using System;
using System.Windows.Forms;
using System.Drawing;

namespace BartenderUI.Util.Builders
{
    class PanelBuilder : Panel, IBuilder<PanelBuilder>
    {
        public PanelBuilder()
        {
            GetInstance()
                .WithTabIndex(1);
        }

        public PanelBuilder GetInstance()
        {
            return this;
        }

        public PanelBuilder WithLocation(int value1, int value2)
        {
            Location = new Point(value1, value2);
            return this;
        }

        public PanelBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public PanelBuilder WithSize(int value1, int value2)
        {
            Size = new Size(value1, value2);
            return this;
        }

        public PanelBuilder WithTabIndex(int value)
        {
            TabIndex = value;
            return this;
        }

        public PanelBuilder WithAutoScrollValue(bool value)
        {
            AutoScroll = true;
            return this;
        }

        public PanelBuilder AddAll(params Control[] values)
        {
            foreach (Control value in values)
            {
                Controls.Add(value);
            }
            return this;
        }
    }
}
