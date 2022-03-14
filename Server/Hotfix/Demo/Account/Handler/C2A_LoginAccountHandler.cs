using System;

namespace ET
{
    public class C2A_LoginAccountHandler: AMRpcHandler<C2A_LoginAccount, A2C_LoginAccount>
    {
        protected override async ETTask Run(Session session, C2A_LoginAccount request, A2C_LoginAccount response, Action reply)
        {
            // 判断sencetype类型，如果不是account则断开session
            // 处理同一玩家多次请求，判断SessionLockingComponent是否为空
            // 判断用户名密码是否为空
            // 判断是否黑名单
            // 判断是否密码正确
            // 生成Token，并保存到Token组件
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误，当前Scene：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            // 防止登陆后断开连接
            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            // 加锁防止客户端同一请求多次发送
            if (session.DomainScene().GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                await session.Disconnect();
                reply();
                return;
            }

            if (string.IsNullOrEmpty(request.AccountName.Trim()) || string.IsNullOrEmpty(request.Password.Trim()))
            {
                response.Error = ErrorCode.ERR_LoginInfoIsNull;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            // 防止同一客户端重复请求
            using (session.AddComponent<SessionLockingComponent>())
            {
                // 使用协程锁，防止不同玩家创建相同用户名
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.AccountName.Trim().GetHashCode()))
                {
                    var accoutList = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                            .Query<Account>(d => d.AccountName.Equals(request.AccountName.Trim()));
                    Account account = null;
                    if (accoutList != null && accoutList.Count > 0)
                    {
                        account = accoutList[0];
                        session.AddChild(account);
                        if (account.AccountType == (int) AccountType.BlackList)
                        {
                            response.Error = ErrorCode.ERR_AccountInBlackListError;
                            reply();
                            session.Disconnect().Coroutine();
                            account?.Dispose();
                            return;
                        }

                        if (!account.Password.Equals(request.Password.Trim()))
                        {
                            response.Error = ErrorCode.ERR_LoginPasswordError;
                            reply();
                            session.Disconnect().Coroutine();
                            account?.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        account = session.AddChild<Account>();
                        account.AccountName = request.AccountName.Trim();
                        account.Password = request.Password.Trim();
                        account.CreateTime = TimeHelper.ServerNow();
                        account.AccountType = (int) AccountType.General;
                        await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save(account);
                    }
                    // 顶号判断，如果是则踢其他玩家账号下线，并更新当前玩家session
                    var accountSessionInstanceId = session.DomainScene().GetComponent<AccountSessionsComponent>().Get(account.Id);
                    var otherSession = Game.EventSystem.Get(accountSessionInstanceId) as Session;
                    otherSession?.Send(new A2C_Disconnect() { Error = 0 });
                    otherSession?.Disconnect().Coroutine();
                    session.DomainScene().GetComponent<AccountSessionsComponent>().Add(account.Id, session.InstanceId);

                    // 用户空闲或异常断开10分钟，自动断开连接
                    session.AddComponent<AccountCheckOutTimeComponent, long>(account.Id);
                            
                    // 创建Token
                    var token = TimeHelper.ClientNow().ToString() + RandomHelper.RandomNumber(0, int.MaxValue);
                    session.DomainScene().GetComponent<TokenComponent>().Remove(account.Id);
                    session.DomainScene().GetComponent<TokenComponent>().Add(account.Id, token);

                    response.AccountId = account.Id;
                    response.Token = token;
                    
                    reply();
                    account?.Dispose();
                }
            }
        }
    }
}