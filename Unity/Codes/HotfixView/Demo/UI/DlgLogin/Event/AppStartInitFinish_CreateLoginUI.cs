

using ET.EventType;

namespace ET
{
	public class AppStartInitFinish_RemoveLoginUI: AEvent<EventType.AppStartInitFinish>
	{
		protected override async ETTask Run(AppStartInitFinish args)
		{
			await args.ZoneScene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Login);
		}
	}
}
