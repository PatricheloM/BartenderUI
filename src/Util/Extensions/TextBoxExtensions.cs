using System.Windows.Forms;
using System.Drawing;

namespace BartenderUI.Util.Extensions
{
    static class TextBoxExtensions
    {

        public static TextBox WithTabIndex(this TextBox o, int value)
        {
            o.TabIndex = value;
            return o;
        }

        public static TextBox WithLocation(this TextBox o, int value1, int value2)
        {
            o.Location = new Point(value1, value2);
            return o;
        }

        public static TextBox WithSize(this TextBox o, int value1, int value2)
        {
            o.Size = new Size(value1, value2);
            return o;
        }

        public static TextBox WithName(this TextBox o, string value)
        {
            o.Name = value;
            return o;
        }

        public static TextBox WithText(this TextBox o, string value)
        {
            o.Text = value;
            return o;
        }

        public static TextBox WithAutoCompleteSource(this TextBox o, string[] values)
        {
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            o.AutoCompleteSource = AutoCompleteSource.CustomSource;
            o.AutoCompleteCustomSource = source;
            source.AddRange(values);
            o.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            return o;
        }

        public static TextBox AddKeyDownEvent(this TextBox o, KeyEventHandler value)
        {
            o.KeyDown += value;
            return o;
        }

        public static TextBox AddKeyPressEvent(this TextBox o, KeyPressEventHandler value)
        {
            o.KeyPress += value;
            return o;
        }
    }
}
