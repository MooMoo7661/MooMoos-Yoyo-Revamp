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
    [Header("LargeChanges")]
    [DefaultValue(true)]
    public bool VanillaYoyoEffects { get; set; }

    [DefaultValue(true)]
    [ReloadRequired]
    public bool LoadModdedYoyos { get; set; }

    [DefaultValue(true)]
    [ReloadRequired]
    public bool LoadModdedAccessories { get; set; }

    [DefaultValue(true)]
    [ReloadRequired]
    public bool EnableModifiedYoyoBag { get; set; }

    [DefaultValue(true)]
    [ReloadRequired]
    public bool LoadModdedItems { get; set; }

    [Header("YoyoStats")]
    [DefaultValue(true)]
    public bool YoyoSpeed { get; set; }
    [DefaultValue(true)]
    public bool YoyoRange { get; set; }
    [DefaultValue(true)]
    public bool YoyoLifetime { get; set; }
    [DefaultValue(true)]
    public bool MaxHits { get; set; }
}