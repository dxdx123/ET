using System;


namespace ET
{
	[MessageHandler]
	public class C2G_QuitMapHandler : AMRpcHandler<C2G_QuitMap, G2C_QuitMap>
	{
		protected override async ETTask Run(Session session, C2G_QuitMap request, G2C_QuitMap response, Action reply)
		{
			// 移除GateMapComponent
			SessionPlayerComponent sessionPlayerComponent = session.GetComponent<SessionPlayerComponent>();
			Player myPlayer = sessionPlayerComponent.GetMyPlayer();
			myPlayer.RemoveComponent<GateMapComponent>();

			StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Lobby");
			
			// 在map服务器上销毁战斗Unit
			await ActorLocationSenderComponent.Instance.Call(sessionPlayerComponent.PlayerId,
				new G2M_UnitQuitMap() { UnitId = request.MyId, SceneInstanceId = startSceneConfig.InstanceId, SceneName = startSceneConfig.Name });
			
			reply();
			await ETTask.CompletedTask;
		}
	}
}