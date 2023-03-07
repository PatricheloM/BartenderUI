using System;
using System.Windows.Forms;
using BartenderUI.Util.Extensions;

namespace BartenderUI.List
{
    abstract class AbstractNewInvoice : Form
    {
        private Button addButton;
        private Button undoButton;

        private Label infoLabel;

        protected TextBox invoiceBox;

        protected abstract void AddButtonClickEvent(object sender, EventArgs e);
        protected abstract void UndoButtonClickEvent(object sender, EventArgs e);
        protected abstract void BoxKeyDownEvent(object sender, KeyEventArgs e);

        protected void InitializeComponents()
        {

            addButton = new Button()
                .WithLocation(12, 58)
                .WithSize(118, 23)
                .WithName("addButton")
                .WithText("Oké")
                .AddClickEvent(AddButtonClickEvent);

            undoButton = new Button()
                .WithLocation(136, 58)
                .WithSize(75, 23)
                .WithName("undoButton")
                .WithText("Mégsem")
                .AddClickEvent(UndoButtonClickEvent);

            invoiceBox = new TextBox()
                .WithLocation(12, 25)
                .WithSize(198, 20)
                .WithName("invoiceBox")
                .AddKeyDownEvent(BoxKeyDownEvent);

            infoLabel = new Label()
                .WithLocation(12, 5)
                .WithSize(64, 13)
                .WithName("infoLabel")
                .WithText("Számla:");

            this
                .WithClientSize(223, 88)
                .WithName("NewInvoice")
                .WithText("Új számla")
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .AddAll(addButton, undoButton, infoLabel, invoiceBox);
        }
    }
}
