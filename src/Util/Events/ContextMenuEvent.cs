using System.Windows.Forms;
using BartenderUI.Util.Extensions;
using BartenderUI.Util.HelperTypes;

namespace BartenderUI.Util.Events
{
    class ContextMenuEvent
    {
        public static void MouseDownEvent(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenu contextMenu = new ContextMenu()
                    .AddAll(new ContextMenuEntry("Asztal törlése", HideEvents.CallForTableContextMenuEvent));

                control.ContextMenu = contextMenu;
            }
        }
    }
}
