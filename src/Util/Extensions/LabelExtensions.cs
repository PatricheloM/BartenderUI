using System;
using System.Windows.Forms;
using System.Drawing;
using BartenderUI.Util.Factories;

namespace BartenderUI.Util.Extensions
{
    static class LabelExtensions
    {
        public static Label WithFont(this Label o, string value1, float value2)
        {
            o.Font = new Font(value1, value2);
            return o;
        }

        public static Label WithFont(this Label o, string value1, float value2, FontStyle value3)
        {
            o.Font = new Font(value1, value2, value3);
            return o;
        }

        public static Label WithLocation(this Label o, int value1, int value2)
        {
            o.Location = new Point(value1, value2);
            return o;
        }

        public static Label WithName(this Label o, string value)
        {
            o.Name = value;
            return o;
        }

        public static Label WithSize(this Label o, int value1, int value2)
        {
            o.Size = new Size(value1, value2);
            return o;
        }

        public static Label WithTabIndex(this Label o, int value)
        {
            o.TabIndex = value;
            return o;
        }

        public static Label WithText(this Label o, string value)
        {
            o.Text = value;
            return o;
        }

        public static Label AddClickEvent(this Label o, EventHandler value)
        {
            o.Click += value;
            return o;
        }

        public static Label WithAutoSizeValue(this Label o, bool value)
        {
            o.AutoSize = value;
            return o;
        }

        public static Label WithBackColor(this Label o, Color value)
        {
            o.BackColor = value;
            return o;
        }

        public static Label WithForeColor(this Label o, Color value)
        {
            o.ForeColor = value;
            return o;
        }

        public static Label WithFlashing(this Label o, int value, params Color[] values)
        {
            int colors = values.Length;
            int counter = 0;

            Timer timer = TimerFactory.Produce(value, (sender, e) =>
            {
                if (colors - counter == 1) counter = 0;
                else counter++;

                o.WithForeColor(values[counter]);
            });

            return o;
        }

        public static Label WithHiddenValue(this Label o, bool value)
        {
            switch (value)
            {
                case true:
                    o.Hide();
                    break;
                case false:
                    o.Show();
                    break;
            }
            return o;
        }
    }
}
