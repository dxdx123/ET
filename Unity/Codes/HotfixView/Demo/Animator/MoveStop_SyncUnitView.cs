namespace ET
{
    public class UnitMoveStop : AEvent<EventType.MoveStop>
    {
        protected override async ETTask Run(EventType.MoveStop args)
        {
            var animatorComponent = args.Unit.GetComponent<AnimatorComponent>();
            animatorComponent.MotionType = MotionType.Idle;
            animatorComponent.MontionSpeed = 0;

            await ETTask.CompletedTask;
        }
    }
}