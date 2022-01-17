using UnityEngine.SceneManagement;

namespace ET
{
	public class EnterMapFinish_RemoveLobbyUI: AEvent<EventType.EnterMapFinish>
	{
		protected override async ETTask Run(EventType.EnterMapFinish args)
		{
			#region 加载场景
			// 加载场景资源
			await ResourcesComponent.Instance.LoadBundleAsync("map.unity3d");
			// 切换到map场景
			SceneChangeComponent sceneChangeComponent = null;
			try
			{
				sceneChangeComponent = Game.Scene.AddComponent<SceneChangeComponent>();
				{
					await sceneChangeComponent.ChangeSceneAsync("Map");
				}
			}
			finally
			{
				sceneChangeComponent?.Dispose();
			}
			#endregion
			
			args.ZoneScene.AddComponent<OperaComponent>();
			args.ZoneScene.AddComponent<CameraComponent, Scene, long>(args.ZoneScene, args.MyUnitId);
			
			args.ZoneScene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Lobby);
            await ETTask.CompletedTask;
		}
	}
}
