
namespace ET
{
	[MessageHandler]
	public class M2C_UnitQuitMapHandler : AMHandler<M2C_UnitQuitMap>
	{
		protected override async ETTask Run(Session session, M2C_UnitQuitMap message)
		{	
			// 逻辑层处理玩家退出
			UnitComponent unitComponent = session.Domain.GetComponent<UnitComponent>();
			PlayerComponent playerComponent = session.DomainScene().CurrentScene().GetComponent<PlayerComponent>();
			unitComponent.Remove(message.UnitId);
			Log.Info($"房间还剩{playerComponent.Children.Count}个玩家");
			
			await Game.EventSystem.PublishAsync(new EventType.LeaveMapFinish() { ZoneScene = session.DomainScene(), UnitId = message.UnitId });
		}
	}
}
