using BartenderUI.Util.Builders;

namespace BartenderUI.Util.Factories
{
    class DataGridViewColumnFactory
    {
        public static DataGridViewTextBoxColumnBuilder Produce(string name, string headerText, bool readOnlyValue, int width)
        {
            return new DataGridViewTextBoxColumnBuilder()
                .WithName(name)
                .WithHeaderText(headerText)
                .WithReadOnlyValue(readOnlyValue)
                .WithWidth(width);
        }

        public static DataGridViewTextBoxColumnBuilder Produce(string name, string headerText, bool readOnlyValue)
        {
            return new DataGridViewTextBoxColumnBuilder()
                .WithName(name)
                .WithHeaderText(headerText)
                .WithReadOnlyValue(readOnlyValue);
        }
    }
}
