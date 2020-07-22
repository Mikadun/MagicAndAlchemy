using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Items.Placeable
{
    public class AlchemicalAltar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alchemical Altar");
            Tooltip.SetDefault("The altar for carrying out the transmutations.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.Blue;
            item.useTurn = true;
            item.useTime = 10;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = TileType<Tiles.AlchemicalAltar>();
        }
    }
}