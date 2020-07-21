using Terraria.UI;

namespace MagicAndAlchemy.UI
{
    class MenuBar : UIState
    {
        public PlayButton playButton;

        public override void OnInitialize()
        {
            playButton = new PlayButton();
            Append(playButton);
        }
    }
}