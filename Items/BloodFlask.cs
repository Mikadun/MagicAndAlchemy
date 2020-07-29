using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicAndAlchemy.Items
{
	public class BloodFlask : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Flask full of blood.");
		}

		public override void SetDefaults() {
			item.width = 10;
			item.height = 30;
			item.maxStack = 999;
			item.value = Item.buyPrice(silver: 15);
			item.rare = ItemRarityID.Blue;
		}
	}
}
