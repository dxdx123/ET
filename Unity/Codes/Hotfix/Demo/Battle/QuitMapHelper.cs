namespace ET
{
    /// <summary>
    /// 退出房间逻辑
    /// </summary>
    public static class QuitMapHelper
    {
        public static async ETTask QuitMap(Scene zoneScene)
        {
            Session gateSession = zoneScene.GetComponent<SessionComponent>().Session;
            PlayerComponent playerComponent = zoneScene.GetComponent<PlayerComponent>();
            UnitComponent unitComponent = gateSession.DomainScene().CurrentScene().GetComponent<UnitComponent>();
            G2C_QuitMap quit = (G2C_QuitMap) await gateSession.Call(new C2G_QuitMap() { MyId = playerComponent.MyId });
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