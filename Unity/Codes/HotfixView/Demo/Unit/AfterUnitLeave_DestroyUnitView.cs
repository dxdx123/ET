using UnityEngine;

namespace ET
{
    public class AfterUnitQuit_DestroyUnitView : AEvent<EventType.LeaveMapFinish>
    {
        protected override async ETTask Run(EventType.LeaveMapFinish args)
        {
            // View层处理玩家退出
            args.Unit?.Dispose();
            
            //GlobalComponent.Instance.Unit.
            await ETTask.CompletedTask;
        }
    }
}