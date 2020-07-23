using Terraria.UI;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace MagicAndAlchemy.UI
{
    class MenuBar : UIState
    {
        public PlayButton playButton;
        public ItemSlotWrapper itemSlot;

        public override void OnInitialize()
        {
            playButton = new PlayButton();
            itemSlot = new ItemSlotWrapper(ItemSlot.Context.ChestItem, 1f) {
                Left = { Pixels = 50 },
                Top = { Pixels = 270 },
                ValidItemFunc = item => true
            };
            //Append(playButton);
            Append(itemSlot);
        }
    }
}