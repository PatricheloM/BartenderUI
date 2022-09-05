using System.Windows.Forms;

namespace BartenderUI.Util.Builders
{
    class DataGridViewTextBoxColumnBuilder : DataGridViewTextBoxColumn
    {
        public DataGridViewTextBoxColumnBuilder WithHeaderText(string value)
        {
            HeaderText = value;
            return this;
        }

        public DataGridViewTextBoxColumnBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public DataGridViewTextBoxColumnBuilder WithReadOnlyValue(bool value)
        {
            ReadOnly = value;
            return this;
        }

        public DataGridViewTextBoxColumnBuilder WithWidth(int value)
        {
            Width = value;
            return this;
        }
    }
}
