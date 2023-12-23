using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CombinationsMod.Content.TrailSystem;

public static partial class Utils
{
    // primitive stuff
    public static bool HasBegun(this SpriteBatch spriteBatch)
    {
        return (bool)spriteBatch.GetType().GetField("beginCalled", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
    }
    public static void Reload(this SpriteBatch spriteBatch, BlendState state, SpriteSortMode mode = default)
    {
        if (spriteBatch.HasBegun())
            spriteBatch.End();
        if (mode == default) mode = (SpriteSortMode)spriteBatch.GetType().GetField("sortMode", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        var samplerState = (SamplerState)spriteBatch.GetType().GetField("samplerState", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        var depthStencilState = (DepthStencilState)spriteBatch.GetType().GetField("depthStencilState", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        var rasterizerState = (RasterizerState)spriteBatch.GetType().GetField("rasterizerState", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        var effect = (Effect)spriteBatch.GetType().GetField("customEffect", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        var transformMatrix = (Matrix)spriteBatch.GetType().GetField("transformMatrix", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(spriteBatch);
        spriteBatch.Begin(mode, state, samplerState, depthStencilState, rasterizerState, effect, transformMatrix);
    }
    private static int width;
    private static int height;
    private static Vector2 zoom;
    private static bool CheckGraphicsChanged()
    {
        var device = Main.graphics.GraphicsDevice;
        bool changed = device.Viewport.Width != width
                       || device.Viewport.Height != height
                       || Main.GameViewMatrix.Zoom != zoom;

        if (!changed) return false;

        width = device.Viewport.Width;
        height = device.Viewport.Height;
        zoom = Main.GameViewMatrix.Zoom;

        return true;
    }

    private static Matrix view;
    private static Matrix projection;
    public static Matrix GetMatrix()
    {
        if (CheckGraphicsChanged())
        {
            var device = Main.graphics.GraphicsDevice;
            int width = device.Viewport.Width;
            int height = device.Viewport.Height;
            Vector2 zoom = Main.GameViewMatrix.Zoom;
            view =
                Matrix.CreateLookAt(Vector3.Zero, Vector3.UnitZ, Vector3.Up)
                * Matrix.CreateTranslation(width / 2, height / -2, 0)
                * Matrix.CreateRotationZ(MathHelper.Pi)
                * Matrix.CreateScale(zoom.X, zoom.Y, 1f);
            projection = Matrix.CreateOrthographic(width, height, 0, 1000);
        }

        return view * projection;
    }
    public static IReadOnlyList<Vector2> Smoothen(IReadOnlyList<Vector2> positions, float smoothness)
    {
        if (positions.Count < 3) return new List<Vector2>(positions);
    
        var smoothed = new List<Vector2>();

        for (int i = 0; i < positions.Count - 1; i++)
        {
            if (i < 1 || i >= positions.Count - 2)
            {
                smoothed.Add(positions[i]);
                continue;
            }
            
            Vector2 p0 = positions[i - 1];
            Vector2 p1 = positions[i];
            Vector2 p2 = positions[i + 1];
            Vector2 p3 = positions[i + 2];

            for (float t = 0; t <= 1; t += smoothness)
            {
                float t2 = t * t;
                float t3 = t2 * t;

                // Catmull-Rom formula
                float tension = 0.5f; // You can adjust this parameter
                Vector2 point = 0.5f * (
                    (2.0f * p1) +
                    (-p0 + p2) * t +
                    (2.0f * p0 - 5.0f * p1 + 4.0f * p2 - p3) * t2 +
                    (-p0 + 3.0f * p1 - 3.0f * p2 + p3) * t3
                );

                smoothed.Add(point);
            }
        }

        return smoothed;
    }
}