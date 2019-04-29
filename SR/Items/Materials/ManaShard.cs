using Terraria.ModLoader;
using Terraria.ID;

namespace SR.Items.Materials
{
    public class ManaShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mana Shard");
            Tooltip.SetDefault("A fragment containing a small amount of energy");
        }

        public override void SetDefaults()
        {
            item.width = 8;
            item.height = 8;
            item.useStyle = 1;
            item.value = 100;
            item.rare = 4;
            item.maxStack = 999;
        }
    }
}