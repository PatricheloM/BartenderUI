using System.Windows.Forms;

namespace BartenderUI.Util
{
    class ScreenBoundsHelper
    {
        public static int ScreenWidth()
        {
            return Screen.PrimaryScreen.Bounds.Width;
        }
        public static int ScreenHeight()
        {
            return Screen.PrimaryScreen.Bounds.Height;
        }
    }
}
