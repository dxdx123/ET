using System;
using UnityEngine;

namespace ET
{
	[ActorMessageHandler]
	public class G2M_UnitQuitMapHandler : AMActorLocationHandler<Unit, G2M_UnitQuitMap>
	{
		protected override async ETTask Run(Unit unit, G2M_UnitQuitMap message)
		{
			// 广播给其他人
			M2C_UnitQuitMap quitUnit = new M2C_UnitQuitMap();
			quitUnit.UnitId = message.UnitId;
			MessageHelper.Broadcast(unit, quitUnit);

			// Unit退出房间
			unit?.Dispose();
			Log.Info($"玩家{message.UnitId}主动退出房间");
			
			await ETTask.CompletedTask;
		}
	}
}