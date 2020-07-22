using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicAndAlchemy.NPCs
{
	// Gargoyle enemy NPC
	public class Gargoyle : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Gargoyle");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults() {
			npc.width = 74;
			npc.height = 54;
			npc.damage = 20;
			npc.defense = 20;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
<<<<<<< HEAD
			npc.aiStyle = 3;
			aiType = NPCID.Mummy;
			animationType = NPCID.Probe;
			/*
			banner = Item.NPCtoBanner(NPCID.Zombie);
			bannerItem = Item.BannerToItem(banner);
			*/
=======
			npc.aiStyle = -1; // unique AI style
			//animationType = NPCID.SlimeSpiked;
>>>>>>> f3104b13af378d9bc606085ffdc50804547b379e
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Overworld.Chance * 0.2f;
		}

		/*
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 10; i++) {
				int dustType = Main.rand.Next(139, 143);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		*/

		public override void AI() {
			npc.TargetClosest(false);
			if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 150f) {
				npc.ai[0] = 1;
				npc.TargetClosest(true);
				npc.velocity = new Vector2(2 * npc.direction, 0f);
			} else {
				npc.ai[0] = 0;
				npc.velocity = Vector2.Zero;
			}
		}

		public override void FindFrame(int frameHeight) {
			npc.spriteDirection = npc.direction;
			npc.frameCounter++;
			if (npc.ai[0] == 0) {
				npc.frame.Y = 0;
			}
			else if (npc.ai[0] == 1) {
				npc.frame.Y = frameHeight;
			}

			if (npc.frameCounter > 64.0) {
				npc.frameCounter = 0f;
			}
		}
	}
}
