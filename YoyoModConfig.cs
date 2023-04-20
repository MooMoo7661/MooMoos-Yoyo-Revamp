using System.ComponentModel;
using Terraria.ModLoader.Config;


namespace CombinationsMod;
[Label("Mod Config")]

internal class YoyoModConfig : ModConfig
{
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Show Player String Color")]
        [Tooltip("Shows the internal color ID of the player's Yoyo string.\n(May not display the correct value with mods that use shaders on Yoyo Strings, or use detouring.)")]
        [ReloadRequired]
        public bool YoyoStringStats { get; set; }

        [Label("Show Yoyo Projectile ID")]
        [Tooltip("Shows the internal ID of the projectile created by the held Yoyo.")]
        [ReloadRequired]
        public bool YoyoProjectileID { get; set; }

        [Label("Vanilla Yoyo Effects")]
        [Tooltip("Enables/Disables Vanilla Yoyos from inheriting added effects by this mod.(Enabled by default)")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool VanillaYoyoEffects { get; set; }

        [Label("Replace Yoyo Bag In Favor of Custom Mechanics")]
        [Tooltip("This includes Vanilla's Yoyo Glove, which is replaced with a custom one that looks identical." +
        "\n This is enabled by default, but if you wish to use other mods that require the yoyo glove, disable this.")]
        [DefaultValue(true)]
        [ReloadRequired] 
        public bool RemoveYoyoGlove { get; set; }
}