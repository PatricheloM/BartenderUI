using System;
using BartenderUI.Util.Builders;

namespace BartenderUI.Util.Factories
{
    class TimerFactory
    {
        public static TimerBuilder Produce(int interval, EventHandler e)
        {
            return new TimerBuilder()
                .WithInterval(interval)
                .AddTickEvent(e)
                .WithEnabledValue(true);
        }
    }
}
