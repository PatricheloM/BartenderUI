using System.Windows.Forms;

namespace BartenderUI.Util.Builders
{
    interface IBuilder<T>
    {
        T GetInstance();
        T WithName(string value);
        T WithSize(int value1, int value2);
        T WithLocation(int value1, int value2);
    }
}
