using System.Windows.Forms;
using BartenderUI.Util.HelperTypes;

namespace BartenderUI.Util.Extensions
{
    static class ContextMenuExtensions
    {
        public static ContextMenu AddAll(this ContextMenu o, params ContextMenuEntry[] values)
        {
            foreach (ContextMenuEntry entry in values)
            {
                o.MenuItems.Add(entry.Caption, entry.OnClickEvent);
            }

            return o;
        }
    }
}
