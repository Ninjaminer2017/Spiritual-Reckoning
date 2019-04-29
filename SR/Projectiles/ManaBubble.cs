using System; //what sources the code uses, these sources allow for calling of terraria functions, existing system functions and microsoft vector functions (probably more)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SR.Projectiles //where it's stored. Replace Mod with the name of your mod. This file is stored in the folder \Mod Sources\(mod name, folder can't have spaces)\Projectiles.
{
    public class ManaBubble : ModProjectile //the class of the projectile
    {
        public float ReverseTimer = 50f;
        public override void SetDefaults()
        {
            projectile.width = 16; //sprite is 2 pixels wide
            projectile.height = 16; //sprite is 20 pixels tall
            projectile.aiStyle = 0; //projectile moves in a straight line
            projectile.friendly  = true; //player projectile
            projectile.thrown = true; //ranged projectile
            projectile.timeLeft = 720; //lasts for 600 frames/ticks. Terraria runs at 60FPS, so it lasts 10 seconds.
            projectile.tileCollide = false;
            projectile.penetrate = 999;
          
        }
        
        public override void AI()
        {
            if(ReverseTimer > 0)
            {
                ReverseTimer -= 1f;
            }
            if(projectile.velocity.X + projectile.velocity.Y > 0f && ReverseTimer == 0f)
            {
                projectile.velocity.X *= -1f; 
                projectile.velocity.Y *= -1f;
                ReverseTimer = 100f;
            }
            if(projectile.velocity.X + projectile.velocity.Y < 0f && ReverseTimer == 0f)
            {
                projectile.velocity.X *= -1f; 
                projectile.velocity.Y *= -1f;
                ReverseTimer = 100f;
            }
        } 
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}