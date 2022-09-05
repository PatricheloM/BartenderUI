using System;
using System.Windows.Forms;
using BartenderUI.Util.Builders;

namespace BartenderUI.Menu
{
    abstract class AbstractAddItem : FormBuilder
    {
        private ButtonBuilder addButton;
        private ButtonBuilder undoButton;

        private LabelBuilder nameLabel;
        private LabelBuilder priceLabel;

        protected TextBoxBuilder nameBox;
        protected TextBoxBuilder priceBox;

        protected abstract void AddButtonClickEvent(object sender, EventArgs e);
        protected abstract void UndoButtonClickEvent(object sender, EventArgs e);
        protected abstract void BoxKeyUpEvent(object sender, KeyEventArgs e);

        protected void InitializeComponents()
        {
            addButton = new ButtonBuilder()
                .WithLocation(12, 83)
                .WithSize(118, 23)
                .WithName("addButton")
                .WithText("Oké")
                .AddClickEvent(AddButtonClickEvent);

            undoButton = new ButtonBuilder()
                .WithLocation(136, 83)
                .WithSize(75, 23)
                .WithName("undoButton")
                .WithText("Mégsem")
                .AddClickEvent(UndoButtonClickEvent);

            nameLabel = new LabelBuilder()
                .WithLocation(13, 13)
                .WithSize(64, 13)
                .WithName("nameLabel")
                .WithText("Termék név");

            priceLabel = new LabelBuilder()
                .WithLocation(13, 48)
                .WithSize(35, 13)
                .WithName("priceLabel")
                .WithText("Ár (Ft)");

            nameBox = new TextBoxBuilder()
                .WithLocation(83, 10)
                .WithSize(128, 20)
                .WithName("nameBox")
                .AddKeyUpEvent(BoxKeyUpEvent);

            priceBox = new TextBoxBuilder()
                .WithLocation(83, 45)
                .WithSize(128, 20)
                .WithName("priceBox")
                .AddKeyUpEvent(BoxKeyUpEvent);

            GetInstance()
                .WithClientSize(223, 118)
                .WithName("AddItem")
                .WithText("Tétel hozzáadás")
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .AddAll(addButton, undoButton, nameLabel, priceLabel, nameBox, priceBox);
        }
    }
}
