

namespace ET
{
	public class LoginFinish_CreateLobbyUI: AEvent<EventType.LoginFinish>
	{
		protected override async ETTask Run(EventType.LoginFinish args)
		{
			// 加载场景资源
			await ResourcesComponent.Instance.LoadBundleAsync("lobby.unity3d");
			// 切换到map场景
			SceneChangeComponent sceneChangeComponent = null;
			try
			{
				sceneChangeComponent = Game.Scene.AddComponent<SceneChangeComponent>();
				{
					await sceneChangeComponent.ChangeSceneAsync("Lobby");
				}
			}
			finally
			{
				sceneChangeComponent?.Dispose();
			}
			
			await args.ZoneScene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Lobby);
		}
	}
}
