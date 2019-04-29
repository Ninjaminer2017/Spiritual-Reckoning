using System; //what sources the code uses, these sources allow for calling of terraria functions, existing system functions and microsoft vector functions (probably more)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SR.Items.Weapons
{
    public class Swordception : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swordception");
            Tooltip.SetDefault("Seems a bit excessive");
        }

        public override void SetDefaults()
        {
            item.width = 126;
            item.height = 126;
            item.value = 0150;
            item.rare = 4;
            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 15;
            item.knockBack = 6;
            item.useTurn = true;
            item.autoReuse = true;

            item.melee = true;
            item.damage = 200;
            item.crit = 10;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("SCeption_1");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			float numberProjectiles = 4 + Main.rand.Next(3); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SCeption_1"), damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SCeption_2"), damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SCeption_3"), damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SCeption_4"), damage, knockBack, player.whoAmI);
			}
            return true;
        }

        public override void AddRecipes()
		{
			ModRecipe r = new ModRecipe(mod);
			r.AddIngredient(mod.ItemType("ManaShard"), 30);			
			r.AddTile(mod.TileType("ElementiteWorkbenchTile"));
			r.SetResult(this);
			r.AddRecipe();
		}
    }
}
