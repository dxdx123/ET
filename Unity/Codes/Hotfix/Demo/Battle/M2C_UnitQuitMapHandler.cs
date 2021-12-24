
namespace ET
{
	[MessageHandler]
	public class M2C_UnitQuitMapHandler : AMHandler<M2C_UnitQuitMap>
	{
		protected override async ETTask Run(Session session, M2C_UnitQuitMap message)
		{	
			// 逻辑层处理玩家退出
			UnitComponent unitComponent = session.Domain.GetComponent<UnitComponent>();
			unitComponent.Remove(message.UnitId);
			Log.Info($"房间还剩{unitComponent.idUnits.Count}个玩家");
			
			Game.EventSystem.Publish(new EventType.LeaveMapFinish() { ZoneScene = session.DomainScene(), Unit = unitComponent.MyUnit });
			await ETTask.CompletedTask;
		}
	}
}
