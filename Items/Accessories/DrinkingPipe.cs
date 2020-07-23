using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicAndAlchemy.Items.Accessories
{
	public class DrinkingPipe : ModItem
	{
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Descreases intoxication");
        } 
		public override void SetDefaults() {
			item.width = 32;
			item.height = 20;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 10);
			item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			// 50% melee and ranged damage increase
			player.meleeDamage += 0.5f;
		}
    }
}