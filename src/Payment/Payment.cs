using System;
using System.Windows.Forms;
using StackExchange.Redis;
using BartenderUI.Redis;
using System.Collections.Generic;
using BartenderUI.Util;
using BartenderUI.Util.Factories;
using BartenderUI.Util.Events;
using System.Linq;

namespace BartenderUI.Payment
{
    class Payment : AbstractPayment
    {
        private List<string> invoiceList = new List<string>();

        public Payment()
        {
            InitializeComponents();
            RefreshInvoicesComboBox();
        }

        protected override void InvoicesSelectedIndexChangedEvent(object sender, EventArgs e)
        {
            if (!(invoices.SelectedItem is null))
            {
                string selected = invoices.SelectedItem.ToString();
                GridFiller.FillGrid(dataGridView, selected);

                payButton.WithText("Kifizetve: " + PriceCalculator.CalculateFullInvoice(selected) + " Ft");
            }
        }

        protected override void PayButtonClickEvent(object sender, EventArgs e)
        {
            if (!(invoices.SelectedItem is null))
            {
                if (MessageBoxFactory.Produce(MessageBoxFactory.GetPaidWarningText(), MessageBoxFactory.GetPaidWarningTitle(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string selected = invoices.SelectedItem.ToString();
                    RedisRepository.Del("szamla_" + selected);
                    invoiceList.ForEach(sz => {
                        RedisRepository.Keys("szamlak_*").ToList().ForEach(sc => {
                            RedisRepository.SRem(sc, selected);
                            if (RedisRepository.SMembers(sc).Length == 0)
                                RedisRepository.HMSet(sc.ToString().Replace("szamlak_", "asztal_"), new HashEntry("state", SzabadFoglaltEnum.Szabad.ToString()));
                        });
                    });
                    RefreshInvoicesComboBox();
                    payButton.WithText("Válasszon számlát!");
                    invoices.SelectedItem = null;
                    RefreshEvent.Invoke();
                }
            }
        }


        private void RefreshInvoicesComboBox()
        {
            invoiceList.Clear();
            invoices.Clear();
            invoiceList = RedisRepository.Keys("szamla_*").ToList().Select(s => s.ToString().Replace("szamla_", "")).ToList();
            invoices.AddAll(invoiceList.ToArray());
        }
    }
}
