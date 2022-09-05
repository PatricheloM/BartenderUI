using System;
using System.Windows.Forms;

namespace BartenderUI.Util.Builders
{
    class TimerBuilder :Timer
    {
        public TimerBuilder WithInterval(int value)
        {
            Interval = value;
            return this;
        }

        public TimerBuilder AddTickEvent(EventHandler value)
        {
            Tick += value;
            return this;
        }

        public TimerBuilder WithEnabledValue(bool value)
        {
            Enabled = value;
            return this;
        }
    }
}
