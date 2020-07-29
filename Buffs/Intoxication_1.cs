using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.Buffs
{
	public class Intoxication_1 : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Intoxication I");
			Description.SetDefault("Health regeneration is slightly lowered");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
		
		public override void Update(Player player, ref int buffIndex) {
            player.lifeRegen -= 4;
		}
	}
}
