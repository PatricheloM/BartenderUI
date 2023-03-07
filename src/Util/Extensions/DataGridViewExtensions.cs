using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Windows.Forms;
namespace BartenderUI.Util.Extensions
{
    static class DataGridViewExtensions
    {

        public static DataGridView AddColumns(this DataGridView o, params DataGridViewColumn[] values)
        {
            o.Columns.AddRange(values);
            return o;
        }

        public static DataGridView WithLocation(this DataGridView o, int value1, int value2)
        {
            o.Location = new Point(value1, value2);
            return o;
        }

        public static DataGridView WithName(this DataGridView o, string value)
        {
            o.Name = value;
            return o;
        }

        public static DataGridView WithReadOnlyValue(this DataGridView o, bool value)
        {
            o.ReadOnly = value;
            return o;
        }

        public static DataGridView WithScrollBars(this DataGridView o, ScrollBars value)
        {
            o.ScrollBars = value;
            return o;
        }

        public static DataGridView WithTabIndex(this DataGridView o, int value)
        {
            o.TabIndex = value;
            return o;
        }

        public static DataGridView WithSize(this DataGridView o, int value1, int value2)
        {
            o.Size = new Size(value1, value2);
            return o;
        }

        public static DataGridView WithShowEditingIconValue(this DataGridView o, bool value)
        {
            o.ShowEditingIcon = value;
            return o;
        }

        public static DataGridView WithAllowUserToResizeRowsValue(this DataGridView o, bool value)
        {
            o.AllowUserToResizeRows = value;
            return o;
        }

        public static DataGridView WithColumnHeadersHeightSizeMode(this DataGridView o, DataGridViewColumnHeadersHeightSizeMode value)
        {
            o.ColumnHeadersHeightSizeMode = value;
            return o;
        }

        public static DataGridView WithAllowUserToAddRowsValue(this DataGridView o, bool value)
        {
            o.AllowUserToAddRows = value;
            return o;
        }

        public static DataGridView WithAllowUserToResizeColumnsValue(this DataGridView o, bool value)
        {
            o.AllowUserToResizeColumns = value;
            return o;
        }

        public static DataGridView WithRowHeadersVisibleValue(this DataGridView o, bool value)
        {
            o.RowHeadersVisible = value;
            return o;
        }

        public static DataGridView AddUserDeletingRowEvent(this DataGridView o, DataGridViewRowCancelEventHandler value)
        {
            o.UserDeletingRow += value;
            return o;
        }

        public static DataGridView AddCellEndEditEvent(this DataGridView o, DataGridViewCellEventHandler value)
        {
            o.CellEndEdit += value;
            return o;
        }

        public static DataGridView AddEditingControlShowingEvent(this DataGridView o, DataGridViewEditingControlShowingEventHandler value)
        {
            o.EditingControlShowing += value;
            return o;
        }
    }
}
