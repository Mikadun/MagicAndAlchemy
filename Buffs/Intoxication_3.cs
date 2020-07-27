using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Buffs
{
	public class Intoxication_3 : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Intoxication III");
			Description.SetDefault("Health regeneration and defence is greatly lowered");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex) {
            player.lifeRegen -= 4;
            player.statDefense -= 4;
		}
	}
}
