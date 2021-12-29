using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class GlobalComponent: Entity
    {
        public static GlobalComponent Instance;
        public Dictionary<long, GameObject> UnitId2GameObjects = new Dictionary<long, GameObject>();
        
        public Transform Global;
        public Transform Unit;
        public Transform UI;
        
        public Transform NormalRoot;
        public Transform PopUpRoot;
        public Transform FixedRoot;
        public Transform PoolRoot;
        public Transform OtherRoot;
    }
}