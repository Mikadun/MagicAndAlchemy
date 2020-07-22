using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Tiles
{
    public class AlchemicalAltar : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileBlockLight[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileCut[Type] = false;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.CoordinateHeights = new[] { 18, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            animationFrameHeight = 38;
        }

        public override void NumDust(int i, int j, bool fail, ref int num) 
        {
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) 
        {
			Item.NewItem(i * 16, j * 16, 32, 16, ItemType<Items.Placeable.AlchemicalAltar>());
		}

        public override void AnimateTile(ref int frame, ref int frameCounter) {
			frameCounter++;
            if (frameCounter > 6) {
                frameCounter = 0;
                frame++;
                frame %= 30;
            }
		}
    }
}