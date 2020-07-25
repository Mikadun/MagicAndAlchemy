using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicAndAlchemy.Items
{
	public class BrainGem : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brain of Cthulhu's Gem");
			Tooltip.SetDefault("God, how disgusting... Oh! What is it?");
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