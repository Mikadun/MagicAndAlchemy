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
		List<PotionRecipe> potionRecipes;

		public Recipes() {
			potionRecipes = new List<PotionRecipe>();
			AddPotionRecipe(ItemType<BloodFlask>(), new int[] {ItemID.Mushroom, ItemID.Daybloom, ItemID.Blinkroot}, ItemID.RegenerationPotion);
		}

		public bool CraftPotion(int bottle, int catalyst, int[] ingredients) {
			for (int i = 0; i < potionRecipes.Count; i++) {
				if (potionRecipes[i].isSame(bottle, catalyst, ingredients)) {
					PotionRecipe p = potionRecipes[i];
					Main.LocalPlayer.QuickSpawnItem(p.resultId, p.stack);
					return true;
				}
			}
			return false;
		}

		public void AddPotionRecipe(int catalyst, int[] ingredients, int resultId, int stack = 1, int bottle = ItemID.Bottle) {
			potionRecipes.Add(new PotionRecipe(bottle, catalyst, ingredients, resultId, stack));
		}
	}


	public class PotionRecipe {
		private int bottle;
		private int catalyst;
		private int[] ingredients;
		public int resultId;
		public int stack;

		public PotionRecipe(int _bottle, int _catalyst, int[] _ingredients, int _resultId, int _stack = 1) {
			bottle = _bottle;
			catalyst = _catalyst;
			ingredients = _ingredients;
			resultId = _resultId;
			stack = _stack;
		}

		public bool isSame(int _bottle, int _catalyst, int[] _ingredients) {
			return (bottle == _bottle && catalyst == _catalyst && ingredients.SequenceEqual(_ingredients));
		}
	}
}