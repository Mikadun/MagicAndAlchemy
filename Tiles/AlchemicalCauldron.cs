using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Tiles
{
    public class AlchemicalCauldron : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileBlockLight[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileCut[Type] = false;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new[] {16, 16};
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
        }

		public override void KillMultiTile(int i, int j, int frameX, int frameY) 
        {
			Item.NewItem(i * 16, j * 16, 32, 16, ItemType<Items.Placeable.AlchemicalCauldron>());
		}

        public override bool NewRightClick(int i, int j) {
            GetInstance<MagicAndAlchemy>().alchemicalCraftingInterface.SetState(GetInstance<MagicAndAlchemy>().alchemicalCraftingUI);
            GetInstance<MagicAndAlchemy>().cauldronPosition = new Vector2(i, j);
            return true;
        }
    }
}