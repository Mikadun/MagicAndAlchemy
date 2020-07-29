using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Items.Weapons
{
	public class RitualDagger : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ritual Dagger");
			Tooltip.SetDefault("Used to take blood of your enemies if you have empty bottle.");
		}

		public override void SetDefaults() {
			item.damage = 14;
			item.melee = true;
			item.width = 28;
			item.height = 32;
			item.useTime = 15; 
			item.useAnimation = 15;
			item.knockBack = 3;
			item.value = Item.buyPrice(gold: 1);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 20;
			item.useStyle = ItemUseStyleID.Stabbing;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 7, 0, -0.5f, 100, Color.DarkRed, 0.75f);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			if (player.HasItem(ItemID.Bottle)) {
                int bottleIndex = player.FindItem(ItemID.Bottle);
                player.ConsumeItem(ItemID.Bottle);
                player.QuickSpawnItem(ItemType<BloodFlask>());
            }

		}
	}
}
