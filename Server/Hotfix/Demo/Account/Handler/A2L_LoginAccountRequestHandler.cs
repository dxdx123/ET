using System;

namespace ET
{
    public class A2L_LoginAccountRequestHandler : AMActorRpcHandler<Scene, A2L_LoginAccountRequest, L2A_LoginAccountResponse>
    {
        protected override async ETTask Run(Scene scene, A2L_LoginAccountRequest request, L2A_LoginAccountResponse response, Action reply)
        {
            var accoutId = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock, accoutId.GetHashCode()))
            {
                if (!scene.GetComponent<LoginInfoRecordComponent>().IsExist(accoutId))
                {
                    reply();
                    return;
                }
            
                var zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accoutId);
                var gateConfig = RealmGateAddressHelper.GetGate(zone, accoutId);
                
                // 发送Actor消息给Gate，踢玩家下线
                var l2gDisconnectGateUnit = await MessageHelper.CallActor(gateConfig.InstanceId, new L2G_DisconnectGateUnit() { AccountId = accoutId });
                
                response.Error = l2gDisconnectGateUnit.Error;
                reply();
            }
            
        }
    }
}