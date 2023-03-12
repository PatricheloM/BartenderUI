using BartenderUI.Util.Extensions;
using BartenderUI.Util.Events;
using BartenderUI.Redis;
using StackExchange.Redis;
using System.Windows.Forms;
using BartenderUI.Util.HelperTypes;

namespace BartenderUI.Util.Factories
{
    class TableFactory
    {
        public static Table Produce(TablePlaceEnum enumerator)
        {
            Table table = new Table()
                .WithSize(100, 100)
                .WithLocation(50, 50)
                .AddMouseDownEvent(DragAndDropEvents.MouseDownEvent)
                .AddMouseDownEvent(ContextMenuEvent.MouseDownEvent)
                .AddMouseUpEvent(DragAndDropEvents.MouseUpEventForTable)
                .AddDoubleClickEvent(DoubleClickEvent.TableDoubleClickEvent)
                .WithId(RedisRepository.Incr("asztalId"))
                .WithState(SzabadFoglaltEnum.Szabad)
                .WithIdLabel();

            RedisRepository.SAdd("asztalok", table.Id.ToString());
            RedisRepository.HMSet("asztal_" + table.Id, 
                new HashEntry("X", table.Location.X),
                new HashEntry("Y", table.Location.Y),
                new HashEntry("state", table.State.ToString()),
                new HashEntry("place", enumerator.ToString()),
                new HashEntry("id", table.Id));

            switch (enumerator)
            {
                case TablePlaceEnum.Belso:
                    table.AddMouseMoveEvent(DragAndDropEvents.MouseMoveBelsoEvent);
                    break;
                case TablePlaceEnum.Kulso:
                    table.AddMouseMoveEvent(DragAndDropEvents.MouseMoveKulsoEvent);
                    break;
            }

            return table;
        }

        public static Table Produce(int id, int locX, int locY, SzabadFoglaltEnum state, TablePlaceEnum enumerator)
        {
            Table table = new Table()
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
                    table.AddMouseMoveEvent(DragAndDropEvents.MouseMoveBelsoEvent);
                    break;
                case TablePlaceEnum.Kulso:
                    table.AddMouseMoveEvent(DragAndDropEvents.MouseMoveKulsoEvent);
                    break;
            }

            return table;
        }
    }
}
