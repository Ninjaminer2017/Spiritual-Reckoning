using Terraria.ModLoader;

namespace SR
{
	public class SR : Mod
	{
		public SR()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadBackgrounds = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
