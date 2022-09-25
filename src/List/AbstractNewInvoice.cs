using System;
using System.Windows.Forms;
using BartenderUI.Util.Builders;

namespace BartenderUI.List
{
    abstract class AbstractNewInvoice : FormBuilder
    {
        private ButtonBuilder addButton;
        private ButtonBuilder undoButton;

        private LabelBuilder infoLabel;

        protected TextBoxBuilder invoiceBox;

        protected abstract void AddButtonClickEvent(object sender, EventArgs e);
        protected abstract void UndoButtonClickEvent(object sender, EventArgs e);
        protected abstract void BoxKeyDownEvent(object sender, KeyEventArgs e);

        protected void InitializeComponents()
        {

            addButton = new ButtonBuilder()
                .WithLocation(12, 58)
                .WithSize(118, 23)
                .WithName("addButton")
                .WithText("Oké")
                .AddClickEvent(AddButtonClickEvent);

            undoButton = new ButtonBuilder()
                .WithLocation(136, 58)
                .WithSize(75, 23)
                .WithName("undoButton")
                .WithText("Mégsem")
                .AddClickEvent(UndoButtonClickEvent);

            invoiceBox = new TextBoxBuilder()
                .WithLocation(12, 25)
                .WithSize(198, 20)
                .WithName("invoiceBox")
                .AddKeyDownEvent(BoxKeyDownEvent);

            infoLabel = new LabelBuilder()
                .WithLocation(12, 5)
                .WithSize(64, 13)
                .WithName("infoLabel")
                .WithText("Számla:");

            GetInstance()
                .WithClientSize(223, 88)
                .WithName("NewInvoice")
                .WithText("Új számla")
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .AddAll(addButton, undoButton, infoLabel, invoiceBox);
        }
    }
}
