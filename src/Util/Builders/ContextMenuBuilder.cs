using System.Windows.Forms;
using BartenderUI.Util.HelperTypes;

namespace BartenderUI.Util.Builders
{
    class ContextMenuBuilder : ContextMenu
    {
        public ContextMenuBuilder AddAll(params ContextMenuEntry[] values)
        {
            foreach (ContextMenuEntry entry in values)
            {
                MenuItems.Add(entry.Caption, entry.OnClickEvent);
            }

            return this;
        }
    }
}
