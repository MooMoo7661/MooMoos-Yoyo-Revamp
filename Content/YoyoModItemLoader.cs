using System.Globalization;
using CombinationsMod.Content.Configs;
using Terraria.ModLoader;

namespace CombinationsMod.Content
{
    public abstract class ModDrill : ModItem
    {
        [CloneByReference]
        public abstract int DrillProjectile { get; }
    }

    public interface IYoyoUpgrade
    {
        LocalizedText Description { get; }

        void ApplyEffects(Projectile proj) { }

        void ApplyOnHitEffect(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone) { }

        void AI(Projectile proj) { }
    }
}
