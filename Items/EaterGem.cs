using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicAndAlchemy.Items
{
	public class EaterGem : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eater of World's Gem");
			Tooltip.SetDefault("Eater of World left behind a gem. Power radiates from it...");
		}

		public override void SetDefaults()
        {
			item.width = 35;
			item.height = 27;
			item.maxStack = 99;
			item.value = Item.buyPrice(silver: 75);
			item.rare = ItemRarityID.Blue;
		}
    }
}