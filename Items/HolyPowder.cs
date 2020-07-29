using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MagicAndAlchemy.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Items
{
	public class HolyPowder : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Powder");
			Tooltip.SetDefault("Master of Undead can't resist this power");
		}

		public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.PurificationPowder);
			item.width = 32;
			item.height = 26;
			item.maxStack = 999;
			item.value = Item.buyPrice(silver: 1);
            item.thrown = true;
            item.damage = 5;
			item.rare = ItemRarityID.Blue;
            item.shoot = ProjectileType<Projectiles.HolyPowder>();
            item.shootSpeed = 5f;
        }
    }
}