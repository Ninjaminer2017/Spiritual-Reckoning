using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
namespace SR
{
    public class SRWorld : ModWorld
    {
        public static bool downedSpindlewheel = false;
        public override void Initialize() 
        {
            downedSpindlewheel = false;
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Legacy Message", delegate (GenerationProgress progress)
            {
                progress.Message = "Solidifying Elemental Energy";
               
                for (int k = 0; k < (int)((double)(WorldGen.rockLayer * Main.maxTilesY) * 60E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lower value if you want less vains ore or higher value for more veins ore
                {
                    int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 200); //this is the coordinates where the veins ore will spawn, so in Cavern layer
                    WorldGen.OreRunner(X, Y, WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(5, 12), (ushort)mod.TileType("ElementiteOreTile"));   //WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9) is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, mod.TileType("CustomOreTile") is the custom tile that will spawn
                }
            }));
        }
    }
}