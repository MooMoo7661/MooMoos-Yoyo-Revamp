using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Terraria;

public static class VectorHelper
{


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Normalized(this Vector2 vec)
    {
        return vec.SafeNormalize(Vector2.Zero);
    }

    public static Vector2 Random => new Vector2(Main.rand.NextFloat(1f), Main.rand.NextFloat(1f));

    public static Vector2 Up => new Vector2(0f, -1f);

    public static Vector2 UpLeft => new Vector2(-1f, -1f);

    public static Vector2 UpRight => new Vector2(1f, -1f);

    public static Vector2 Down => new Vector2(0f, 1f);

    public static Vector2 DownLeft => new Vector2(-1f, 1f);

    public static Vector2 DownRight => new Vector2(1f, 1f);

    public static Vector2 Left => new Vector2(-1f, 0f);

    public static Vector2 Right => new Vector2(1f, 0f);

    public static Vector2 Circular = Vector2.One.RotatedByRandom(MathHelper.TwoPi);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 VelocityToPoint(Vector2 A, Vector2 B, float speed)
    {
        Vector2 vector = B - A;
        vector *= speed / vector.Length();
        if (!vector.HasNaNs())
        {
            return vector;
        }
        return Vector2.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Angle(Vector2 a, Vector2 b)
    {
        return (b - a).ToRotation();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 RandomPointInArea(Vector2 A, Vector2 B)
    {
        return new Vector2(Main.rand.Next((int)A.X, (int)B.X) + 1, Main.rand.Next((int)A.Y, (int)B.Y) + 1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 PermutateVelocity(float speedX, float speedY, double amount, float multiplierMin = 1f, float multiplierMax = 1f)
    {
        return new Vector2(speedX, speedY).RotatedByRandom(amount) * ((multiplierMin != multiplierMax) ? Main.rand.NextFloat(multiplierMin, multiplierMax) : multiplierMin);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PermutateVelocity(ref float speedX, ref float speedY, double amount, float multiplierMin = 1f, float multiplierMax = 1f)
    {
        Vector2 vector = PermutateVelocity(speedX, speedY, amount, multiplierMin, multiplierMax);
        speedX = vector.X;
        speedY = vector.Y;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Distance(this Vector2 v, Vector2 To)
    {
        float num = Vector2.Distance(v, To);
        if (!float.IsNaN(num))
        {
            return num;
        }
        return 0f;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 GetPosition(this Rectangle rect)
    {
        return new Vector2(rect.X, rect.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Offseted(this Vector2 vec, float x, float y = 0f)
    {
        return new Vector2(vec.X + x, vec.Y + y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Normal(this Vector2 vec)
    {
        return new Vector2(0f - vec.Y, vec.X);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ToColor(this Vector3 vec, float alpha = 1f)
    {
        return new Color(vec.X, vec.Y, vec.Z, alpha);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 DirectionTo(this Vector2 origin, Vector2 target)
    {
        return Vector2.Normalize(target - origin);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPastPosition(this Vector2 vel, Vector2 origin, Vector2 target)
    {
        if (Math.Sign(vel.X) == origin.X.CompareTo(target.X))
        {
            return Math.Sign(vel.Y) == origin.Y.CompareTo(target.Y);
        }
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Deconstruct(this Vector2 vec, out float x, out float y)
    {
        x = vec.X;
        y = vec.Y;
    }
}