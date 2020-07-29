using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Buffs
{
	public class Intoxication_4 : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Intoxication IV");
			Description.SetDefault("You're going to die");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex) {
            player.lifeRegen -= 32;
            player.statDefense -= 12;
		}
	}
}
