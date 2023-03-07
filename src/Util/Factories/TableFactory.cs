using BartenderUI.Util.Extensions;
using BartenderUI.Util.Events;
using BartenderUI.Redis;
using StackExchange.Redis;
using System.Windows.Forms;

namespace BartenderUI.Util.Factories
{
    class TableFactory
    {
        public static PictureBox Produce(TablePlaceEnum enumerator)
        {
            PictureBox pictureBox = new PictureBox()
                .WithSize(100, 100)
                .WithLocation(50, 50)
                .AddMouseDownEvent(DragAndDropEvents.MouseDownEvent)
                .AddMouseDownEvent(ContextMenuEvent.MouseDownEvent)
                .AddMouseUpEvent(DragAndDropEvents.MouseUpEventForTable)
                .AddDoubleClickEvent(DoubleClickEvent.TableDoubleClickEvent)
                .WithId(RedisRepository.Incr("asztalId"))
                .WithState(SzabadFoglaltEnum.Szabad)
                .WithIdLabel();

            RedisRepository.SAdd("asztalok", pictureBox.GetId().ToString());
            RedisRepository.HMSet("asztal_" + pictureBox.GetId(), 
                new HashEntry("X", pictureBox.Location.X),
                new HashEntry("Y", pictureBox.Location.Y),
                new HashEntry("state", pictureBox.GetState().ToString()),
                new HashEntry("place", enumerator.ToString()),
                new HashEntry("id", pictureBox.GetId()));

            switch (enumerator)
            {
                case TablePlaceEnum.Belso:
                    pictureBox.AddMouseMoveEvent(DragAndDropEvents.MouseMoveBelsoEvent);
                    break;
                case TablePlaceEnum.Kulso:
                    pictureBox.AddMouseMoveEvent(DragAndDropEvents.MouseMoveKulsoEvent);
                    break;
            }

            return pictureBox;
        }

        public static PictureBox Produce(int id, int locX, int locY, SzabadFoglaltEnum state, TablePlaceEnum enumerator)
        {
            PictureBox pictureBox = new PictureBox()
                .WithSize(100, 100)
                .AddMouseDownEvent(DragAndDropEvents.MouseDownEvent)
                .AddMouseDownEvent(ContextMenuEvent.MouseDownEvent)
                .AddMouseUpEvent(DragAndDropEvents.MouseUpEventForTable)
                .AddDoubleClickEvent(DoubleClickEvent.TableDoubleClickEvent)
                .WithId(id)
                .WithState(state)
                .WithLocation(locX, locY)
                .WithIdLabel();

            switch (enumerator)
            {
                case TablePlaceEnum.Belso:
                    pictureBox.AddMouseMoveEvent(DragAndDropEvents.MouseMoveBelsoEvent);
                    break;
                case TablePlaceEnum.Kulso:
                    pictureBox.AddMouseMoveEvent(DragAndDropEvents.MouseMoveKulsoEvent);
                    break;
            }

            return pictureBox;
        }
    }
}
