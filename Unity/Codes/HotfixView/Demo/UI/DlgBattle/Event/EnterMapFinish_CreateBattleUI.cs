namespace ET
{
	public class EnterMapFinish_CreateBattleUI: AEvent<EventType.EnterMapFinish>
	{
		protected override async ETTask Run(EventType.EnterMapFinish args)
		{
			ShowWindowData data = new ShowWindowData();
			data.contextData = args.ZoneScene.GetComponent<PlayerComponent>();
			await args.ZoneScene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Battle, WindowID.WindowID_Lobby, data);
			args.ZoneScene.AddComponent<CameraComponent, Scene>(args.ZoneScene);
		}
	}
}
