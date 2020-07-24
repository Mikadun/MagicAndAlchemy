using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Items.Placeable
{
    public class GemHolder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem Holder");
            Tooltip.SetDefault("Place boss gems to activate the Altar");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 24;
            item.useTurn = true;
            item.useTime = 10;
            item.useAnimation = 15;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = TileType<Tiles.GemHolder>();
        }
    }
}