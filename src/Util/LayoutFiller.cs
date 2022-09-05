using System;
using BartenderUI.Redis;
using BartenderUI.Util.Builders;
using BartenderUI.Util.Factories;

namespace BartenderUI.Util
{
    class LayoutFiller
    {
        public static void FillLayout(GroupBoxBuilder belso, GroupBoxBuilder kulso)
        {
            foreach (string tableId in RedisRepository.SMembers("asztalok"))
            {
                PictureBoxBuilder table = TableFactory.Produce(
                    Convert.ToInt32(tableId),
                    Convert.ToInt32(RedisRepository.HGet("asztal_" + tableId, "X")),
                    Convert.ToInt32(RedisRepository.HGet("asztal_" + tableId, "Y")), 
                    RedisRepository.HGet("asztal_" + tableId, "state") == "Szabad" ? SzabadFoglaltEnum.Szabad : SzabadFoglaltEnum.Foglalt, 
                    RedisRepository.HGet("asztal_" + tableId, "place") == "Belso" ? TablePlaceEnum.Belso : TablePlaceEnum.Kulso);

                switch (RedisRepository.HGet("asztal_" + tableId, "place"))
                {
                    case "Belso":
                        belso.AddAll(table);
                        break;
                    case "Kulso":
                        kulso.AddAll(table);
                        break;
                }
            }
        }
    }
}
