using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicAndAlchemy.Items
{
	public class EyeGem : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Cthulhu's Gem");
			Tooltip.SetDefault("A trophy from a hard battle. You wonder what it's for?");
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