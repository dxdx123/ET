namespace ET
{
	[ObjectSystem]
	public class UnitComponentAwakeSystem : AwakeSystem<UnitComponent>
	{
		public override void Awake(UnitComponent self)
		{
		}
	}
	
	[ObjectSystem]
	public class UnitComponentDestroySystem : DestroySystem<UnitComponent>
	{
		public override void Destroy(UnitComponent self)
		{
		}
	}
	
	public static class UnitComponentSystem
	{
		public static void Add(this UnitComponent self, Unit unit)
		{
		}

		public static Unit Get(this UnitComponent self, long id)
		{
			Unit unit = self.GetChild<Unit>(id);
			return unit;
		}

		public static void Remove(this UnitComponent self, long id)
		{
			Unit unit = self.GetChild<Unit>(id);
			unit?.Dispose();
		}
		
		public static void RemoveAll(this UnitComponent self)
		{
			foreach (var unitId in self.idUnits.Keys)
			{
				Unit unit;
				self.idUnits.TryGetValue(unitId, out unit);
				self.idUnits.Remove(unitId);
				unit?.Dispose();
			}
		}

		public static void RemoveNoDispose(this UnitComponent self, long id)
		{
			self.idUnits.Remove(id);
		}

		public static Unit[] GetAll(this UnitComponent self)
		{
			return self.idUnits.Values.ToArray();
		}
	}
}