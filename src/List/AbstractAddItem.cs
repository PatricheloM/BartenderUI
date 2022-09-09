using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BartenderUI.Redis;
using BartenderUI.Util.Builders;
using StackExchange.Redis;

namespace BartenderUI.List
{
    abstract class AbstractAddItem : FormBuilder
    {
        private ButtonBuilder addButton;
        private ButtonBuilder undoButton;

        private LabelBuilder nameLabel;
        private LabelBuilder quantityLabel;
        private LabelBuilder invoiceLabel;

        protected TextBoxBuilder nameBox;
        protected NumericUpDownBuilder quantityBox;
        protected TextBoxBuilder invoiceBox;

        protected abstract void AddButtonClickEvent(object sender, EventArgs e);
        protected abstract void UndoButtonClickEvent(object sender, EventArgs e);
        protected abstract void BoxKeyDownEvent(object sender, KeyEventArgs e);

        protected void InitializeComponents(int id)
        {
            HashEntry[] menu = RedisRepository.HGetAll("menu");
            List<string> names = new List<string>();

            foreach (HashEntry item in menu)
            {
                names.Add(item.Name);
            }

            addButton = new ButtonBuilder()
                .WithLocation(12, 118)
                .WithSize(118, 23)
                .WithName("addButton")
                .WithText("Oké")
                .AddClickEvent(AddButtonClickEvent);

            undoButton = new ButtonBuilder()
                .WithLocation(136, 118)
                .WithSize(75, 23)
                .WithName("undoButton")
                .WithText("Mégsem")
                .AddClickEvent(UndoButtonClickEvent);

            nameLabel = new LabelBuilder()
                .WithLocation(13, 13)
                .WithSize(64, 13)
                .WithName("nameLabel")
                .WithText("Termék név");

            quantityLabel = new LabelBuilder()
                .WithLocation(13, 48)
                .WithSize(35, 13)
                .WithName("quantityLabel")
                .WithText("Darabszám");

            invoiceLabel = new LabelBuilder()
                .WithLocation(13, 83)
                .WithSize(35, 13)
                .WithName("invoiceLabel")
                .WithText("Számla");

            nameBox = new TextBoxBuilder()
                .WithLocation(83, 10)
                .WithSize(128, 20)
                .WithName("nameBox")
                .WithAutoCompleteSource(names.ToArray());

            quantityBox = new NumericUpDownBuilder()
                .WithLocation(83, 45)
                .WithSize(128, 20)
                .WithName("quantityBox")
                .WithValue(1);

            invoiceBox = new TextBoxBuilder()
                .WithLocation(83, 80)
                .WithSize(128, 20)
                .WithName("invoiceBox")
                .AddKeyDownEvent(BoxKeyDownEvent)
                .WithAutoCompleteSource(RedisRepository.SMembers("szamlak_" + id));

            GetInstance()
                .WithClientSize(223, 156)
                .WithName("AddItem")
                .WithText("Tétel hozzáadás")
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .AddAll(addButton, undoButton, nameLabel, quantityLabel, invoiceLabel, nameBox, quantityBox, invoiceBox);
        }
    }
}
