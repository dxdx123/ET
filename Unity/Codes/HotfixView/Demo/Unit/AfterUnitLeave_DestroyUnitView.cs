using UnityEngine;

namespace ET
{
    public class AfterUnitQuit_DestroyUnitView : AEvent<EventType.LeaveMapFinish>
    {
        protected override async ETTask Run(EventType.LeaveMapFinish args)
        {
            // View层处理玩家退出
            Log.Info($"销毁玩家[{args.UnitId}]GameObject");
            GlobalComponent.Instance.RemoveUnitGo(args.UnitId);
            
            await ETTask.CompletedTask;
        }
    }
}