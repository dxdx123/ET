

using UnityEngine;

namespace ET
{
	public class LoginFinish_RemoveLoginUI: AEvent<EventType.LoginFinish>
	{
		protected override async ETTask Run(EventType.LoginFinish args)
		{
			await UIHelper.Remove(args.ZoneScene, UIType.UILogin);

			/*Log.Debug("1111111111");
			ETCancellationToken cancellationToken = new ETCancellationToken();
			MoveAsync(new Vector3(0, 0, 0), cancellationToken).Coroutine();
			
			Log.Debug("2222222222");*/
			//cancellationToken.Cancel();
		}

		protected async ETTask<int> TestAsync()
		{
			Log.Debug("3333333333");
			await TimerComponent.Instance.WaitAsync(20000);
			Log.Debug("44444444444");
			
			return 10;
		}
		
		protected async ETTask MoveAsync( Vector3 position,  ETCancellationToken cancellationToken)
		{
			Log.Debug("Move Start");
			var result = await TimerComponent.Instance.WaitAsync(3000, cancellationToken);
			if (result)
			{
				Log.Debug("Move Over");
			}
			else
			{
				Log.Debug("Move Stop");
			}
		}
	}
}
