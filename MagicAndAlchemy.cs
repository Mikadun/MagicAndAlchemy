using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using MagicAndAlchemy;
using MagicAndAlchemy.UI;

namespace MagicAndAlchemy
{
	public class MagicAndAlchemy : Mod
	{
		internal AlchemicalCraftingUI alchemicalCraftingUI;
		internal UserInterface alchemicalCraftingInterface;
		internal Vector2 cauldronPosition;
		public UserInterface alchemistNPCUserInterface;
		private GameTime _lastUpdateUiGameTime;
		public Recipes recipes;

		public override void Load()
		{
			if (!Main.dedServ) {
				alchemicalCraftingUI = new AlchemicalCraftingUI();
				alchemicalCraftingUI.Activate();
				alchemicalCraftingInterface = new UserInterface();
				alchemistNPCUserInterface = new UserInterface();
				alchemicalCraftingInterface.SetState(null);
			}
		}

		public override void AddRecipes() {
			recipes = new Recipes(alchemicalCraftingUI.maxIngredientCount);
			alchemicalCraftingUI.craftButton.OnClick += CraftPotion;
		}

		public void CraftPotion(UIMouseEvent evt,  UIElement listeningElement) {
			int[] ingredients = new int[alchemicalCraftingUI.maxIngredientCount];
			for (int i = 0; i < ingredients.Length; i++) {
				ingredients[i] = alchemicalCraftingUI.ingredientSlots[i].Item.type;
			}
			Array.Sort(ingredients);
			
			bool result = recipes.CraftPotion(ingredients);
			if (result) {
				for (int i = 0; i < ingredients.Length; i++) {
					alchemicalCraftingUI.ingredientSlots[i].Item.stack--;
				}
			}
		}

		public override void UpdateUI(GameTime gameTime)
		{
			_lastUpdateUiGameTime = gameTime;
			if (alchemicalCraftingInterface?.CurrentState != null) {
				if ((Main.LocalPlayer.Center.ToTileCoordinates().ToVector2() - cauldronPosition).Length() > 10) {
					alchemicalCraftingInterface.SetState(null);
				} else {
					alchemicalCraftingInterface.Update(gameTime);
				}
			}
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"MagicAndAlchemy: Alchemical Crafting Interface",
					delegate
					{
						if (_lastUpdateUiGameTime != null && alchemicalCraftingInterface?.CurrentState != null) {
							alchemicalCraftingInterface.Draw(Main.spriteBatch, new GameTime());
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
    	}
	}
}