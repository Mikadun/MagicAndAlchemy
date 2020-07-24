using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Items.Placeable
{
    public class AltarBlock : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Altar Block");
            Tooltip.SetDefault("Infused with the souls of creatures");
        }

        public override void SetDefaults()
        {
            item.width = 12;
			item.height = 12;
            item.maxStack = 999;
            item.autoReuse = true;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = TileType<Tiles.AltarBlock>();
        }
    }
}