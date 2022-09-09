using System;
using System.Windows.Forms;
using BartenderUI.Util.Builders;

namespace BartenderUI.Util.Events
{
    class ClearTableEvent
    {
        public static void ClearTableEventForTableContextMenu(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            PictureBoxBuilder table = menuItem.GetContextMenu().SourceControl as PictureBoxBuilder;
            InvoiceDeleteHelper.DeleteInvoices(table.Id);
        }
    }
}
