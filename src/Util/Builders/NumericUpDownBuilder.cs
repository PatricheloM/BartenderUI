using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BartenderUI.Util.Builders
{
    class NumericUpDownBuilder : NumericUpDown, IBuilder<NumericUpDownBuilder>
    {
        public NumericUpDownBuilder GetInstance()
        {
            return this;
        }

        public NumericUpDownBuilder WithLocation(int value1, int value2)
        {
            Location = new Point(value1, value2);
            return this;
        }

        public NumericUpDownBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public NumericUpDownBuilder WithSize(int value1, int value2)
        {
            Size = new Size(value1, value2);
            return this;
        }

        public NumericUpDownBuilder WithValue(int value)
        {
            Value = value;
            return this;
        }
    }
}
