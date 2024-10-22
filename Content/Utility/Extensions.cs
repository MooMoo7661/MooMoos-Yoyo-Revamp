using System;
using CombinationsMod.Content.Global_Classes.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using static CombinationsMod.Content.ModSystems.CombinationsModSystem;
using static MooMooLib.MooMooLibModsystem;

namespace CombinationsMod.Content.Utility
{
    public static class Extensions
    {
        /// <summary>
        /// Returns a string converted to a specific color depending on hex.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="hex">The hex you want to color the string as.</param>
        /// <returns></returns>
        public static string ToHexString(this string text, string hex)
        {
            return "[c/" + hex + ":" + text + "]";
        }

        /// <summary>
        /// Takes in a Color, and returns a formatted string with the proper Hex value to color the string as.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color">The color you want the text to be.</param>
        /// <returns></returns>
        public static string ToHexString(this string text, Color color)
        {
            return "[c/" + color.Hex3() + ":" + text + "]";
        }

        public static NPCShop AddWithValue(this NPCShop shop, int itemType, int customValue, params Condition[] conditions)
        {
            var item = new Item(itemType)
            {
                shopCustomPrice = customValue
            };

            return shop.Add(item, conditions);
        }

        public static bool IsYoyo(this Projectile projectile)
        {
            return projectile.aiStyle == 99 && !projectile.counterweight;
        }

        public static bool IsCounterweight(this Projectile projectile)
        {
            return projectile.aiStyle == 99 && projectile.counterweight;
        }

        public static YoyoDataHouse YoyoData(this Projectile projectile)
        {
            if (projectile.aiStyle != 99)
                throw new Exception("Attempted to get data from a non-yoyo projectile. Projectile type: " + projectile.Name);

            if (!projectile.TryGetGlobalProjectile<YoyoDataHouse>(out _))
                throw new Exception("Could not find data house for yoyo projectile!");

            return projectile.GetGlobalProjectile<YoyoDataHouse>();
        }

        public static Player GetOwner(this Projectile projectile)
        {
            return Main.player[projectile.owner];
        }

        public static void Register(this StringColor stringColor, Color color, int idx)
        {
            stringColor.setStringColor(color);
            yoyoStringColorDictionary.TryAdd(idx, stringColor);
        }

        public static void Register(this StringTexture stringTexture, Asset<Texture2D> tex, int idx)
        {
            stringTexture.setStringTexture(tex);
            yoyoStringDictionary.TryAdd(idx, stringTexture);
        }

        public static void Register(this LocalizedAbilityString abilityString, string value, int item)
        {
            abilityString.SetStringValue(value);
            yoyoAbilityDictionary.TryAdd(item, abilityString);
        }
    }
}
