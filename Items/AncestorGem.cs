using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicAndAlchemy.Items
{
	public class AncestorGem : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancestor's Gem");
			Tooltip.SetDefault("He held it very dear. You need to ask the Alchemist about this.");
		}

		public override void SetDefaults()
        {
			item.width = 35;
			item.height = 27;
			item.maxStack = 99;
			item.value = Item.buyPrice(gold: 1, silver: 25);
			item.rare = ItemRarityID.Quest;
		}
    }
}