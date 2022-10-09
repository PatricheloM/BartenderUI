using System.Windows.Forms;
using System.Drawing;
using System;

namespace BartenderUI.Util.Builders
{
    class ComboBoxBuilder : ComboBox, IBuilder<ComboBoxBuilder>
    {
        public ComboBoxBuilder()
        {
            GetInstance()
                .WithTabIndex(1);
        }

        public ComboBoxBuilder GetInstance()
        {
            return this;
        }

        public ComboBoxBuilder WithLocation(int value1, int value2)
        {
            Location = new Point(value1, value2);
            return this;
        }

        public ComboBoxBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public ComboBoxBuilder WithSize(int value1, int value2)
        {
            Size = new Size(value1, value2);
            return this;
        }

        public ComboBoxBuilder WithTabIndex(int value)
        {
            TabIndex = value;
            return this;
        }

        public ComboBoxBuilder AddAll(string[] value)
        {
            Items.AddRange(value);
            return this;
        }

        public ComboBoxBuilder AddKeyDownEvent(KeyEventHandler value)
        {
            KeyDown += value;
            return this;
        }

        public ComboBoxBuilder AddSelectedIndexChangedEvent(EventHandler value)
        {
            SelectedIndexChanged += value;
            return this;
        }

        public ComboBoxBuilder WithAutoCompleteSource(string[] values)
        {
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteCustomSource = source;
            source.AddRange(values);
            AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            return this;
        }

        public ComboBoxBuilder WithReadOnlyValue(bool value)
        {
            if (value)
            {
                DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                DropDownStyle = ComboBoxStyle.DropDown;
            }
            return this;
        }

        public ComboBoxBuilder WithDefaultValue(string value)
        {
            Text = value;
            return this;
        }

        public ComboBoxBuilder WithDropDownStyle(ComboBoxStyle value)
        {
            DropDownStyle = value;
            return this;
        }

        public ComboBoxBuilder WithFormattingValue(bool value)
        {
            FormattingEnabled = value;
            return this;
        }

        public ComboBoxBuilder Clear()
        {
            Items.Clear();
            return this;
        }
    }
}
