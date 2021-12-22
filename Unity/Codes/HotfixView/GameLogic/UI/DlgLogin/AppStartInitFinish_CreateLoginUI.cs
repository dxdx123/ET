

using ET.EventType;

namespace ET
{
	public class AppStartInitFinish_RemoveLoginUI: AEvent<EventType.AppStartInitFinish>
	{
		protected override async ETTask Run(AppStartInitFinish args)
		{
			await UIComponent.Instance.ShowWindowAsync(WindowID.WindowID_Login);
		}
	}
}
