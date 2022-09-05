using BartenderUI.Util.Builders;
using BartenderUI.Util.Events;
using BartenderUI.Redis;
using StackExchange.Redis;

namespace BartenderUI.Util.Factories
{
    class TableFactory
    {
        public static PictureBoxBuilder Produce(TablePlaceEnum enumerator)
        {
            PictureBoxBuilder pictureBoxBuilder = new PictureBoxBuilder()
                .WithSize(100, 100)
                .WithLocation(50, 50)
                .AddMouseDownEvent(DragAndDropEvents.MouseDownEvent)
                .AddMouseDownEvent(ContextMenuEvent.MouseDownEvent)
                .AddMouseUpEvent(DragAndDropEvents.MouseUpEventForTable)
                .AddDoubleClickEvent(DoubleClickEvent.TableDoubleClickEvent)
                .WithId(RedisRepository.Incr("asztalId"))
                .WithState(SzabadFoglaltEnum.Szabad);

            RedisRepository.SAdd("asztalok", pictureBoxBuilder.Id.ToString());
            RedisRepository.HMSet("asztal_" + pictureBoxBuilder.Id, 
                new HashEntry("X", pictureBoxBuilder.Location.X),
                new HashEntry("Y", pictureBoxBuilder.Location.Y),
                new HashEntry("state", pictureBoxBuilder.State.ToString()),
                new HashEntry("place", enumerator.ToString()),
                new HashEntry("id", pictureBoxBuilder.Id));

            switch (enumerator)
            {
                case TablePlaceEnum.Belso:
                    pictureBoxBuilder.AddMouseMoveEvent(DragAndDropEvents.MouseMoveBelsoEvent);
                    break;
                case TablePlaceEnum.Kulso:
                    pictureBoxBuilder.AddMouseMoveEvent(DragAndDropEvents.MouseMoveKulsoEvent);
                    break;
            }

            return pictureBoxBuilder;
        }

        public static PictureBoxBuilder Produce(int id, int locX, int locY, SzabadFoglaltEnum state, TablePlaceEnum enumerator)
        {
            PictureBoxBuilder pictureBoxBuilder = new PictureBoxBuilder()
                .WithSize(100, 100)
                .AddMouseDownEvent(DragAndDropEvents.MouseDownEvent)
                .AddMouseDownEvent(ContextMenuEvent.MouseDownEvent)
                .AddMouseUpEvent(DragAndDropEvents.MouseUpEventForTable)
                .AddDoubleClickEvent(DoubleClickEvent.TableDoubleClickEvent)
                .WithId(id)
                .WithState(state)
                .WithLocation(locX, locY);

            switch (enumerator)
            {
                case TablePlaceEnum.Belso:
                    pictureBoxBuilder.AddMouseMoveEvent(DragAndDropEvents.MouseMoveBelsoEvent);
                    break;
                case TablePlaceEnum.Kulso:
                    pictureBoxBuilder.AddMouseMoveEvent(DragAndDropEvents.MouseMoveKulsoEvent);
                    break;
            }

            return pictureBoxBuilder;
        }
    }
}
