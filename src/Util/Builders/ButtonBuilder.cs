using System;
using System.Windows.Forms;
using System.Drawing;

namespace BartenderUI.Util.Builders
{
    class ButtonBuilder : Button
    {
        public ButtonBuilder()
        {
            GetInstance()
                .WithVisualStyleBackColorValue(true)
                .WithTabIndex(1);
        }

        public ButtonBuilder GetInstance()
        {
            return this;
        }

        public ButtonBuilder WithFont(string value1, float value2)
        {
            Font = new Font(value1, value2);
            return this;
        }

        public ButtonBuilder WithFont(string value1, float value2, FontStyle value3)
        {
            Font = new Font(value1, value2, value3);
            return this;
        }

        public ButtonBuilder WithLocation(int value1, int value2)
        {
            Location = new Point(value1, value2);
            return this;
        }

        public ButtonBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public ButtonBuilder WithSize(int value1, int value2)
        {
            Size = new Size(value1, value2);
            return this;
        }

        public ButtonBuilder WithTabIndex(int value)
        {
            TabIndex = value;
            return this;
        }

        public ButtonBuilder WithText(string value)
        {
            Text = value;
            return this;
        }

        public ButtonBuilder WithVisualStyleBackColorValue(bool value)
        {
            UseVisualStyleBackColor = value;
            return this;
        }

        public ButtonBuilder AddClickEvent(EventHandler value)
        {
            Click += value;
            return this;
        }
    }
}
