using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SR.NPCs
{
    public class FlameSpirit : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame Spirit");
        }

        public override void SetDefaults()
        {
            npc.width = 70;
            npc.height = 46;
            npc.damage = 20;
            npc.defense = 0;
            npc.lifeMax = 50;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 150f;
            npc.knockBackResist = 0.25f;
            npc.aiStyle = 14;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[2]; //Main.npcFrameCount[2];
            aiType = 2; // aiType = 2;
            animationType = 2; // animationType = 2;
            npc.lavaImmune = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            
            if (!SRWorld.downedSpindlewheel == true) 
            {
                return SpawnCondition.Underworld.Chance * 5f;
            }
            else
            {
                return SpawnCondition.Underworld.Chance * 0;
            }
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ElementiteOre"), Main.rand.Next(1, 4));
        }
    }
}