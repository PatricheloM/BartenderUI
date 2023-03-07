using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BartenderUI.Redis;
using BartenderUI.Util.Extensions;
using StackExchange.Redis;

namespace BartenderUI.List
{
    abstract class AbstractAddItem : Form
    {
        private Button addButton;
        private Button undoButton;

        private Label nameLabel;
        private Label quantityLabel;
        private Label invoiceLabel;

        protected ComboBox nameBox;
        protected NumericUpDown quantityBox;
        protected ComboBox invoiceBox;

        protected abstract void AddButtonClickEvent(object sender, EventArgs e);
        protected abstract void UndoButtonClickEvent(object sender, EventArgs e);

        protected void InitializeComponents(int id)
        {
            HashEntry[] menu = RedisRepository.HGetAll("menu");
            List<string> names = new List<string>();

            foreach (HashEntry item in menu)
            {
                names.Add(item.Name);
            }

            addButton = new Button()
                .WithLocation(12, 118)
                .WithSize(118, 23)
                .WithName("addButton")
                .WithText("Oké")
                .AddClickEvent(AddButtonClickEvent);

            undoButton = new Button()
                .WithLocation(136, 118)
                .WithSize(75, 23)
                .WithName("undoButton")
                .WithText("Mégsem")
                .AddClickEvent(UndoButtonClickEvent);

            nameLabel = new Label()
                .WithLocation(13, 13)
                .WithSize(64, 13)
                .WithName("nameLabel")
                .WithText("Termék név");

            quantityLabel = new Label()
                .WithLocation(13, 48)
                .WithSize(35, 13)
                .WithName("quantityLabel")
                .WithText("Darabszám");

            invoiceLabel = new Label()
                .WithLocation(13, 83)
                .WithSize(35, 13)
                .WithName("invoiceLabel")
                .WithText("Számla");

            nameBox = new ComboBox()
                .WithLocation(83, 10)
                .WithSize(128, 20)
                .WithName("nameBox")
                .AddAll(names.ToArray())
                .WithAutoCompleteSource(names.ToArray());

            quantityBox = new NumericUpDown()
                .WithLocation(83, 45)
                .WithSize(128, 20)
                .WithName("quantityBox")
                .WithValue(1);

            invoiceBox = new ComboBox()
                .WithLocation(83, 80)
                .WithSize(128, 20)
                .WithName("invoiceBox")
                .WithReadOnlyValue(true)
                .AddAll(RedisRepository.SMembers("szamlak_" + id))
                .AddAll(new string[] { "<Új számla>"})
                .WithDefaultValue("<Új számla>");

            this
                .WithClientSize(223, 156)
                .WithName("AddItem")
                .WithText("Tétel hozzáadás")
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .AddAll(addButton, undoButton, nameLabel, quantityLabel, invoiceLabel, nameBox, quantityBox, invoiceBox);
        }
    }
}
