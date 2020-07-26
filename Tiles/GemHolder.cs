using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Tiles
{
    public class GemHolder : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileBlockLight[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileCut[Type] = false;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
            TileObjectData.newTile.CoordinateHeights = new int[] { 18, 18, 18 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ItemType<Items.Placeable.GemHolder>());
        }

        public override bool NewRightClick(int i, int j)
        {
            int selectedItem = Main.LocalPlayer.selectedItem;
            selectedItem = Main.LocalPlayer.inventory[selectedItem].type;
            if (selectedItem == ItemType<Items.EyeGem>())
            {
                Main.tile[i, j].frameX = 18;
                return true;
            }
            if (selectedItem == ItemType<Items.AncestorGem>())
            {
                Main.tile[i, j].frameX = 36;
                return true;
            }
            if (selectedItem == ItemType<Items.BrainGem>())
            {
                Main.tile[i, j].frameX = 54;
                return true;
            }
            if (selectedItem == ItemType<Items.EaterGem>())
            {
                Main.tile[i, j].frameX = 72;
                return true;
            } 
            return false;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter) {
			frameCounter++;
            if (frameCounter > 4) {
                frameCounter = 0;
                frame++;
                frame %= 6;
            }
		}
    }   
}