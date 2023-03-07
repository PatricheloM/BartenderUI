using System;
using StackExchange.Redis;
using BartenderUI.Util.Extensions;
using BartenderUI.Redis;
using BartenderUI.Util.HelperTypes;
using System.Windows.Forms;

namespace BartenderUI.Util
{
    class GridFiller
    {
        public static void FillGrid(DataGridView grid, NewOrder[] orders)
        {
            for (int i = 0; grid.Rows.Count > i;)
            {
                grid.Rows.RemoveAt(i);
            }

            foreach (NewOrder order in orders)
            {
                grid.Rows.Add(order.Item, order.Quantity, order.Table, order.Invoice,
                    new Button()
                    .WithName("isDelivered")
                    .WithText("OK"));
                    //.AddClickEvent()); TODO
            }
        }

        public static void FillGrid(DataGridView grid, HashEntry[] entries)
        {
            for (int i = 0; grid.Rows.Count > i;)
            {
                grid.Rows.RemoveAt(i);
            }

            foreach (HashEntry entry in entries)
            {
                grid.Rows.Add(entry.Name, entry.Value);
            }
        }

        public static void FillGrid(DataGridView grid, int id)
        {
            for (int i = 0; grid.Rows.Count > i;)
            {
                grid.Rows.RemoveAt(i);
            }

            foreach (string szamla in RedisRepository.SMembers("szamlak_" + id.ToString()))
            {
                foreach (HashEntry item in RedisRepository.HGetAll("szamla_" + szamla))
                {
                    grid.Rows.Add(
                        item.Name, 
                        item.Value,
                        PriceCalculator.Visualizer(item.Name, Convert.ToInt32(item.Value)), 
                        szamla);
                }
            }
        }

        public static void FillGrid(DataGridView grid, string invoice)
        {
            for (int i = 0; grid.Rows.Count > i;)
            {
                grid.Rows.RemoveAt(i);
            }

            foreach (HashEntry item in RedisRepository.HGetAll("szamla_" + invoice))
            {
                grid.Rows.Add(
                    item.Name,
                    item.Value,
                    PriceCalculator.Visualizer(item.Name, Convert.ToInt32(item.Value)));
            }
        }
    }
}
