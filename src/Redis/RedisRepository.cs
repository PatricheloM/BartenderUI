using System;
using System.Collections.Generic;
using StackExchange.Redis;

namespace BartenderUI.Redis
{
    class RedisRepository
    {
        private static readonly IDatabase db = RedisConnection.GetConnection();
        private static readonly IServer server = RedisConnection.GetServer();

        public static void Publish(string channel, string message)
        {
            db.Publish(channel, message);
        }

        public void Set(string key, string value)
        {
            db.StringSet(key, value);
        }

        public static string Get(string key)
        {
            return db.StringGet(key);
        }

        public static string HGet(string key, string field)
        {
            return db.HashGet(key, field);
        }

        public static void HMSet(string key, params HashEntry[] values)
        {
            db.HashSet(key, values);
        }

        public static void HIncrBy(string key, string value, int amount)
        {
            db.HashIncrement(key, value, amount);
        }

        public static HashEntry[] HGetAll(string key)
        {
            return db.HashGetAll(key);
        }

        public static bool HDel(string key, string value)
        {
            return db.HashDelete(key, value);
        }

        public static void SAdd(string key, string value)
        {
            db.SetAdd(key, value);
        }

        public static string[] SMembers(string key)
        {
            return db.SetMembers(key).ToStringArray();
        }

        public static void SRem(string key, string value)
        {
            db.SetRemove(key, value);
        }

        public static bool SIsMember(string key, string value)
        {
            return Array.IndexOf(SMembers(key), value) != -1;
        }

        public static void LPush(string key, params string[] values)
        {
            foreach (string value in values)
            {
                db.ListLeftPush(key, value);
            }
        }

        public static string[] LRange(string key)
        { 
            return db.ListRange(key).ToStringArray();
        }

        public static int Incr(string key)
        {
            return Convert.ToInt32(db.StringIncrement(key));
        }

        public static bool Del(string key)
        {
            return db.KeyDelete(key);
        }

        public static bool Exists(string key)
        {
            return db.KeyExists(key);
        }

        public static IEnumerable<RedisKey> Keys(string pattern)
        {
            return server.Keys(pattern: pattern);
        }
    }
}
