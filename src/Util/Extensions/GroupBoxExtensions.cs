using System;
using System.Windows.Forms;
using System.Drawing;

namespace BartenderUI.Util.Extensions
{
    static class GroupBoxExtensions
    {

        public static GroupBox AddAll(this GroupBox o, params Control[] values)
        {
            foreach (var control in values)
            {
                o.Controls.Add(control);
            }
            return o;
        }

        public static GroupBox WithLocation(this GroupBox o, int value1, int value2)
        {
            o.Location = new Point(value1, value2);
            return o;
        }

        public static GroupBox WithName(this GroupBox o, string value)
        {
            o.Name = value;
            return o;
        }

        public static GroupBox WithSize(this GroupBox o, int value1, int value2)
        {
            o.Size = new Size(value1, value2);
            return o;
        }

        public static GroupBox WithTabIndex(this GroupBox o, int value)
        {
            o.TabIndex = value;
            return o;
        }

        public static GroupBox WithTabStopValue(this GroupBox o, bool value)
        {
            o.TabStop = value;
            return o;
        }

        public static GroupBox WithText(this GroupBox o, string value)
        {
            o.Text = value;
            return o;
        }

        public static GroupBox Clear(this GroupBox o)
        {
            o.Controls.Clear();
            return o;
        }
    }
}
