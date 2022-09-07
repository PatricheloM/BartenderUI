using System.Drawing;
using System.Windows.Forms;
namespace BartenderUI.Util.Builders
{
    class DataGridViewBuilder : DataGridView, IBuilder<DataGridViewBuilder>
    {
        public DataGridViewBuilder()
        {
            GetInstance()
                .WithTabIndex(0);
        }

        public DataGridViewBuilder GetInstance()
        {
            return this;
        }

        public DataGridViewBuilder AddColumns(params DataGridViewColumn[] values)
        {
            Columns.AddRange(values);
            return this;
        }

        public DataGridViewBuilder WithLocation(int value1, int value2)
        {
            Location = new Point(value1, value2);
            return this;
        }

        public DataGridViewBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public DataGridViewBuilder WithReadOnlyValue(bool value)
        {
            ReadOnly = value;
            return this;
        }

        public DataGridViewBuilder WithScrollBars(ScrollBars value)
        {
            ScrollBars = value;
            return this;
        }

        public DataGridViewBuilder WithTabIndex(int value)
        {
            TabIndex = value;
            return this;
        }

        public DataGridViewBuilder WithSize(int value1, int value2)
        {
            Size = new Size(value1, value2);
            return this;
        }

        public DataGridViewBuilder WithShowEditingIconValue(bool value)
        {
            ShowEditingIcon = value;
            return this;
        }

        public DataGridViewBuilder WithAllowUserToResizeRowsValue(bool value)
        {
            AllowUserToResizeRows = value;
            return this;
        }

        public DataGridViewBuilder WithColumnHeadersHeightSizeMode(DataGridViewColumnHeadersHeightSizeMode value)
        {
            ColumnHeadersHeightSizeMode = value;
            return this;
        }

        public DataGridViewBuilder WithAllowUserToAddRowsValue(bool value)
        {
            AllowUserToAddRows = value;
            return this;
        }

        public DataGridViewBuilder WithAllowUserToResizeColumnsValue(bool value)
        {
            AllowUserToResizeColumns = value;
            return this;
        }

        public DataGridViewBuilder WithRowHeadersVisibleValue(bool value)
        {
            RowHeadersVisible = value;
            return this;
        }

        public DataGridViewBuilder AddUserDeletingRowEvent(DataGridViewRowCancelEventHandler value)
        {
            UserDeletingRow += value;
            return this;
        }

        public DataGridViewBuilder AddCellEndEditEvent(DataGridViewCellEventHandler value)
        {
            CellEndEdit += value;
            return this;
        }

        public DataGridViewBuilder AddEditingControlShowingEvent(DataGridViewEditingControlShowingEventHandler value)
        {
            EditingControlShowing += value;
            return this;
        }
    }
}
