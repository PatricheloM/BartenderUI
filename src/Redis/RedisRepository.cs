using System;
using StackExchange.Redis;

namespace BartenderUI.Redis
{
    class RedisRepository
    {
        private static readonly IDatabase db = RedisConnection.GetConnection();

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

        public static HashEntry[] HGetAll(string key)
        {
            return db.HashGetAll(key);
        }

        public static void HDel(string key, string value)
        {
            db.HashDelete(key, value);
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

        public static int Incr(string key)
        {
            return Convert.ToInt32(db.StringIncrement(key));
        }

        public static void Del(string key)
        {
            db.KeyDelete(key);
        }
    }
}
