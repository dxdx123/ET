﻿namespace ET
{
    public class AccountSessionsComponentDestroySystem: DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSessionsDictionary.Clear();
        }
    }

    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if (!self.AccountSessionsDictionary.ContainsKey(accountId))
            {
                return 0;
            }

            return self.AccountSessionsDictionary[accountId];
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long sessionInstanceId)
        {
            if (self.AccountSessionsDictionary.ContainsKey(accountId))
            {
                self.AccountSessionsDictionary[accountId] = sessionInstanceId;
            }
            else
            {
                self.AccountSessionsDictionary.Add(accountId, sessionInstanceId);
            }
        }

        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            if (self.AccountSessionsDictionary.ContainsKey(accountId))
            {
                self.AccountSessionsDictionary.Remove(accountId);
            }
        }
    }
}