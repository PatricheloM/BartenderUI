using System;

namespace BartenderUI.Util.HelperTypes
{
    class NewOrder
    {
        public string Item { get; private set; }
        public string Quantity { get; private set; }
        public string Table { get; private set; }
        public string Invoice { get; private set; }

        public NewOrder(string item, string quantity, string table, string invoice)
        {
            Item = item;
            Quantity = quantity;
            Table = table;
            Invoice = invoice;
        }
    }
}
