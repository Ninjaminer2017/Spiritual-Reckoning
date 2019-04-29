using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace SR.Items.Weapons
{
	public class HighTide : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Splish Splash i was takin a bath");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.noMelee = true;
			item.magic = true;
			item.mana = 3;
			item.rare = 5;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 7f;
			item.useAnimation = 20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ManaBubble");
			item.value = Item.sellPrice(gold: 3);
		}
	}
}