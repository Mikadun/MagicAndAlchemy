using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
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
                        item = "EyeGem";
                        break;

                    case 2:
                        item = "AncestorGem";
                        break;

                    case 3:
                        item = "BrainGem";
                        break;

                    case 4:
                        item = "EaterGem";
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
                int[] gemsTypes = new int[4] {ItemType<Items.EyeGem>(), ItemType<Items.AncestorGem>(), ItemType<Items.BrainGem>(), ItemType<Items.EaterGem>()};
                
                for (int k = 0; k < 4; k++)
                    if (selectedIdItem == gemsTypes[k]){
                        Main.LocalPlayer.inventory[selectedItem].stack--;
                        Main.tile[i, topY].frameX = (short)(18 * (k+1));
			            Main.tile[i, topY + 1].frameX = (short)(18 * (k+1));
			            Main.tile[i, topY + 2].frameX = (short)(18 * (k+1));

                        if (gemsTypes[k] == ItemType<Items.AncestorGem>()) CheckTheArea(i, topY);
                        return true; 
                    }
                return false;
            }
            else 
            {
                int selectedItem = Main.LocalPlayer.selectedItem;
                int topY = j - Main.tile[i, j].frameY / 18 % 3;
                int selectedIdItem = Main.LocalPlayer.inventory[selectedItem].type;
                int[] gemsTypes = new int[4] {ItemType<Items.EyeGem>(), ItemType<Items.AncestorGem>(), ItemType<Items.BrainGem>(), ItemType<Items.EaterGem>()};
                if (selectedIdItem != 0)
                {
                    for (int k = 0; k < 4; k++)
                        if (selectedIdItem == gemsTypes[k] && Main.tile[i, j].frameX != (short)(18 * (k+1))){
                            Main.LocalPlayer.inventory[selectedItem].stack--;
                        
                            int style = Main.tile[i, topY].frameX / 18;
                            string item;
                            switch(style)
                            {
                            case 1:
                                    item = "EyeGem";
                                    break;

                                case 2:
                                    item = "AncestorGem";
                                    break;

                                case 3:
                                    item = "BrainGem";
                                    break;

                                case 4:
                                    item = "EaterGem";
                                    break;

                                default:
                                    return false;
                            }
                                             
                            Main.tile[i, topY].frameX = (short)(18 * (k+1));
                            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType(item));
			                Main.tile[i, topY + 1].frameX = (short)(18 * (k+1));
			                Main.tile[i, topY + 2].frameX = (short)(18 * (k+1));

                            if (gemsTypes[k] == ItemType<Items.AncestorGem>()) CheckTheArea(i, topY);
                            return true; 
                        }
                }
                else
                {
                    int style = Main.tile[i, topY].frameX / 18;
                    string item;
                    switch(style)
                    {
                    case 1:
                            item = "EyeGem";
                            break;

                        case 2:
                            item = "AncestorGem";
                            break;

                        case 3:
                            item = "BrainGem";
                            break;

                        case 4:
                            item = "EaterGem";
                            break;

                        default:
                            return false;
                    }
                    
                    Main.tile[i, topY].frameX = 0;
                    Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType(item));
			        Main.tile[i, topY + 1].frameX = 0;
			        Main.tile[i, topY + 2].frameX = 0;
                    return true;
                }
            }
            return false;
        }

        private void CheckTheArea(int i, int topY)
        {
            int blockType = TileType<Tiles.AltarBlock>();
            int GemHolderType = TileType<Tiles.GemHolder>();

            for (int k = 0; k < 2; k++)
                for (int c = 0; c < 3; c++)
                {
                    Tile tile = Main.tile[i - c, topY + 3 - k];
                    if (tile.type == blockType) continue;
                    if (tile.type == GemHolderType && tile.frameX > 17) continue;
                    return;
                }

            for (int k = 0; k < 2; k++)
                for (int c = 0; c < 3; c++)
                {
                    Tile tile = Main.tile[i - c, topY + 3 - k];
                    if (tile.type == blockType){
                        tile.ClearEverything();
                        continue;
                    }
                    if (tile.type == GemHolderType){
                        tile.ClearEverything();
                        Main.tile[i - c, topY + 2 - k].ClearEverything();
                        Main.tile[i - c, topY + 1 - k].ClearEverything();
                        continue;
                    } 
                }
            
            Item.NewItem(i * 16, topY * 16, 32, 16, ItemType<Items.Placeable.AlchemicalAltar>());
        }


        public override void AnimateTile(ref int frame, ref int frameCounter) {
            if (++frameCounter > 24) {
                frameCounter = 0;
                frame = ++frame % 4;
            }
		}
    }   
}