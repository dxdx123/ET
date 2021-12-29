using UnityEngine;

namespace ET
{
	public class QuitMapFinish_CreateLobbyUI: AEvent<EventType.QuitMapFinish>
	{
		protected override async ETTask Run(EventType.QuitMapFinish args)
		{
			// 销毁Map上的gameObject
			GlobalComponent.Instance.RemoveAllUnitGo();

			#region 切换到场景
			// 加载场景资源
			await ResourcesComponent.Instance.LoadBundleAsync("lobby.unity3d");
			// 切换到lobby场景
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

			#endregion
			
			args.ZoneScene.RemoveComponent<OperaComponent>();
			args.ZoneScene.RemoveComponent<CameraComponent>();
			
			UIComponent.Instance.CloseWindow(WindowID.WindowID_Battle);
			await UIComponent.Instance.ShowWindowAsync(WindowID.WindowID_Lobby);
		}
	}
}
