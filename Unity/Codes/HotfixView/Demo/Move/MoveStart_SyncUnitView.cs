namespace ET
{
    public class UnitMoveStart : AEvent<EventType.MoveStart>
    {
        protected override async ETTask Run(EventType.MoveStart args)
        {
            var animatorComponent = args.Unit.GetComponent<AnimatorComponent>();
            animatorComponent.MotionType = MotionType.Run;
            animatorComponent.MontionSpeed = args.Speed;

            await ETTask.CompletedTask;
        }
    }
}