using UnityEngine;

namespace ET
{
	public class QuitMapFinish_CreateLobbyUI: AEvent<EventType.QuitMapFinish>
	{
		protected override async ETTask Run(EventType.QuitMapFinish args)
		{
			// 销毁Map上的gameObject
			GlobalComponent.Instance.RemoveAllUnitGo();

			args.ZoneScene.RemoveComponent<OperaComponent>();
			//args.ZoneScene.RemoveComponent<CameraComponent>();

			CurrentScenesComponent currentScenesComponent = args.ZoneScene.GetComponent<CurrentScenesComponent>();
			await SceneChangeHelper.SceneChangeTo(args.ZoneScene, "Lobby", currentScenesComponent.InstanceId);
			
			args.ZoneScene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Battle);
			await args.ZoneScene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Lobby);
		}
	}
}
