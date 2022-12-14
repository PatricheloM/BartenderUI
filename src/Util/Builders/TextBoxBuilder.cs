using System.Windows.Forms;
using System.Drawing;

namespace BartenderUI.Util.Builders
{
    class TextBoxBuilder : TextBox, IBuilder<TextBoxBuilder>
    {
        public TextBoxBuilder()
        {
            GetInstance()
                .WithTabIndex(0);
        }

        public TextBoxBuilder GetInstance()
        {
            return this;
        }

        public TextBoxBuilder WithTabIndex(int value)
        {
            TabIndex = value;
            return this;
        }

        public TextBoxBuilder WithLocation(int value1, int value2)
        {
            Location = new Point(value1, value2);
            return this;
        }

        public TextBoxBuilder WithSize(int value1, int value2)
        {
            Size = new Size(value1, value2);
            return this;
        }

        public TextBoxBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public TextBoxBuilder WithText(string value)
        {
            Text = value;
            return this;
        }

        public TextBoxBuilder WithAutoCompleteSource(string[] values)
        {
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteCustomSource = source;
            source.AddRange(values);
            AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            return this;
        }

        public TextBoxBuilder AddKeyDownEvent(KeyEventHandler value)
        {
            KeyDown += value;
            return this;
        }

        public TextBoxBuilder AddKeyPressEvent(KeyPressEventHandler value)
        {
            KeyPress += value;
            return this;
        }
    }
}
