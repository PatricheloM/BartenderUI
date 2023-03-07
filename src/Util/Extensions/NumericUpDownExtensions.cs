using System.Drawing;
using System.Windows.Forms;

namespace BartenderUI.Util.Extensions
{
    static class NumericUpDownExtensions
    {

        public static NumericUpDown WithLocation(this NumericUpDown o, int value1, int value2)
        {
            o.Location = new Point(value1, value2);
            return o;
        }

        public static NumericUpDown WithName(this NumericUpDown o, string value)
        {
            o.Name = value;
            return o;
        }

        public static NumericUpDown WithSize(this NumericUpDown o, int value1, int value2)
        {
            o.Size = new Size(value1, value2);
            return o;
        }

        public static NumericUpDown WithValue(this NumericUpDown o, int value)
        {
            o.Value = value;
            return o;
        }
    }
}
