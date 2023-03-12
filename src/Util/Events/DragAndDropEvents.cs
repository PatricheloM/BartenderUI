using System.Windows.Forms;
using BartenderUI.Redis;
using StackExchange.Redis;
using BartenderUI.Util.HelperTypes;

namespace BartenderUI.Util.Events
{
    class DragAndDropEvents
    {
        private static bool grabbed;
        private static int deltaX;
        private static int deltaY;

        public static void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                deltaX = e.X;
                deltaY = e.Y;
                grabbed = true;
            }
        }

        public static void MouseMoveBelsoEvent(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            int newX = control.Left + (e.X - deltaX);
            int newY = control.Top + (e.Y - deltaY);

            if (grabbed)
            {
                if (newX > 0 && newX < (ScreenBoundsHelper.ScreenWidth() / 3 * 2) - 110 && newY > 0 && newY < ScreenBoundsHelper.ScreenHeight() - 180)
                {
                    control.Left = newX;
                    control.Top = newY;
                }
            }
        }

        public static void MouseMoveKulsoEvent(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            int newX = control.Left + (e.X - deltaX);
            int newY = control.Top + (e.Y - deltaY);

            if (grabbed)
            {
                if (newX > 0 && newX < ScreenBoundsHelper.ScreenWidth() / 3 - 110 && newY > 0 && newY < ScreenBoundsHelper.ScreenHeight() - 180)
                {
                    control.Left = newX;
                    control.Top = newY;
                }
            }
        }

        public static void MouseUpEventGeneric(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        public static void MouseUpEventForTable(object sender, MouseEventArgs e)
        {
            Table table = sender as Table;
            RedisRepository.HMSet("asztal_" + table.Id,
                new HashEntry("X", table.Location.X),
                new HashEntry("Y", table.Location.Y));

            MouseUpEventGeneric(sender, e);
        }
    }
}
