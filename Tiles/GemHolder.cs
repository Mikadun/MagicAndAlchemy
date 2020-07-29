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
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 18, 16, 16 };
            //TileObjectData.newTile.StyleHorizontal = true;
            animationFrameHeight = 56;
            TileObjectData.addTile(Type);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ItemType<Items.Placeable.GemHolder>());
            if (frameX > 17)
            {
                int style = frameX / 18;
                string item;
                switch(style)
                {
                    case 1:
                        item = "EyeGem"; // green
                        break;

                    case 2:
                        item = "AncestorGem"; // blue
                        break;

                    case 3:
                        item = "BrainGem";  // red
                        break;

                    case 4:
                        item = "EaterGem"; // purple
                        break;

                    default:
                        return;
                }
                Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType(item));
            }
        }

        public override bool NewRightClick(int i, int j)
        {
            if (Main.tile[i, j].frameX < 18)
            {
                int selectedItem = Main.LocalPlayer.selectedItem;
                int topY = j - Main.tile[i, j].frameY / 18 % 3;
                int selectedIdItem = Main.LocalPlayer.inventory[selectedItem].type;
                if (selectedIdItem == ItemType<Items.EyeGem>())
                {   
                    Main.LocalPlayer.inventory[selectedItem].stack--;
                    Main.tile[i, topY].frameX = 18;
			        Main.tile[i, topY + 1].frameX = 18;
			        Main.tile[i, topY + 2].frameX = 18;
                    return true;              
                }
                if (selectedIdItem == ItemType<Items.AncestorGem>())
                {
                    Main.LocalPlayer.inventory[selectedItem].stack--;
                    Main.tile[i, topY].frameX = 36;
			        Main.tile[i, topY + 1].frameX = 36;
			        Main.tile[i, topY + 2].frameX = 36;
                    return true;
                }
                if (selectedIdItem == ItemType<Items.BrainGem>())
                {   
                    Main.LocalPlayer.inventory[selectedItem].stack--;
                    Main.tile[i, topY].frameX = 54;
			        Main.tile[i, topY + 1].frameX = 54;
			        Main.tile[i, topY + 2].frameX = 54;
                    return true;
                }
                if (selectedIdItem == ItemType<Items.EaterGem>())
                {
                    Main.LocalPlayer.inventory[selectedItem].stack--;
                    Main.tile[i, topY].frameX = 72;
			        Main.tile[i, topY + 1].frameX = 72;
			        Main.tile[i, topY + 2].frameX = 72;
                    return true;
                } 
            }
            return false;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter) {
            if (++frameCounter > 24) {
                frameCounter = 0;
                frame = ++frame % 4;
            }
		}
    }   
}