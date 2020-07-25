using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Items
{
	public class TransGem : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem of Transmutation");
			Tooltip.SetDefault("This will help you become a true alchemist!");
		}

		public override void SetDefaults()
        {
			item.width = 35;
			item.height = 27;
			item.maxStack = 99;
			item.value = Item.buyPrice(silver: 75);
			item.rare = ItemRarityID.Blue;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Items.EyeGem>());
            recipe.AddTile(TileType<Tiles.AlchemicalAltar>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Items.BrainGem>());
            recipe.AddTile(TileType<Tiles.AlchemicalAltar>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Items.AncestorGem>());
            recipe.AddTile(TileType<Tiles.AlchemicalAltar>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Items.EaterGem>());
            recipe.AddTile(TileType<Tiles.AlchemicalAltar>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}