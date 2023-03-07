using System;
using System.Windows.Forms;
using BartenderUI.Util.Extensions;

namespace BartenderUI.Util.Factories
{
    class TimerFactory
    {
        public static Timer Produce(int interval, EventHandler e)
        {
            return new Timer()
                .WithInterval(interval)
                .AddTickEvent(e)
                .WithEnabledValue(true);
        }
    }
}
