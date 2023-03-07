using BartenderUI.Util.Extensions;
using System.Windows.Forms;

namespace BartenderUI.Util.Factories
{
    class DataGridViewColumnFactory
    {
        public partial class TextBoxColumn
        {
            public static DataGridViewTextBoxColumn Produce(string name, string headerText, bool readOnlyValue, int width)
            {
                return new DataGridViewTextBoxColumn()
                    .WithName(name)
                    .WithHeaderText(headerText)
                    .WithReadOnlyValue(readOnlyValue)
                    .WithWidth(width);
            }

            public static DataGridViewTextBoxColumn Produce(string name, string headerText, bool readOnlyValue)
            {
                return new DataGridViewTextBoxColumn()
                    .WithName(name)
                    .WithHeaderText(headerText)
                    .WithReadOnlyValue(readOnlyValue);
            }
        }

        public partial class ButtonColumn
        { 
            public static DataGridViewButtonColumn Produce(string name, string headerText, int width) 
            {
                return new DataGridViewButtonColumn()
                    .WithName(name)
                    .WithHeaderText(headerText)
                    .WithWidth(width);
            }
        }
    }
}
