using System;
using UnityEngine;

namespace ET
{
	[ActorMessageHandler]
	public class G2M_UnitQuitMapHandler : AMActorRpcHandler<Scene, G2M_UnitQuitMap, M2G_UnitQuitMap>
	{
		protected override async ETTask Run(Scene scene, G2M_UnitQuitMap request, M2G_UnitQuitMap response, Action reply)
		{
			// 广播给其他人
			UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
			Unit unit = unitComponent.Get(request.UnitId);
			
			M2C_UnitQuitMap quitUnit = new M2C_UnitQuitMap();
			quitUnit.UnitId = request.UnitId;
			MessageHelper.Broadcast(unit, quitUnit);

			// Unit退出房间
			unitComponent.Remove(request.UnitId);
			Log.Info($"玩家{request.UnitId}主动退出房间");
			
			reply();
			await ETTask.CompletedTask;
		}
	}
}