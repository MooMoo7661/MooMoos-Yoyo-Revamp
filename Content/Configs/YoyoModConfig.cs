using System.ComponentModel;
using Terraria.ModLoader.Config;


namespace CombinationsMod.Content.Configs;
[Label("Mod Config")]

internal class YoyoModConfig : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("SmallChanges")]
    [Label("Show Player String Color")]
    [Tooltip("Shows the internal color ID of the player's Yoyo string.\n(May not display the correct value with mods that use shaders on Yoyo Strings, or use detouring.)")]
    public bool YoyoStringStats { get; set; }

    [Label("Show Yoyo Projectile ID")]
    [Tooltip("Shows the internal ID of the projectile created by the held Yoyo.")]
    public bool YoyoProjectileID { get; set; }

    [Label("Main Yoyo Emits Dusts")]
    [Tooltip("For testing purposes. Creates dust around your main yoyo.(Disabled by default)")]
    [DefaultValue(false)]
    public bool MainYoyoDust { get; set; }

    [Label("Changes to damage of vanilla yoyos")]
    [Tooltip("Enables/Disables the changes this mod makes to the stats of vanilla yoyos.(Enabled by default)")]
    [DefaultValue(true)]
    public bool VanillaYoyoDamageChanges { get; set; }

    [Label("Accessory slot indicators")]
    [Tooltip("Enables/Disables telling what type of item goes in which slot.(Enabled by default)")]
    [DefaultValue(true)]
    public bool AccessorySlotIndicators { get; set; }

    [Label("Move EOC Yoyo to post-twins")]
    [Tooltip("Enables/Disables moving the EOC Yoyo to drop from the twins instead of Mothrons.(Enabled by default)")]
    [DefaultValue(true)]
    public bool EOCYoyoProgressionMovement { get; set; }

    [Label("Increase the size of YoYo Glove sprite.(Enabled by default)")]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool UpscaleYoyoGlove { get; set; }

    //[Label("Position of Accessory Slots")]
    //[Increment(1)]
    //[Range(1, 4)]
    //[DefaultValue(1)]
    //[Slider]
    //public int AccessorySlotPosition { get; set; }

    [Header("LargeChanges")]
    [BackgroundColor(0, 255, 0)]
    [Label("Vanilla Yoyo Effects")]
    [Tooltip("Enables/Disables Vanilla Yoyos from inheriting added effects by this mod. (Enabled by default)")]
    [DefaultValue(true)]
    public bool VanillaYoyoEffects { get; set; }

    [BackgroundColor(255, 255, 0)]
    [Label("Modded Yoyos")]
    [Tooltip("Enables/Disables modded yoyos.(Enabled by default)")]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool LoadModdedYoyos { get; set; }

    [BackgroundColor(255, 255, 0)]
    [Label("Modded Accessories")]
    [Tooltip("Enables/Disables modded accessories. (Enabled by default)")]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool LoadModdedAccessories { get; set; }

    [BackgroundColor(255, 255, 0)]
    [Label("Changes to Yoyo Bag System")]
    [Tooltip("Enables/Disables new yoyo bag system. (Enabled by default)")]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool EnableModifiedYoyoBag { get; set; }

    [BackgroundColor(255, 0, 0)]
    [Label("Modded Items")]
    [Tooltip("Enables/Disables modded items. Includes yoyos and accessories. (Enabled by default)")]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool LoadModdedItems { get; set; }
}