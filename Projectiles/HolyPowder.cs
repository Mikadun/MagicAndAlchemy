using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicAndAlchemy.Projectiles
{
    class HolyPowder : ModProjectile
    {
        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.PurificationPowder);
            aiType = ProjectileID.PurificationPowder;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if (target.type == NPCID.DungeonGuardian) {
                target.StrikeNPC((int)(1e6), 0, target.direction);
                NPC.downedBoss3 = true;
            }
        }
    }
}