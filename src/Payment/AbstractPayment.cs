using System;
using System.Windows.Forms;
using System.Drawing;
using BartenderUI.Util.Builders;

namespace BartenderUI.Payment
{
    abstract class AbstractPayment : FormBuilder
    {
        private LabelBuilder infoLabel;

        protected ComboBoxBuilder invoices;

        protected ButtonBuilder payButton;

        protected PanelBuilder panel;

        private GroupBoxBuilder groupBox;

        protected abstract void PayButtonClickEvent(object sender, EventArgs e);
        protected abstract void InvoicesSelectedIndexChangedEvent(object sender, EventArgs e);

        protected void InitializeComponents()
        {
            panel = new PanelBuilder()
                .WithLocation(21, 54)
                .WithName("panel")
                .WithSize(441, 366)
                .WithAutoScrollValue(true);

            groupBox = new GroupBoxBuilder()
                .WithLocation(15, 35)
                .WithName("groupBox")
                .WithSize(453, 391)
                .WithTabStopValue(false)
                .WithText("Tételek:");

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
                .AddAll(groupBox, panel, infoLabel, payButton, invoices);
        }
    }
}
