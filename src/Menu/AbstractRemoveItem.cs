using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BartenderUI.Util.Extensions;
using BartenderUI.Redis;
using StackExchange.Redis;

namespace BartenderUI.Menu
{
    abstract class AbstractRemoveItem : Form
    {
        private Button removeButton;
        private Button undoButton;

        private Label infoLabel;

        protected ComboBox nameBox;

        protected abstract void RemoveButtonClickEvent(object sender, EventArgs e);
        protected abstract void UndoButtonClickEvent(object sender, EventArgs e);
        protected abstract void BoxKeyDownEvent(object sender, KeyEventArgs e);

        protected void InitializeComponents()
        {
            HashEntry[] menu = RedisRepository.HGetAll("menu");
            List<string> names = new List<string>();

            foreach (HashEntry item in menu)
            {
                names.Add(item.Name);
            }

            removeButton = new Button()
                .WithLocation(12, 58)
                .WithSize(118, 23)
                .WithName("addButton")
                .WithText("Oké")
                .AddClickEvent(RemoveButtonClickEvent);

            undoButton = new Button()
                .WithLocation(136, 58)
                .WithSize(75, 23)
                .WithName("undoButton")
                .WithText("Mégsem")
                .AddClickEvent(UndoButtonClickEvent);

            nameBox = new ComboBox()
                .WithLocation(12, 25)
                .WithSize(198, 20)
                .WithName("nameBox")
                .AddKeyDownEvent(BoxKeyDownEvent)
                .WithAutoCompleteSource(names.ToArray())
                .AddAll(names.ToArray());

            infoLabel = new Label()
                .WithLocation(12, 5)
                .WithSize(64, 13)
                .WithName("infoLabel")
                .WithText("Kezdje el gépelni!");

            this
                .WithClientSize(223, 88)
                .WithName("RemoveItem")
                .WithText("Tétel eltávolítás")
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .AddAll(removeButton, undoButton, infoLabel, nameBox);
        }
    }
}
