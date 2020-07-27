using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MagicAndAlchemy.Items;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy
{
	public class Recipes
	{
		private List<PotionRecipe> potionRecipes;
		private int maxPotionIngredientCount;

		public Recipes(int _maxPotionIngredient) {
			maxPotionIngredientCount = _maxPotionIngredient;
			potionRecipes = new List<PotionRecipe>();
			AddPotionRecipe(new int[] {ItemID.Mushroom, ItemID.Daybloom, ItemID.Blinkroot, ItemType<BloodFlask>()}, ItemID.RegenerationPotion);
		}

		public bool CraftPotion(int[] ingredients) {
			for (int i = 0; i < potionRecipes.Count; i++) {
				if (potionRecipes[i].isSame(ingredients)) {
					PotionRecipe p = potionRecipes[i];
					Main.LocalPlayer.QuickSpawnItem(p.resultId, p.stack);
					return true;
				}
			}
			return false;
		}

		public void AddPotionRecipe(int[] ingredients, int resultId, int stack = 1) {
			if (ingredients.Length < maxPotionIngredientCount) {
				int[] newIngredients = new int[maxPotionIngredientCount];
				for (int i = 0; i < maxPotionIngredientCount; i++) {
					if (i < ingredients.Length) {
						newIngredients[i] = ingredients[i];
					} else {
						newIngredients[i] = 0;
					}
				}
				ingredients = newIngredients;
			}
			Array.Sort(ingredients);
			potionRecipes.Add(new PotionRecipe(ingredients, resultId, stack));
		}
	}


	public class PotionRecipe {
		private int[] ingredients;
		public int resultId;
		public int stack;

		public PotionRecipe(int[] _ingredients, int _resultId, int _stack = 1) {
			ingredients = _ingredients;
			resultId = _resultId;
			stack = _stack;
		}

		public bool isSame(int[] _ingredients) {
			return (ingredients.SequenceEqual(_ingredients));
		}
	}
}