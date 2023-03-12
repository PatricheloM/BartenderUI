using System;
using StackExchange.Redis;
using System.Windows.Forms;
using BartenderUI.Util.Factories;
using BartenderUI.Util;
using BartenderUI.Redis;

namespace BartenderUI
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Initializer.Initialize();
            Application.EnableVisualStyles();
            try
            {
                RedisRepository.Ping();
                Application.Run(new Layout.Layout());
            }
            catch (TypeInitializationException e) when (e.InnerException.InnerException is RedisConnectionException)
            {
                if (MessageBoxFactory.Produce(MessageBoxFactory.GetRedisConnectionErrorText(), MessageBoxFactory.GetRedisConnectionErrorTitle(), MessageBoxButtons.RetryCancel) == MessageBoxFactory.GetRetryResult())
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
