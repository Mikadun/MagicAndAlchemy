using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Items.Weapons
{
    class StampFireBlast : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.NebulaBlaze;
		public static Color OverrideColor = new Color(122, 173, 255);
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stamp Fire Blast");
        }

        public override void SetDefaults()
        {
            item.damage = 80;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.useTime = 15;
            item.useAnimation = 15;
            item.maxStack = 1;
            item.knockBack = 1.5f;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 10000;
            item.mana = 10;
            item.shoot = ProjectileType<Projectiles.FireBlast>();
            item.shootSpeed = 10f;
        }
    }
}