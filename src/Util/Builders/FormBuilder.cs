using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace BartenderUI.Util.Builders
{
    class FormBuilder : Form
    {
        public FormBuilder GetInstance()
        {
            return this;
        }

        public FormBuilder AddAll(params Control[] values)
        {
            foreach (var control in values)
            {
                Controls.Add(control);
            }
            return this;
        }

        public FormBuilder WithClientSize(int value1, int value2)
        {
            ClientSize = new Size(value1, value2);
            return this;
        }

        public FormBuilder WithFormBorderStyle(FormBorderStyle value)
        {
            FormBorderStyle = value;
            return this;
        }

        public FormBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public FormBuilder WithText(string value)
        {
            Text = value;
            return this;
        }

        public FormBuilder WithState(FormWindowState value)
        {
            WindowState = value;
            return this;
        }

        public FormBuilder WithIcon(string value)
        {
            try
            {
                Icon = new Icon(value);
            }
            catch (Exception)
            {
            }
            return this;
        }

        public FormBuilder WithShowIconValue(bool value)
        {
            ShowIcon = value;
            return this;
        }

        public FormBuilder WithShowInTaskbarValue(bool value)
        {
            ShowInTaskbar = value;
            return this;
        }

        public FormBuilder WithFormClosingEvent(FormClosingEventHandler value)
        {
            FormClosing += value;
            return this;
        }
    }
}
