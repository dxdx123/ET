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