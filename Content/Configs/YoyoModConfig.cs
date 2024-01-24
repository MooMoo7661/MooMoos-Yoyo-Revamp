using System.ComponentModel;
using Terraria.ModLoader.Config;
namespace CombinationsMod.Content.Configs;

internal class YoyoModConfig : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("SmallChanges")]
    public bool YoyoStringStats { get; set; }

    public bool YoyoProjectileID { get; set; }

    [DefaultValue(false)]
    public bool MainYoyoDust { get; set; }

    [DefaultValue(true)]
    public bool VanillaYoyoDamageChanges { get; set; }

    [DefaultValue(true)]
    public bool AccessorySlotIndicators { get; set; }

    [DefaultValue(true)]
    public bool EOCYoyoProgressionMovement { get; set; }

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
    [DefaultValue(true)]
    public bool VanillaYoyoEffects { get; set; }

    [BackgroundColor(255, 255, 0)]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool LoadModdedYoyos { get; set; }

    [BackgroundColor(255, 255, 0)]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool LoadModdedAccessories { get; set; }

    [BackgroundColor(255, 255, 0)]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool EnableModifiedYoyoBag { get; set; }

    [BackgroundColor(255, 0, 0)]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool LoadModdedItems { get; set; }
}