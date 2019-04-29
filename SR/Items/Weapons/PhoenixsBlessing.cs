using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using Terraria;

namespace SR.Items.Weapons
{
	public class PhoenixsBlessing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phoenix's Blessing");
            Tooltip.SetDefault("When you seem lost, a phoenix of the night swoops\nand helps you find your way, making your forlorn quest seem possible!");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.noMelee = true;
			item.magic = true;
			item.mana = 5;
			item.rare = 5;
			item.width = 60;
			item.height = 60;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 10;
			item.useAnimation = 20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PBProjectile");
			item.value = Item.sellPrice(gold: 3);
			Item.staff[item.type] = true;
		}

 		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)

        {
            int numberProjectiles = 6; // shoots 2 projectiles
            for (int index = 0; index < numberProjectiles; ++index)
            {
                Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
                vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                vector2_1.Y -= (float)(100 * index);
                float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if ((double)num13 < 0.0) num13 *= -1f;
                if ((double)num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                float num15 = item.shootSpeed / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + (float)Main.rand.Next(-40, 41) * 0.02f; //change the Main.rand.Next here to, for example, (-10, 11) to reduce the spread. Change this to 0 to remove it altogether
                float SpeedY = num17 + (float)Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
            }
            return false;
        }
		public override void AddRecipes()
		{
			ModRecipe r = new ModRecipe(mod);
			r.AddIngredient(ItemID.HellstoneBar, 5);
			r.AddIngredient(mod.ItemType("ElementiteBar"), 10);			
			r.AddTile(mod.TileType("ElementiteWorkbenchTile"));
			r.SetResult(this);
			r.AddRecipe();
		}
		
    }
}