using System;
using BartenderUI.Util.Builders;
namespace BartenderUI.Util.Events
{
    class DoubleClickEvent
    {
        public static void TableDoubleClickEvent(object sender, EventArgs e)
        {
            PictureBoxBuilder pictureBoxBuilder = sender as PictureBoxBuilder;
            List.List list = new List.List(pictureBoxBuilder.Id);
            list.ShowDialog();
        }
    }
}
