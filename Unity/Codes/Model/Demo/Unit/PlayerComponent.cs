namespace ET
{
    public class PlayerComponent: Entity, IAwake
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long MyId; 
        
        /// <summary>
        /// 用户登陆名
        /// </summary>
        public string UserName; 
    }
}