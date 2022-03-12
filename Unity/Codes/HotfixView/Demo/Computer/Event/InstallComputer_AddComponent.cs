namespace ET
{
    public class InstallComputer_AddComponent : AEvent<EventType.InstallComputer>
    {
        protected override async ETTask Run(EventType.InstallComputer arg)
        {
            await TimerComponent.Instance.WaitAsync(1000);
            Computer computer = arg.computer;

            computer.AddComponent<PCCaseComponent>();
            computer.AddComponent<MornitorsComponent>();
            computer.AddComponent<KeyBoardComponent>();
            computer.AddComponent<MouseComponent>();

            await ETTask.CompletedTask;
        }
    }
}