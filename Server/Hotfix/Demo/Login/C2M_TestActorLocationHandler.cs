using System;
using MongoDB.Driver.Core.WireProtocol.Messages;

namespace ET
{
    public class C2M_TestActorLocationHandler : AMActorLocationRpcHandler<Unit, C2M_TestActorLocationRequest, M2C_TestActorLocationResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TestActorLocationRequest request, M2C_TestActorLocationResponse response, Action reply)
        {
            Log.Debug($"--------{request.Content}----------");
            response.Content = "11111111111";
            
            reply();
            await ETTask.CompletedTask;
        }
    }
}