using System;
using System.Windows.Forms;

namespace BartenderUI.Payment
{
    class Payment : AbstractPayment
    {
        public Payment()
        {
            InitializeComponents();
        }

        protected override void InvoicesSelectedIndexChangedEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void PayButtonClickEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
