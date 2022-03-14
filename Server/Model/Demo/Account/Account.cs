namespace ET
{
    public enum AccountType
    {
        Account = 0,
        General = 1,
        BlackList = 2,
    }
    
    public class Account : Entity, IAwake
    {
        public string AccountName;
        public string Password;
        public int AccountType;
        public long CreateTime;
    }
}