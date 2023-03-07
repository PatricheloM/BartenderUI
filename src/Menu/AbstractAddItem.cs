using System;
using System.Windows.Forms;
using BartenderUI.Util.Extensions;

namespace BartenderUI.Menu
{
    abstract class AbstractAddItem : Form
    {
        private Button addButton;
        private Button undoButton;

        private Label nameLabel;
        private Label priceLabel;

        protected TextBox nameBox;
        protected TextBox priceBox;

        protected abstract void AddButtonClickEvent(object sender, EventArgs e);
        protected abstract void UndoButtonClickEvent(object sender, EventArgs e);
        protected abstract void BoxKeyDownEvent(object sender, KeyEventArgs e);
        protected abstract void PriceBoxKeyPressEvent(object sender, KeyPressEventArgs e);

        protected void InitializeComponents()
        {
            addButton = new Button()
                .WithLocation(12, 83)
                .WithSize(118, 23)
                .WithName("addButton")
                .WithText("Oké")
                .AddClickEvent(AddButtonClickEvent);

            undoButton = new Button()
                .WithLocation(136, 83)
                .WithSize(75, 23)
                .WithName("undoButton")
                .WithText("Mégsem")
                .AddClickEvent(UndoButtonClickEvent);

            nameLabel = new Label()
                .WithLocation(13, 13)
                .WithSize(64, 13)
                .WithName("nameLabel")
                .WithText("Termék név");

            priceLabel = new Label()
                .WithLocation(13, 48)
                .WithSize(35, 13)
                .WithName("priceLabel")
                .WithText("Ár (Ft)");

            nameBox = new TextBox()
                .WithLocation(83, 10)
                .WithSize(128, 20)
                .WithName("nameBox");

            priceBox = new TextBox()
                .WithLocation(83, 45)
                .WithSize(128, 20)
                .WithName("priceBox")
                .AddKeyDownEvent(BoxKeyDownEvent)
                .AddKeyPressEvent(PriceBoxKeyPressEvent);

            this
                .WithClientSize(223, 118)
                .WithName("AddItem")
                .WithText("Tétel hozzáadás")
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .AddAll(addButton, undoButton, nameLabel, priceLabel, nameBox, priceBox);
        }
    }
}
