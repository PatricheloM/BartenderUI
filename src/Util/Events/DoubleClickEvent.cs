using System;
using System.Windows.Forms;
using BartenderUI.Util.Extensions;

namespace BartenderUI.Util.Events
{
    class DoubleClickEvent
    {
        public static void TableDoubleClickEvent(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            List.List list = new List.List(pictureBox.GetId());
            list.ShowDialog();
        }
    }
}
