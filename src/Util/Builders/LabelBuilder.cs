using System;
using System.Windows.Forms;
using System.Drawing;
using BartenderUI.Util.Factories;

namespace BartenderUI.Util.Builders
{
    class LabelBuilder : Label, IBuilder<LabelBuilder>
    {
        public LabelBuilder()
        {
            GetInstance()
                .WithTabIndex(1)
                .WithAutoSizeValue(true)
                .WithBackColor(Color.Transparent);
        }

        public LabelBuilder GetInstance()
        {
            return this;
        }

        public LabelBuilder WithFont(string value1, float value2)
        {
            Font = new Font(value1, value2);
            return this;
        }

        public LabelBuilder WithFont(string value1, float value2, FontStyle value3)
        {
            Font = new Font(value1, value2, value3);
            return this;
        }

        public LabelBuilder WithLocation(int value1, int value2)
        {
            Location = new Point(value1, value2);
            return this;
        }

        public LabelBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public LabelBuilder WithSize(int value1, int value2)
        {
            Size = new Size(value1, value2);
            return this;
        }

        public LabelBuilder WithTabIndex(int value)
        {
            TabIndex = value;
            return this;
        }

        public LabelBuilder WithText(string value)
        {
            Text = value;
            return this;
        }

        public LabelBuilder AddClickEvent(EventHandler value)
        {
            Click += value;
            return this;
        }

        public LabelBuilder WithAutoSizeValue(bool value)
        {
            AutoSize = value;
            return this;
        }

        public LabelBuilder WithBackColor(Color value)
        {
            BackColor = value;
            return this;
        }

        public LabelBuilder WithForeColor(Color value)
        {
            ForeColor = value;
            return this;
        }

        public LabelBuilder WithFlashing(int value, params Color[] values)
        {
            int colors = values.Length;
            int counter = 0;

            TimerBuilder timer = TimerFactory.Produce(value, (sender, e) =>
            {
                if (colors - counter == 1) counter = 0;
                else counter++;

                GetInstance()
                    .WithForeColor(values[counter]);
            });

            return this;
        }

        public LabelBuilder WithHiddenValue(bool value)
        {
            switch (value)
            {
                case true:
                    Hide();
                    break;
                case false:
                    Show();
                    break;
            }
            return this;
        }
    }
}
