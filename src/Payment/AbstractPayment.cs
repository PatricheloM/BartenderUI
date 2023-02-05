using System;
using System.Windows.Forms;
using System.Drawing;
using BartenderUI.Util.Builders;
using BartenderUI.Util.Factories;

namespace BartenderUI.Payment
{
    abstract class AbstractPayment : FormBuilder
    {
        private LabelBuilder infoLabel;

        protected ComboBoxBuilder invoices;

        protected ButtonBuilder payButton;

        protected DataGridViewBuilder dataGridView;
        private DataGridViewTextBoxColumnBuilder itemColumn;
        private DataGridViewTextBoxColumnBuilder quantityColumn;
        private DataGridViewTextBoxColumnBuilder priceColumn;

        protected abstract void PayButtonClickEvent(object sender, EventArgs e);
        protected abstract void InvoicesSelectedIndexChangedEvent(object sender, EventArgs e);

        protected void InitializeComponents()
        {
            itemColumn = DataGridViewColumnFactory.Produce("itemColumn", "Tétel", true, 230);
            quantityColumn = DataGridViewColumnFactory.Produce("quantityColumn", "Darabszám", true, 71);
            priceColumn = DataGridViewColumnFactory.Produce("priceColumn", "Ár", true, 135);

            dataGridView = new DataGridViewBuilder()
                .WithAllowUserToResizeColumnsValue(false)
                .WithAllowUserToResizeRowsValue(false)
                .WithRowHeadersVisibleValue(false)
                .WithAllowUserToAddRowsValue(false)
                .WithColumnHeadersHeightSizeMode(DataGridViewColumnHeadersHeightSizeMode.AutoSize)
                .WithLocation(21, 54)
                .WithName("dataGridView")
                .WithScrollBars(ScrollBars.Vertical)
                .WithSize(441, 366)
                .AddColumns(itemColumn, quantityColumn, priceColumn);

            infoLabel = new LabelBuilder()
                .WithAutoSizeValue(true)
                .WithLocation(12, 16)
                .WithFont("Microsoft Sans Serif", 9F, FontStyle.Bold)
                .WithName("infoLabel")
                .WithSize(63, 15)
                .WithText("Számla: ");

            payButton = new ButtonBuilder()
                .WithFont("Microsoft Sans Serif", 12F, FontStyle.Bold)
                .WithLocation(15, 432)
                .WithName("payButton")
                .WithSize(453, 36)
                .WithText("Válasszon számlát!")
                .AddClickEvent(PayButtonClickEvent);

            invoices = new ComboBoxBuilder()
                .WithDropDownStyle(ComboBoxStyle.DropDownList)
                .WithName("invoices")
                .WithSize(387, 21)
                .WithLocation(81, 13)
                .AddSelectedIndexChangedEvent(InvoicesSelectedIndexChangedEvent);

            GetInstance()
                .WithClientSize(480, 480)
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .WithName("Payment")
                .WithShowIconValue(false)
                .WithShowInTaskbarValue(false)
                .WithText("Számla kifizetése")
                .AddAll(dataGridView, infoLabel, payButton, invoices);
        }
    }
}
