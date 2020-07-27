using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using MagicAndAlchemy.Buffs;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Items
{
	public class PotionConsumeGlobalItem : GlobalItem
	{
        public override void OnConsumeItem(Item item, Player player) {
            if (item.potion || item.UseSound != null && item.UseSound.Style == 3 && item.buffType > 0) {
                int time = 60 * 5;
                player.AddBuff(BuffType<Intoxication>(), time);
            }
        }
	}
}
