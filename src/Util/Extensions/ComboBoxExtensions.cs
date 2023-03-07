using System.Windows.Forms;
using System.Drawing;
using System;

namespace BartenderUI.Util.Extensions
{
    static class ComboBoxExtensions
    {

        public static ComboBox WithLocation(this ComboBox o, int value1, int value2)
        {
            o.Location = new Point(value1, value2);
            return o;
        }

        public static ComboBox WithName(this ComboBox o, string value)
        {
            o.Name = value;
            return o;
        }

        public static ComboBox WithSize(this ComboBox o, int value1, int value2)
        {
            o.Size = new Size(value1, value2);
            return o;
        }

        public static ComboBox WithTabIndex(this ComboBox o, int value)
        {
            o.TabIndex = value;
            return o;
        }

        public static ComboBox AddAll(this ComboBox o, string[] value)
        {
            o.Items.AddRange(value);
            return o;
        }

        public static ComboBox AddKeyDownEvent(this ComboBox o, KeyEventHandler value)
        {
            o.KeyDown += value;
            return o;
        }

        public static ComboBox AddSelectedIndexChangedEvent(this ComboBox o, EventHandler value)
        {
            o.SelectedIndexChanged += value;
            return o;
        }

        public static ComboBox WithAutoCompleteSource(this ComboBox o, string[] values)
        {
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            o.AutoCompleteSource = AutoCompleteSource.CustomSource;
            o.AutoCompleteCustomSource = source;
            source.AddRange(values);
            o.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            return o;
        }

        public static ComboBox WithReadOnlyValue(this ComboBox o, bool value)
        {
            if (value)
            {
                o.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                o.DropDownStyle = ComboBoxStyle.DropDown;
            }
            return o;
        }

        public static ComboBox WithDefaultValue(this ComboBox o, string value)
        {
            o.Text = value;
            return o;
        }

        public static ComboBox WithDropDownStyle(this ComboBox o, ComboBoxStyle value)
        {
            o.DropDownStyle = value;
            return o;
        }

        public static ComboBox WithFormattingValue(this ComboBox o, bool value)
        {
            o.FormattingEnabled = value;
            return o;
        }

        public static ComboBox Clear(this ComboBox o)
        {
            o.Items.Clear();
            return o;
        }
    }
}
