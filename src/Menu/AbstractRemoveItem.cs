using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BartenderUI.Util.Builders;
using BartenderUI.Redis;
using StackExchange.Redis;

namespace BartenderUI.Menu
{
    abstract class AbstractRemoveItem : FormBuilder
    {
        private ButtonBuilder removeButton;
        private ButtonBuilder undoButton;

        private LabelBuilder infoLabel;

        protected TextBoxBuilder nameBox;

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

            removeButton = new ButtonBuilder()
                .WithLocation(12, 58)
                .WithSize(118, 23)
                .WithName("addButton")
                .WithText("Oké")
                .AddClickEvent(RemoveButtonClickEvent);

            undoButton = new ButtonBuilder()
                .WithLocation(136, 58)
                .WithSize(75, 23)
                .WithName("undoButton")
                .WithText("Mégsem")
                .AddClickEvent(UndoButtonClickEvent);

            nameBox = new TextBoxBuilder()
                .WithLocation(12, 25)
                .WithSize(198, 20)
                .WithName("nameBox")
                .AddKeyDownEvent(BoxKeyDownEvent)
                .WithAutoCompleteSource(names.ToArray());

            infoLabel = new LabelBuilder()
                .WithLocation(12, 5)
                .WithSize(64, 13)
                .WithName("nameLabel")
                .WithText("Kezdje el gépelni!");

            GetInstance()
                .WithClientSize(223, 88)
                .WithName("RemoveItem")
                .WithText("Tétel eltávolítás")
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .AddAll(removeButton, undoButton, infoLabel, nameBox);
        }
    }
}
