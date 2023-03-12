using System;
using StackExchange.Redis;
using System.Windows.Forms;
using BartenderUI.Util.Factories;
using BartenderUI.Util;

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
                ConnectionTester.Test();
                Application.Run(new Layout.Layout());
            }
            catch (RedisConnectionException)
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
