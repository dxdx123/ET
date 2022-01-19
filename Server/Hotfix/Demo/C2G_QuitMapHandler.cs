using System;


namespace ET
{
	[MessageHandler]
	public class C2G_QuitMapHandler : AMRpcHandler<C2G_QuitMap, G2C_QuitMap>
	{
		protected override async ETTask Run(Session session, C2G_QuitMap request, G2C_QuitMap response, Action reply)
		{
			// 在map服务器上销毁战斗Unit
			long mapInstanceId = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Map1").InstanceId;
			
			await ActorMessageSenderComponent.Instance.Call(mapInstanceId,
				new G2M_UnitQuitMap() { UnitId = request.UnitId, GateSessionId = session.InstanceId });
			
			reply();
		}
	}
}