using System.Windows.Forms;
using BartenderUI.Util.Builders;
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
                ContextMenuBuilder contextMenuBuilder = new ContextMenuBuilder()
                    .AddAll(new ContextMenuEntry("Asztal törlése", HideEvents.CallForTableContextMenuEvent), new ContextMenuEntry("Asztal ürítése", ClearTableEvent.ClearTableEventForTableContextMenu));

                control.ContextMenu = contextMenuBuilder;
            }
        }
    }
}
