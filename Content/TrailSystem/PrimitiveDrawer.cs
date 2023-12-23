using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CombinationsMod.Content.TrailSystem;

public enum DefaultIndices
{
    TriangleStrip = 0
}

public class PrimitiveDrawer
{
    private readonly DefaultIndices defaultIndices;
    private readonly PrimitiveType primitiveType;
    private short[] indices;
    private VertexPositionColorTexture[] vertices;

    public PrimitiveDrawer(int vertexCount, PrimitiveType type,
        DefaultIndices defaultIndices = DefaultIndices.TriangleStrip)
    {
        vertices = new VertexPositionColorTexture[vertexCount];
        indices = new short[vertexCount * 3];
        this.defaultIndices = defaultIndices;
        primitiveType = type;
    }

    public int VertexCount { get; private set; }

    public void Resize(int vertexCount)
    {
        VertexCount = 0;
        vertices = new VertexPositionColorTexture[vertexCount];
        indices = new short[vertexCount * 3];
    }

    public void AddVertex(Vector2 position, Color color, Vector2 uv)
    {
        var pos = new Vector3(position, 0);
        vertices[VertexCount] = new VertexPositionColorTexture(pos, color, uv);
        VertexCount++;
    }

    public void AddIndexes(short[] extra)
    {
        Array.Resize(ref indices, indices.Length + extra.Length);
        Array.Copy(extra, 0, indices, indices.Length - extra.Length, extra.Length);
    }

    public void PrepareIndices()
    {
        switch (defaultIndices)
        {
            case DefaultIndices.TriangleStrip:
                for (int i = 0; i < VertexCount / 2 - 1; i++)
                {
                    indices[i * 6] = (short)(i * 2);
                    indices[i * 6 + 1] = (short)(i * 2 + 1);
                    indices[i * 6 + 2] = (short)(i * 2 + 2);

                    indices[i * 6 + 3] = (short)(i * 2 + 2);
                    indices[i * 6 + 4] = (short)(i * 2 + 3);
                    indices[i * 6 + 5] = (short)(i * 2 + 1);
                }

                break;
        }
    }

    public void Draw()
    {
        if (VertexCount < 2) return;
        GraphicsDevice device = Main.graphics.GraphicsDevice;
        device.DrawUserIndexedPrimitives(primitiveType, vertices, 0, vertices.Length, indices, 0, indices.Length / 3);
    }
}