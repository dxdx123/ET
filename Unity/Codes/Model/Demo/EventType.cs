namespace ET
{
    namespace EventType
    {
        public struct AppStart
        {
        }

        public struct ChangePosition
        {
            public Unit Unit;
        }

        public struct ChangeRotation
        {
            public Unit Unit;
        }

        public struct PingChange
        {
            public Scene ZoneScene;
            public long Ping;
        }
        
        public struct AfterCreateZoneScene
        {
            public Scene ZoneScene;
        }
        
        public struct AfterCreateLoginScene
        {
            public Scene LoginScene;
        }

        public struct AppStartInitFinish
        {
            public Scene ZoneScene;
        }

        public struct LoginFinish
        {
            public Scene ZoneScene;
        }

        public struct LoadingBegin
        {
            public Scene Scene;
        }

        public struct LoadingFinish
        {
            public Scene Scene;
        }
        
        public struct EnterMapFinish
        {
            public Scene ZoneScene;
            public Unit MyUnit;
        }
        
        // 别的玩家退出
        public struct LeaveMapFinish
        {
            public Scene ZoneScene;
            public long UnitId;
        }

        // 玩家自己退出
        public struct QuitMapFinish
        {
            public Scene ZoneScene;
            public Unit Unit;
        }
        

        public struct AfterUnitCreate
        {
            public Unit Unit;
        }
        
        public struct MoveStart
        {
            public Unit Unit;
            public float Speed;
        }

        public struct MoveStop
        {
            public Unit Unit;
        }
    }
}