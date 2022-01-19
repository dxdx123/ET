namespace ET
{
    public class AfterCreateZoneScene_AddComponent: AEvent<EventType.AfterCreateZoneScene>
    {
        protected override async ETTask Run(EventType.AfterCreateZoneScene args)
        {
            Scene zoneScene = args.ZoneScene;
            zoneScene.AddComponent<UIComponent>();
            zoneScene.AddComponent<ResourcesLoaderComponent>();
            zoneScene.AddComponent<UIEventComponent>();
            zoneScene.AddComponent<UIPathComponent>();
            await ETTask.CompletedTask;
        }
    }
}