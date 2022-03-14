using System;

namespace ET
{
    public class L2G_DisconnectGateUnitHandler : AMActorRpcHandler<Scene, L2G_DisconnectGateUnit, G2L_DisconnectGateUnit>
    {
        protected override async ETTask Run(Scene scene, L2G_DisconnectGateUnit request, G2L_DisconnectGateUnit response, Action reply)
        {
            var accountId = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.GateCenterLock, accountId.GetHashCode()))
            {
                var playerComponent = scene.GetComponent<PlayerComponent>();
                var player = playerComponent.Get(accountId);
                if (player == null)
                {
                    reply();
                    return;
                }
                
                playerComponent.Remove(accountId);
                player.Dispose();
            }
            
            
            await ETTask.CompletedTask;
        }
    }
}