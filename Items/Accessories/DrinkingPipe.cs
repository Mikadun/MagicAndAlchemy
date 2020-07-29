using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MagicAndAlchemy.Buffs;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Items.Accessories
{
	public class DrinkingPipe : ModItem
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Potion drinking pipe");
			Tooltip.SetDefault("Intoxication debuff makes you stronger");
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
			if (player.HasBuff(BuffType<Intoxication_1>())) {
				player.lifeRegen += 8;
				player.statDefense += 2;
			} else if (player.HasBuff(BuffType<Intoxication_2>())) {
				player.lifeRegen += 14;
				player.statDefense += 8;
			} else if (player.HasBuff(BuffType<Intoxication_3>())) {
				player.lifeRegen += 24;
				player.statDefense += 14;
			} else if (player.HasBuff(BuffType<Intoxication_4>())) {
				player.lifeRegen += 52;
				player.statDefense += 24;
			}
		}
    }
}