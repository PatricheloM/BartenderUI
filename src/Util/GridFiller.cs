using System;
using StackExchange.Redis;
using BartenderUI.Util.Builders;
using BartenderUI.Redis;
using BartenderUI.Util;

namespace BartenderUI.Util
{
    class GridFiller
    {
        public static void FillGrid(DataGridViewBuilder grid, HashEntry[] entries)
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

        public static void FillGrid(DataGridViewBuilder grid, int id)
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
    }
}
