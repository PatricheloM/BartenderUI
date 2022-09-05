using System;

namespace BartenderUI.Util.HelperTypes
{
    class ContextMenuEntry
    {
        public string Caption { get; private set; }
        public EventHandler OnClickEvent { get; private set; }

        public ContextMenuEntry(string caption, EventHandler onClickEvent)
        {
            Caption = caption;
            OnClickEvent = onClickEvent;
        }
    }
}
