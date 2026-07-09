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
        /// <summary>
        /// Apply effects when the projectile spawns.
        /// </summary>
        /// <param name="projectile"></param>
        void ApplyEffects(Projectile projectile) { }

        /// <summary>
        /// OnHitNPC clone.
        /// </summary>
        void ApplyOnHitEffect(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone) { }

        void AI(Projectile projectile) { }
    }
}
