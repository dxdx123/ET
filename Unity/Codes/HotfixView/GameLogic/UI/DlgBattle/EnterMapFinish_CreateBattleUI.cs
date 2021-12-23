namespace ET
{
	public class EnterMapFinish_CreateBattleUI: AEvent<EventType.EnterMapFinish>
	{
		protected override async ETTask Run(EventType.EnterMapFinish args)
		{
			await UIComponent.Instance.ShowWindowAsync(WindowID.WindowID_Battle);
		}
	}
}
