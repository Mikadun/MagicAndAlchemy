using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Buffs
{
	public class Intoxication : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Intoxication");
			Description.SetDefault("Health regeneration is slightly lowered");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
		
		public override void Update(Player player, ref int buffIndex) {
            player.DelBuff(buffIndex);
			int time = 5 * 60;
			int minStageOfDebuff = BuffType<Intoxication_1>();
			int maxStageOfDebuff = BuffType<Intoxication_4>();
            int stageOfDebuff = 0;
			for (int i = maxStageOfDebuff; i >= minStageOfDebuff; i--) {
				if (player.HasBuff(i)) {
					stageOfDebuff = Math.Max(stageOfDebuff, i);
					int deleteBuffIndex = player.FindBuffIndex(i);
					player.DelBuff(deleteBuffIndex);
				}
			}
            
			if (stageOfDebuff == maxStageOfDebuff) {
				player.AddBuff(maxStageOfDebuff, time, false);
			} else if (stageOfDebuff == 0) {
                player.AddBuff(minStageOfDebuff, time, false);
			} else {
				player.AddBuff(stageOfDebuff + 1, time, false);
            }
		}

		public static bool PlayerHasIntoxication(Player player) {
			int minStageOfDebuff = BuffType<Intoxication_1>();
			int maxStageOfDebuff = BuffType<Intoxication_4>();
			for (int i = maxStageOfDebuff; i >= minStageOfDebuff; i--) {
				if (player.HasBuff(i)) {
					return true;
				}
			}
			return false;
		}
	}
}
