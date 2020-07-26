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
		private UserInterface alchemicalCraftingInterface;
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
				alchemicalCraftingInterface.SetState(alchemicalCraftingUI);
			}
		}

		public override void AddRecipes() {
			recipes = new Recipes();
			alchemicalCraftingUI.craftButton.OnClick += CraftPotion;
		}

		public void CraftPotion(UIMouseEvent evt,  UIElement listeningElement) {
            Main.NewText(Main.inventoryBack9Texture.Width.ToString() + " " + Main.inventoryBack9Texture.Height.ToString());

			int bottle = alchemicalCraftingUI.bottleSlot.Item.type;
			int catalyst = alchemicalCraftingUI.catalystSlot.Item.type;
			int[] ingredients = new int[alchemicalCraftingUI.maxIngredientCount];
			for (int i = 0; i < ingredients.Length; i++) {
				ingredients[i] = alchemicalCraftingUI.ingredientSlots[i].Item.type;
				Main.NewText(ingredients[i].ToString());
			}
			Array.Sort(ingredients);
			
			bool result = recipes.CraftPotion(bottle, catalyst, ingredients);
			if (result) {
				alchemicalCraftingUI.bottleSlot.Item.stack--;
				alchemicalCraftingUI.catalystSlot.Item.stack--;
				for (int i = 0; i < ingredients.Length; i++) {
					alchemicalCraftingUI.ingredientSlots[i].Item.stack--;
				}
			}
		}

		public override void UpdateUI(GameTime gameTime)
		{
			_lastUpdateUiGameTime = gameTime;
			if (alchemicalCraftingInterface?.CurrentState != null) {
				alchemicalCraftingInterface.Update(gameTime);
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