using System.Windows.Forms;

namespace BartenderUI.Util.Extensions
{
    static class DataGridViewTextBoxColumnExtensions
    {
        public static DataGridViewTextBoxColumn WithHeaderText(this DataGridViewTextBoxColumn o, string value)
        {
            o.HeaderText = value;
            return o;
        }

        public static DataGridViewTextBoxColumn WithName(this DataGridViewTextBoxColumn o, string value)
        {
            o.Name = value;
            return o;
        }

        public static DataGridViewTextBoxColumn WithReadOnlyValue(this DataGridViewTextBoxColumn o, bool value)
        {
            o.ReadOnly = value;
            return o;
        }

        public static DataGridViewTextBoxColumn WithWidth(this DataGridViewTextBoxColumn o, int value)
        {
            o.Width = value;
            return o;
        }
    }
}
