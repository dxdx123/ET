namespace ET
{
    public class AccountInfoComponentAwakeSystem: AwakeSystem<AccountInfoComponent>
    {
        public override void Awake(AccountInfoComponent self)
        {
            
        }
    }
    public class AccountInfoComponentUpdateSystem: UpdateSystem<AccountInfoComponent>
    {
        public override void Update(AccountInfoComponent self)
        {
            
        }
    }
    public class AccountInfoComponentDestroySystem: DestroySystem<AccountInfoComponent>
    {
        public override void Destroy(AccountInfoComponent self)
        {
            self.AccountId = 0;
            self.Token = "";
        }
    }


    public static class AccountInfoComponentSystem
    {
        
    }
}