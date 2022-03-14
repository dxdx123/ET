using System;


namespace ET
{
    public static class LoginHelper
    {
        public static async ETTask<int> Login(Scene zoneScene, string address, string account, string password)
        {
            A2C_LoginAccount a2CLoginAccount = null;
            Session session = null;
            try
            {
                session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                a2CLoginAccount = (A2C_LoginAccount)await session.Call(new C2A_LoginAccount() { AccountName = account, Password = MD5Helper.StringMD5(password) });
                 
            }
            catch (Exception e)
            {
                session?.Dispose();
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetworkError;
            }
            
            if (a2CLoginAccount.Error != ErrorCode.ERR_Success)
            {
                Log.Debug(a2CLoginAccount.Message);
                session?.Dispose();
                return a2CLoginAccount.Error;
            }

            zoneScene.AddComponent<SessionComponent>().Session = session;
            zoneScene.GetComponent<SessionComponent>().Session.AddComponent<PingComponent>();
            
            zoneScene.GetComponent<AccountInfoComponent>().AccountId = a2CLoginAccount.AccountId;
            zoneScene.GetComponent<AccountInfoComponent>().Token = a2CLoginAccount.Token;

            return ErrorCode.ERR_Success;

        } 
    }
}