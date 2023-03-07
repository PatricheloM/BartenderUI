using System.Windows.Forms;

namespace BartenderUI.Util.Extensions
{
    static class DataGridViewButtonColumnExtensions
    {
        public static DataGridViewButtonColumn WithHeaderText(this DataGridViewButtonColumn o, string value)
        {
            o.HeaderText = value;
            return o;
        }

        public static DataGridViewButtonColumn WithName(this DataGridViewButtonColumn o, string value)
        {
            o.Name = value;
            return o;
        }

        public static DataGridViewButtonColumn WithWidth(this DataGridViewButtonColumn o, int value)
        {
            o.Width = value;
            return o;
        }
    }
}
