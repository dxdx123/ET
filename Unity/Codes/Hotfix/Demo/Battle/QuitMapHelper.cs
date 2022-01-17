namespace ET
{
    /// <summary>
    /// 退出房间逻辑
    /// </summary>
    public static class QuitMapHelper
    {
        public static async ETTask QuitMap(Scene zoneScene)
        {
            var gateSession = zoneScene.GetComponent<SessionComponent>().Session;
            var playerComponent = zoneScene.GetComponent<PlayerComponent>();
            var unitComponent = gateSession.DomainScene().CurrentScene().GetComponent<UnitComponent>();
            var quit = await gateSession.Call(new C2G_QuitMap() { UnitId = playerComponent.MyId });
            if (quit.Error == 0)
            {
                await Game.EventSystem.PublishAsync(new EventType.QuitMapFinish() { ZoneScene = zoneScene, UnitId = playerComponent.MyId });
                // 销毁Unit逻辑对象
                unitComponent.RemoveAll();
                Log.Info($"玩家[{playerComponent.MyId}]主动退出房间");
            }
        }
    }
}