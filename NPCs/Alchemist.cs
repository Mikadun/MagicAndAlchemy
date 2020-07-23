using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;
using MagicAndAlchemy.Projectiles;

namespace MagicAndAlchemy.NPCs
{
	[AutoloadHead]
	public class Alchemist : ModNPC
	{
		public override string Texture => "MagicAndAlchemy/NPCs/Alchemist";

		public override bool Autoload(ref string name) {
			name = "Alchemist";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Alchemist");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 20;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}
        /*
		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<Sparkle>());
			}
		}
        */

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}
                return true;
			}
			return false;
		}

		public override string TownNPCName() {
			// Get random name on NPC
			WeightedRandom<string> name = new WeightedRandom<string>();
			name.Add("Harry");
			name.Add("Arnold");
			name.Add("Jerry");
			name.Add("Raiven");
			name.Add("Edison");
			name.Add("Garold");
			return name.Get();
		}

		public override string GetChat() {
			// Get random chat line
			WeightedRandom<string> chat = new WeightedRandom<string>();
			int wizard = NPC.FindFirstNPC(NPCID.Wizard);
			if (wizard >= 0) {
				chat.Add("I'm glad to see " + Main.npc[wizard].GivenName + " back");
			} 
			chat.Add("Potions? Yes, I have some");
			chat.Add("Did you know that if you mix mushrooms with blinkroot, you can see the future!");
			chat.Add("You won't see potions better than mine");
			return chat;
		}

		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			Main.playerInventory = true;
			Main.npcChatText = "";
			shop = true;
		}
        
		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ItemID.HealingPotion);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ManaPotion);
			nextSlot++;
		}

		/*
		public override void NPCLoot() {
			Item.NewItem(npc.getRect(), ItemType<Items.Armor.ExampleCostume>());
		}
        */

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toKingStatue) {
			return true;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 1f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}
		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileID.ToxicFlask;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}

	}
}
