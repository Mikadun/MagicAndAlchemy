using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Items.Placeable
{
    public class AlchemicalCauldron : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alchemical Cauldron");
            Tooltip.SetDefault("Throw stuff in there and see what happens");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.CookingPot);
            item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Blue;
            item.createTile = TileType<Tiles.AlchemicalCauldron>();
        }
    }
}