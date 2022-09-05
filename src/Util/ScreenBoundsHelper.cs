using System.Windows.Forms;

namespace BartenderUI.Util
{
    class ScreenBoundsHelper
    {
        public static int ScreenWidth()
        {

            int width = Screen.PrimaryScreen.Bounds.Width;
            return width;

        }
        public static int ScreenHeight()
        {

            int height = Screen.PrimaryScreen.Bounds.Height;
            return height;
        }
    }
}
