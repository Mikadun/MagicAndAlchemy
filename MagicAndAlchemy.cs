using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using MagicAndAlchemy.UI;

namespace MagicAndAlchemy
{
	public class MagicAndAlchemy : Mod
	{
		internal MenuBar MenuBar;
		private UserInterface alchemyInterface;
		public UserInterface alchemistNPCUserInterface;
		private GameTime _lastUpdateUiGameTime;

		public override void Load()
		{
			if (!Main.dedServ) {
				MenuBar = new MenuBar();
				MenuBar.Activate();
				alchemyInterface = new UserInterface();
				alchemistNPCUserInterface = new UserInterface();
				alchemyInterface.SetState(MenuBar);
			}
		}

		public override void UpdateUI(GameTime gameTime)
		{
			_lastUpdateUiGameTime = gameTime;
			if (alchemyInterface?.CurrentState != null) {
				alchemyInterface.Update(gameTime);
			}
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"MagicAndAlchemy: alchemyInterface",
					delegate
					{
						if (_lastUpdateUiGameTime != null && alchemyInterface?.CurrentState != null) {
							alchemyInterface.Draw(Main.spriteBatch, new GameTime());
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
    	}
	}
}