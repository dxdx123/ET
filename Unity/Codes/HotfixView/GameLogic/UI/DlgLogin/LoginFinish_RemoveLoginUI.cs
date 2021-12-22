

using ET.EventType;

namespace ET
{
	public class LoginFinish_RemoveLoginUI: AEvent<EventType.LoginFinish>
	{
		protected override async ETTask Run(LoginFinish args)
		{
			UIComponent.Instance.CloseWindow(WindowID.WindowID_Login);
			await ETTask.CompletedTask;
		}
	}
}
