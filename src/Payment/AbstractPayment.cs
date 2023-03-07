using System;
using System.Windows.Forms;
using System.Drawing;
using BartenderUI.Util.Extensions;
using BartenderUI.Util.Factories;

namespace BartenderUI.Payment
{
    abstract class AbstractPayment : Form
    {
        private Label infoLabel;

        protected ComboBox invoices;

        protected Button payButton;

        protected DataGridView dataGridView;
        private DataGridViewTextBoxColumn itemColumn;
        private DataGridViewTextBoxColumn quantityColumn;
        private DataGridViewTextBoxColumn priceColumn;

        protected abstract void PayButtonClickEvent(object sender, EventArgs e);
        protected abstract void InvoicesSelectedIndexChangedEvent(object sender, EventArgs e);

        protected void InitializeComponents()
        {
            itemColumn = DataGridViewColumnFactory.TextBoxColumn.Produce("itemColumn", "Tétel", true, 230);
            quantityColumn = DataGridViewColumnFactory.TextBoxColumn.Produce("quantityColumn", "Darabszám", true, 71);
            priceColumn = DataGridViewColumnFactory.TextBoxColumn.Produce("priceColumn", "Ár", true, 135);

            dataGridView = new DataGridView()
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

            infoLabel = new Label()
                .WithAutoSizeValue(true)
                .WithLocation(12, 16)
                .WithFont("Microsoft Sans Serif", 9F, FontStyle.Bold)
                .WithName("infoLabel")
                .WithSize(63, 15)
                .WithText("Számla: ");

            payButton = new Button()
                .WithFont("Microsoft Sans Serif", 12F, FontStyle.Bold)
                .WithLocation(15, 432)
                .WithName("payButton")
                .WithSize(453, 36)
                .WithText("Válasszon számlát!")
                .AddClickEvent(PayButtonClickEvent);

            invoices = new ComboBox()
                .WithDropDownStyle(ComboBoxStyle.DropDownList)
                .WithName("invoices")
                .WithSize(387, 21)
                .WithLocation(81, 13)
                .AddSelectedIndexChangedEvent(InvoicesSelectedIndexChangedEvent);

            this
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
