using System;
using UnityEngine;

namespace ET
{
	[ActorMessageHandler]
	public class G2M_UnitQuitMapHandler : AMActorLocationHandler<Unit, G2M_UnitQuitMap>
	{
		protected override async ETTask Run(Unit unit, G2M_UnitQuitMap message)
		{
			// 通知客户端开始切场景
			M2C_StartSceneChange m2CStartSceneChange =
					new M2C_StartSceneChange() { SceneInstanceId = message.SceneInstanceId, SceneName = message.SceneName };
			MessageHelper.SendToClient(unit, m2CStartSceneChange);
			
			// 广播给其他人
			M2C_UnitQuitMap quitUnit = new M2C_UnitQuitMap();
			quitUnit.UnitId = message.UnitId;
			MessageHelper.Broadcast(unit, quitUnit);

			// Unit退出房间
			unit?.RemoveComponent<MailBoxComponent>();
			unit?.Dispose();
			Log.Info($"玩家{message.UnitId}主动退出房间");
			
			await ETTask.CompletedTask;
		}
	}
}