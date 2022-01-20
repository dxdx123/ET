using System;


namespace ET
{
	[MessageHandler]
	public class C2G_QuitMapHandler : AMRpcHandler<C2G_QuitMap, G2C_QuitMap>
	{
		protected override async ETTask Run(Session session, C2G_QuitMap request, G2C_QuitMap response, Action reply)
		{
			SessionPlayerComponent sessionPlayerComponent = session.GetComponent<SessionPlayerComponent>();

			// 在map服务器上销毁战斗Unit
			await ActorLocationSenderComponent.Instance.Call(sessionPlayerComponent.PlayerId,
				new G2M_UnitQuitMap() { UnitId = request.MyId, GateSessionId = session.InstanceId });
			
			reply();
			await ETTask.CompletedTask;
		}
	}
}