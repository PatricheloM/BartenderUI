using System;
using System.Windows.Forms;
using StackExchange.Redis;
using BartenderUI.Redis;
using System.Collections.Generic;
using System.Drawing;
using BartenderUI.Util.Builders;
using BartenderUI.Util;
using BartenderUI.Util.Factories;
using BartenderUI.Util.Events;

namespace BartenderUI.Payment
{
    class Payment : AbstractPayment
    {
        private Dictionary<string, List<string>> invoiceList = new Dictionary<string, List<string>>();
        private List<LabelBuilder> itemLabels = new List<LabelBuilder>();

        public Payment()
        {
            InitializeComponents();
            RefreshDictionary();
            RefreshInvoicesComboBox();
        }

        protected override void InvoicesSelectedIndexChangedEvent(object sender, EventArgs e)
        {
            if (!(invoices.SelectedItem is null))
            {
                string selected = invoices.SelectedItem.ToString();
                HashEntry[] entries = RedisRepository.HGetAll("szamla_" + selected);
                int lineSpacing = 0;
                foreach (HashEntry entry in entries)
                {
                    // TODO

                    lineSpacing++;
                }

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
                    foreach (var entry in invoiceList)
                    {
                        if (entry.Value.Contains(selected))
                        {
                            RedisRepository.SRem(entry.Key, selected);
                            if (RedisRepository.SMembers(entry.Key).Length == 0)
                            {
                                RedisRepository.HMSet(entry.Key.Replace("szamlak_", "asztal_"), new HashEntry("state", SzabadFoglaltEnum.Szabad.ToString()));
                            }
                        }
                    }
                    RefreshDictionary();
                    RefreshInvoicesComboBox();
                    payButton.WithText("Válasszon számlát!");
                    invoices.SelectedItem = null;
                    RefreshEvent.Invoke();
                }
            }
        }

        private void RefreshDictionary()
        {
            invoiceList.Clear();
            foreach (RedisKey key in RedisRepository.Keys("szamlak_*"))
            {
                List<string> list = new List<string>();
                foreach (string value in RedisRepository.SMembers(key))
                {
                    list.Add(value);
                }
                invoiceList.Add(key, list);
            }
        }

        private void RefreshInvoicesComboBox()
        {
            invoices.Clear();
            List<string> addable = new List<string>();
            foreach (var entry in invoiceList)
            {
                foreach (var invoice in entry.Value)
                {
                    addable.Add(invoice);
                }
            }
            invoices.AddAll(addable.ToArray());
        }
    }
}
