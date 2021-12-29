using System.Runtime.CompilerServices;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class GlobalComponentAwakeSystem: AwakeSystem<GlobalComponent>
    {
        public override void Awake(GlobalComponent self)
        {
            GlobalComponent.Instance = self;
            
            self.Global = GameObject.Find("/Global").transform;
            self.Unit = GameObject.Find("/Global/UnitRoot").transform;
            self.UI = GameObject.Find("/Global/UIRoot").transform;
            
            self.NormalRoot = GameObject.Find("Global/UIRoot/NormalRoot").transform;
            self.PopUpRoot = GameObject.Find("Global/UIRoot/PopUpRoot").transform;
            self.FixedRoot = GameObject.Find("Global/UIRoot/FixedRoot").transform;
            self.OtherRoot = GameObject.Find("Global/UIRoot/OtherRoot").transform;
            self.PoolRoot =  GameObject.Find("Global/PoolRoot").transform;
        }
    }

    public static class GlobalComponentSystem
    {
        public static void AddUnitGo(this GlobalComponent self, long unitId , GameObject go)
        {
            self.UnitId2GameObjects.Add(unitId, go);
        }
        
        public static void RemoveUnitGo(this GlobalComponent self, long unitId)
        {
            GameObject go = null;
            if (self.UnitId2GameObjects.TryGetValue(unitId, out go))
            {
                self.UnitId2GameObjects.Remove(unitId);
                UnityEngine.Object.Destroy(go);
            }
        }
    }
}