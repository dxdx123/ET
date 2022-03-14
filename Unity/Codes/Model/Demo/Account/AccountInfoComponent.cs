namespace ET
{
    public class AccountInfoComponent : Entity, IAwake, IUpdate, IDestroy
    {
        public string AccountName;
        public string Token;
        public long AccountId;
    }
}