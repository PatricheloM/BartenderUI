using System;
using System.Windows.Forms;
using System.Drawing;

namespace BartenderUI.Util.Extensions
{
    static class FormExtensions
    {

        public static Form AddAll(this Form o, params Control[] values)
        {
            foreach (var control in values)
            {
                o.Controls.Add(control);
            }
            return o;
        }

        public static Form WithClientSize(this Form o, int value1, int value2)
        {
            o.ClientSize = new Size(value1, value2);
            return o;
        }

        public static Form WithFormBorderStyle(this Form o, FormBorderStyle value)
        {
            o.FormBorderStyle = value;
            return o;
        }

        public static Form WithName(this Form o, string value)
        {
            o.Name = value;
            return o;
        }

        public static Form WithText(this Form o, string value)
        {
            o.Text = value;
            return o;
        }

        public static Form WithState(this Form o, FormWindowState value)
        {
            o.WindowState = value;
            return o;
        }

        public static Form WithIcon(this Form o, string value)
        {
            try
            {
                o.Icon = new Icon(value);
            }
            catch (Exception)
            {
            }
            return o;
        }

        public static Form WithShowIconValue(this Form o, bool value)
        {
            o.ShowIcon = value;
            return o;
        }

        public static Form WithShowInTaskbarValue(this Form o, bool value)
        {
            o.ShowInTaskbar = value;
            return o;
        }

        public static Form WithFormClosingEvent(this Form o, FormClosingEventHandler value)
        {
            o.FormClosing += value;
            return o;
        }
    }
}
