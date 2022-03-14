namespace ET
{
    public class AccountCheckOutTimeComponent : Entity, IAwake<long>, IDestroy
    {
        public long Timer = 0; // Timer的id
        public long AccountId = 0;
    }
}