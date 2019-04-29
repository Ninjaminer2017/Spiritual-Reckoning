using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SR.Items.Weapons
{
	public class SupaLaser : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Ima firin mah lazer");
		}

		public override void SetDefaults()
		{
			item.damage = 150;
			item.noMelee = true;
			item.magic = true;
			item.channel = true; //Channel so that you can held the weapon [Important]
			item.mana = 5;
			item.rare = 5;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SupaLaserBeam");
			item.value = Item.sellPrice(gold: 30);
		}
	}
}
