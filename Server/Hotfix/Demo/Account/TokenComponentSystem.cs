namespace ET
{
    public static class TokenComponentSystem
    {
        // 增，删，查
        // 改,令牌要设置过期时间

        public static void Add(this TokenComponent self, long key, string token)
        {
            self.TokenDictionary.Add(key, token);
            self.TimeOutRemoveKey(key, token).Coroutine();
        }

        public static string Get(this TokenComponent self, long key)
        {
            string returnValut = null;
            self.TokenDictionary.TryGetValue(key, out returnValut);
            return returnValut;
        }

        public static void Remove(this TokenComponent self, long key)
        {
            if (self.TokenDictionary.ContainsKey(key))
            {
                self.TokenDictionary.Remove(key);
            }
        }

        private static async ETTask TimeOutRemoveKey(this TokenComponent self, long key, string tokenKey)
        {
            await TimerComponent.Instance.WaitAsync(600000);
            string onlineToken = self.Get(key);
            if (!string.IsNullOrEmpty(onlineToken) && onlineToken.Equals(tokenKey))
            {
                self.Remove(key);
            }
        }
    }
}