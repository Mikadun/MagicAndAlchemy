using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicAndAlchemy.NPCs
{
	public class Gargoyle : ModNPC
	{
		private float speed = 1.5f;
		private float animationDelay = 10f;
		private float acceleration = 0.1f;
		private int walkAnimationFramesCount = 3;

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Gargoyle");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.width = 52;
			npc.height = 40;
			npc.damage = 20;
			npc.defense = 20;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = -1;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Overworld.Chance * 0.2f;
		}

		public override void AI() {
			npc.TargetClosest(false);
			if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 150f) {
				npc.ai[0] = 1;
				npc.TargetClosest(true);
				npc.velocity.X += acceleration * npc.direction;
			} else {
				npc.ai[0] = 0;
				npc.velocity = Vector2.Zero;
			}

			if (Math.Abs(npc.velocity.X) > speed) {
				npc.velocity.X = npc.direction * speed;
			}
		}

		public override void FindFrame(int frameHeight) {
			npc.spriteDirection = npc.direction;
			npc.frameCounter++;
			if (npc.ai[0] == 0) {
				npc.frame.Y = 0 * frameHeight;
			}
			else if (npc.ai[0] == 1) {
				if (npc.frameCounter < animationDelay) {
					npc.frame.Y = 1 * frameHeight;
				} else if (npc.frameCounter < 2 * animationDelay) {
					npc.frame.Y = 2 * frameHeight;
				} else {
					npc.frame.Y = 3 * frameHeight;
				}
			}

			if (npc.frameCounter > walkAnimationFramesCount * animationDelay) {
				npc.frameCounter = 0f;
			}
		}
	}
}
