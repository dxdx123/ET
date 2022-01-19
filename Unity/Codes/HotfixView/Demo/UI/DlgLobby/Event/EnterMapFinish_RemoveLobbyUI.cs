using UnityEngine.SceneManagement;

namespace ET
{
	public class EnterMapFinish_RemoveLobbyUI: AEvent<EventType.EnterMapFinish>
	{
		protected override async ETTask Run(EventType.EnterMapFinish args)
		{
			args.ZoneScene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Lobby);
            await ETTask.CompletedTask;
		}
	}
}
