
using Terraria;
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
            Main.tileCut[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.CoordinateHeights = new[] { 18 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
        }

        public override void NumDust(int i, int j, bool fail, ref int num) 
        {
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) 
        {
			Item.NewItem(i * 16, j * 16, 32, 16, ItemType<Items.Placeable.AlchemicalAltar>());
		}
    }
}