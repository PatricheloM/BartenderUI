using System;
using System.Windows.Forms;
using System.Drawing;
using BartenderUI.Util;
using BartenderUI.Util.Extensions;
using BartenderUI.Util.Structs;

namespace BartenderUI.Layout
{
    abstract class AbstractLayout : Form
    {
        private Button pluszBelso;
        private Button pluszKulso;

        private Button exitButton;
        private Button minimizeButton;
        private Button menuButton;
        private Button kifizetesButton;
        private Button resetButton;

        protected GroupBox groupBoxBelso;
        protected GroupBox groupBoxKulso;

        protected Label newOrderLabel;

        protected abstract void PluszBelsoButtonClickEvent(object sender, EventArgs e);
        protected abstract void PluszKulsoButtonClickEvent(object sender, EventArgs e);
        protected abstract void ExitButtonClickEvent(object sender, EventArgs e);
        protected abstract void MinimizeButtonClickEvent(object sender, EventArgs e);
        protected abstract void MenuButtonClickEvent(object sender, EventArgs e);
        protected abstract void KifizetesButtonClickEvent(object sender, EventArgs e);
        protected abstract void ResetButtonClickEvent(object sender, EventArgs e);
        protected abstract void NewOrderLabelClickEvent(object sender, EventArgs e);

        protected void InitializeComponents() 
        {
            pluszBelso = new Button()
                .WithFont("Microsoft Sans Serif", 32F)
                .WithLocation(5, 60)
                .WithName("pluszB")
                .WithText("+")
                .WithSize(50, 50)
                .AddClickEvent(PluszBelsoButtonClickEvent);

            pluszKulso = new Button()
                .WithFont("Microsoft Sans Serif", 32F)
                .WithLocation(ScreenBoundsHelper.ScreenWidth() / 3 * 2 - 5, 60)
                .WithName("pluszK")
                .WithText("+")
                .WithSize(50, 50)
                .AddClickEvent(PluszKulsoButtonClickEvent);

            exitButton = new Button()
                .WithFont("Microsoft Sans Serif", 32F, FontStyle.Bold)
                .WithLocation(ScreenBoundsHelper.ScreenWidth() - 55, 5)
                .WithName("exitButton")
                .WithSize(50, 50)
                .WithText("X")
                .AddClickEvent(ExitButtonClickEvent);

            minimizeButton = new Button()
                .WithFont("Microsoft Sans Serif", 28F, FontStyle.Bold)
                .WithLocation(ScreenBoundsHelper.ScreenWidth() - 110, 5)
                .WithName("minimizeButton")
                .WithSize(50, 50)
                .WithText("_")
                .AddClickEvent(MinimizeButtonClickEvent);

            menuButton = new Button()
                .WithFont("Microsoft Sans Serif", 20F, FontStyle.Bold)
                .WithLocation(ScreenBoundsHelper.ScreenWidth() - 225, 5)
                .WithName("menuButton")
                .WithSize(110, 50)
                .WithText("Menü")
                .AddClickEvent(MenuButtonClickEvent);

            kifizetesButton = new Button()
                .WithFont("Microsoft Sans Serif", 18F, FontStyle.Bold)
                .WithLocation(ScreenBoundsHelper.ScreenWidth() - 355, 5)
                .WithName("kifizetesButton")
                .WithSize(125, 50)
                .WithText("Kifizetés")
                .AddClickEvent(KifizetesButtonClickEvent);

            resetButton = new Button()
                .WithFont("Microsoft Sans Serif", 14F, FontStyle.Bold)
                .WithLocation(ScreenBoundsHelper.ScreenWidth() - 510, 5)
                .WithName("resetButton")
                .WithSize(150, 50)
                .WithText("Új elrendezés")
                .AddClickEvent(ResetButtonClickEvent);

            groupBoxBelso = new GroupBox()
                .WithName("groupBoxBelso")
                .WithLocation(10, 60)
                .WithSize(ScreenBoundsHelper.ScreenWidth() / 3 * 2 - 20, ScreenBoundsHelper.ScreenHeight() - 80);

            groupBoxKulso = new GroupBox()
                .WithName("groupBoxKulso")
                .WithLocation(ScreenBoundsHelper.ScreenWidth() / 3 * 2, 60)
                .WithSize(ScreenBoundsHelper.ScreenWidth() / 3 - 10, ScreenBoundsHelper.ScreenHeight() - 80);

            newOrderLabel = new Label()
                .WithName("newOrderLabel")
                .WithLocation((ScreenBoundsHelper.ScreenWidth() - 500) / 2, 15)
                .WithText("Új rendelés!")
                .WithFont("Microsoft Sans Serif", 24F, FontStyle.Bold)
                .WithFlashing(500, Color.Red, Color.Black)
                .WithAutoSizeValue(true)
                .WithBackColor(Color.Transparent)
                .WithHiddenValue(true)
                .AddClickEvent(NewOrderLabelClickEvent);

            this
                .WithClientSize(ScreenBoundsHelper.ScreenWidth(), ScreenBoundsHelper.ScreenHeight())
                .WithFormBorderStyle(FormBorderStyle.None)
                .WithName("Layout")
                .WithText("Bartender")
                .WithIcon(FilePathStruct.Icon)
                .AddAll(pluszBelso, pluszKulso, resetButton, menuButton, kifizetesButton, minimizeButton, exitButton, groupBoxBelso, groupBoxKulso, newOrderLabel);
        }
    }
}
