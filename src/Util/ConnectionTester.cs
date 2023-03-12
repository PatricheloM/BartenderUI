using BartenderUI.Redis;
using StackExchange.Redis;
using System;

namespace BartenderUI.Util
{
    class ConnectionTester
    {
        public static void Test()
        {
            try
            {
                RedisRepository.Ping();
            }
            catch (Exception)
            {
                throw new RedisConnectionException(ConnectionFailureType.SocketFailure, "Can not connect to this adderss or invalid password!");
            }
        }
    }
}
