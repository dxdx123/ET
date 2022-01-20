using System;


namespace ET
{
	[MessageHandler]
	public class C2G_QuitMapHandler : AMRpcHandler<C2G_QuitMap, G2C_QuitMap>
	{
		protected override async ETTask Run(Session session, C2G_QuitMap request, G2C_QuitMap response, Action reply)
		{
			Player myPlayer = session.GetComponent<SessionPlayerComponent>().GetMyPlayer();
			GateMapComponent gateMapComponent = myPlayer.GetComponent<GateMapComponent>();
			UnitGateComponent unitGateComponent = gateMapComponent.DomainScene().GetComponent<UnitGateComponent>();
			UnitComponent unitComponent = unitGateComponent.GetComponent<UnitComponent>();
			Unit unit = unitComponent.GetChild<Unit>(myPlayer.Id);

			// 在map服务器上销毁战斗Unit
			string mapName = unit.DomainScene().Name;
			long sceneInstanceId = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), mapName).InstanceId;
			
			await ActorMessageSenderComponent.Instance.Call(sceneInstanceId,
				new G2M_UnitQuitMap() { UnitId = request.MyId, GateSessionId = session.InstanceId });
			
			reply();
		}
	}
}