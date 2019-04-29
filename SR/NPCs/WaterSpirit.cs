using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SR.NPCs
{
    public class WaterSpirit : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Spirit");
        }

        public override void SetDefaults()
        {
            npc.width = 70;
            npc.height = 46;
            npc.damage = 10;
            npc.defense = 5;
            npc.lifeMax = 40;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 150f;
            npc.knockBackResist = 0.25f;
            npc.aiStyle = 14;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[2]; //Main.npcFrameCount[2];
            aiType = 2; // aiType = 2;
            animationType = 2; // animationType = 2;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!SRWorld.downedSpindlewheel == true) 
            {
                return SpawnCondition.Ocean.Chance * 5f;
            }
            else
            {
                return SpawnCondition.Ocean.Chance * 0;
            }
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ElementiteOre"), Main.rand.Next(1, 4));
        }
    }
}