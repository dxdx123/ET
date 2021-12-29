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
            var unitComponent = gateSession.Domain.GetComponent<UnitComponent>();
            var quit = await gateSession.Call(new C2G_QuitMap() { UnitId = unitComponent.MyUnit.Id });
            if (quit.Error == 0)
            {
                // 销毁Unit逻辑对象
                unitComponent.RemoveAll();

                Game.EventSystem.Publish(new EventType.QuitMapFinish() { ZoneScene = zoneScene, Unit = unitComponent.MyUnit }).Coroutine();
                
                Log.Info($"玩家[{unitComponent.MyUnit.Id}]主动退出房间");
            }
        }
    }
}