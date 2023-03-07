using System;
using System.Windows.Forms;
using System.Drawing;

namespace BartenderUI.Util.Extensions
{
    static class ButtonExtensions
    {

        public static Button WithFont(this Button o, string value1, float value2)
        {
            o.Font = new Font(value1, value2);
            return o;
        }

        public static Button WithFont(this Button o, string value1, float value2, FontStyle value3)
        {
            o.Font = new Font(value1, value2, value3);
            return o;
        }

        public static Button WithLocation(this Button o, int value1, int value2)
        {
            o.Location = new Point(value1, value2);
            return o;
        }

        public static Button WithName(this Button o, string value)
        {
            o.Name = value;
            return o;
        }

        public static Button WithSize(this Button o, int value1, int value2)
        {
            o.Size = new Size(value1, value2);
            return o;
        }

        public static Button WithTabIndex(this Button o, int value)
        {
            o.TabIndex = value;
            return o;
        }

        public static Button WithText(this Button o, string value)
        {
            o.Text = value;
            return o;
        }

        public static Button WithVisualStyleBackColorValue(this Button o, bool value)
        {
            o.UseVisualStyleBackColor = value;
            return o;
        }

        public static Button AddClickEvent(this Button o, EventHandler value)
        {
            o.Click += value;
            return o;
        }
    }
}
