using System;
using System.Windows.Forms;
using System.Drawing;

namespace BartenderUI.Util.Builders
{
    class GroupBoxBuilder : GroupBox, IBuilder<GroupBoxBuilder>
    {
        public GroupBoxBuilder()
        {
            GetInstance()
                .WithTabStopValue(false)
                .WithTabIndex(0);
        }

        public GroupBoxBuilder GetInstance()
        {
            return this;
        }

        public GroupBoxBuilder AddAll(params Control[] values)
        {
            foreach (var control in values)
            {
                Controls.Add(control);
            }
            return this;
        }

        public GroupBoxBuilder WithLocation(int value1, int value2)
        {
            Location = new Point(value1, value2);
            return this;
        }

        public GroupBoxBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public GroupBoxBuilder WithSize(int value1, int value2)
        {
            Size = new Size(value1, value2);
            return this;
        }

        public GroupBoxBuilder WithTabIndex(int value)
        {
            TabIndex = value;
            return this;
        }

        public GroupBoxBuilder WithTabStopValue(bool value)
        {
            TabStop = value;
            return this;
        }

        public GroupBoxBuilder WithText(string value)
        {
            Text = value;
            return this;
        }
    }
}
