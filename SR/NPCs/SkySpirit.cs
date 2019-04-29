using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SR.NPCs
{
    public class SkySpirit : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky Spirit");
        }

        public override void SetDefaults()
        {
            npc.width = 44;
            npc.height = 20;
            npc.damage = 10;
            npc.defense = 20;
            npc.lifeMax = 150;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 150f;
            npc.knockBackResist = 0.25f;
            npc.aiStyle = 14;
            Main.npcFrameCount[npc.type] = 6; //Main.npcFrameCount[2];
            aiType = 5; // aiType = 2;
            animationType = 6; // animationType = 2;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!SRWorld.downedSpindlewheel == true) 
            {
                return SpawnCondition.Sky.Chance * 5f;
            }
            else
            {
                return SpawnCondition.Sky.Chance * 0;
            }
        }       
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ElementiteOre"), Main.rand.Next(1, 4));
        }
    }
}