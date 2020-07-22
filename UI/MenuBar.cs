using Terraria.UI;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace MagicAndAlchemy.UI
{
    class MenuBar : UIState
    {
        public PlayButton playButton;
        public UIItemSlot itemSlot;

        public override void OnInitialize()
        {
            playButton = new PlayButton();
            itemSlot = new UIItemSlot(new Vector2(Main.screenWidth + 50, Main.screenHeight + 50) / 2f);
            //Append(playButton);
            Append(itemSlot);
        }
    }
}