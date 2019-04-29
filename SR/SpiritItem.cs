using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;


namespace SR
{
    public abstract class SpiritItem : ModItem
    {
        public bool spirit = true;

        public override void SetDefaults()
        {
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null) {
				// We want to grab the last word of the tooltip, which is the translated word for 'damage' (depending on what langauge the player is using)
				// So we split the string by whitespace, and grab the last word from the returned arrays to get the damage word, and the first to get the damage shown in the tooltip
				string[] splitText = tt.text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
				// Change the tooltip text
				tt.text = damageValue + " Chaos " + damageWord;
			}
        }
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            SRPlayer modPlayer = player.GetModPlayer<SRPlayer>(mod);
            int originalDmg = damage;
            damage = (int)(damage * SRPlayer.chaosDamage);
            float globalDmg = 1;
            globalDmg = player.meleeDamage - 1;
            if(player.rangedDamage - 1 < globalDmg)
                globalDmg = player.rangedDamage - 1;
            if (player.magicDamage - 1 < globalDmg)
                globalDmg = player.magicDamage - 1;
            if (player.thrownDamage - 1 < globalDmg)
                globalDmg = player.thrownDamage - 1;
            if (player.minionDamage - 1 < globalDmg)
                globalDmg = player.minionDamage - 1;
            if (globalDmg > 1)
                damage = damage + (int)(originalDmg * globalDmg);
        }
    }
}