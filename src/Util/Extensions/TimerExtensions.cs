using System;
using System.Windows.Forms;

namespace BartenderUI.Util.Extensions
{
    static class TimerExtensions
    {
        public static Timer WithInterval(this Timer o, int value)
        {
            o.Interval = value;
            return o;
        }

        public static Timer AddTickEvent(this Timer o, EventHandler value)
        {
            o.Tick += value;
            return o;
        }

        public static Timer WithEnabledValue(this Timer o, bool value)
        {
            o.Enabled = value;
            return o;
        }
    }
}
