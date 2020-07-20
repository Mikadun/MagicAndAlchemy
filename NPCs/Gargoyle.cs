using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicAndAlchemy.NPCs
{
	// Gargoyle
	public class Gargoyle : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Gargoyle");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults() {
			npc.width = 38;
			npc.height = 50;
			npc.damage = 20;
			npc.defense = 20;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.GoblinWarrior;
			animationType = NPCID.Probe;
			/*
			banner = Item.NPCtoBanner(NPCID.Zombie);
			bannerItem = Item.BannerToItem(banner);
			*/
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Overworld.Chance * 0.8f;
		}

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
	}
}
