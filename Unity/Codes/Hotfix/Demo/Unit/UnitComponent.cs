﻿using System.Linq;

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
			foreach (var unitId in self.Children.Keys)
			{
				Unit unit;
				self.Children.TryGetValue(unitId, out Entity entity);
				self.Children.Remove(unitId);
				
				unit = entity as Unit;
				unit?.Dispose();
			}
		}

		public static void RemoveNoDispose(this UnitComponent self, long id)
		{
			self.Children.Remove(id);
		}

		public static Entity[] GetAll(this UnitComponent self)
		{
			return self.Children.Values.ToArray();
		}
	}
}