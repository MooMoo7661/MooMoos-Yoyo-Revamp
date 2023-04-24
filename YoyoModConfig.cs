using System.ComponentModel;
using Terraria.ModLoader.Config;


namespace CombinationsMod;
[Label("Mod Config")]

internal class YoyoModConfig : ModConfig
{
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Show Player String Color")]
        [Tooltip("Shows the internal color ID of the player's Yoyo string.\n(May not display the correct value with mods that use shaders on Yoyo Strings, or use detouring.)")]
        public bool YoyoStringStats { get; set; }

        [Label("Show Yoyo Projectile ID")]
        [Tooltip("Shows the internal ID of the projectile created by the held Yoyo.")]
        public bool YoyoProjectileID { get; set; }

        [Label("Vanilla Yoyo Effects")]
        [Tooltip("Enables/Disables Vanilla Yoyos from inheriting added effects by this mod.(Enabled by default)")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool VanillaYoyoEffects { get; set; }

        [Label("Main Yoyo Emits Dusts")]
        [Tooltip("For testing purposes. Creates dust around your main yoyo.(Disabled by default)")]
        [DefaultValue(false)]
        public bool MainYoyoDust { get; set; }
        
}