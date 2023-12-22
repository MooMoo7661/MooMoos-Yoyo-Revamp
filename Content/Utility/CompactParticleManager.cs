using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CombinationsMod.Content.Utility;

public class CompactParticle
{
    public Vector2 Position;
    public Vector2 Velocity;
    public float Rotation;
    public float Scale;
    public float Opacity;
    public float TimeAlive;
    public Color Color;
    public bool Dead;
}
public class CompactParticleManager
{
    private List<CompactParticle> particles = new List<CompactParticle>();
    private Action<CompactParticle> updateParticle;
    private Action<CompactParticle, SpriteBatch, Vector2> drawParticle;
    public CompactParticleManager(Action<CompactParticle> updateParticle, Action<CompactParticle, SpriteBatch, Vector2> drawParticle)
    {
        this.updateParticle = updateParticle;
        this.drawParticle = drawParticle;
    }
    public void AddParticle(Vector2 position, Vector2 velocity, float rotation, float scale, float opacity, Color color)
    {
        particles.Add(new CompactParticle
        {
            Position = position,
            Velocity = velocity,
            Rotation = rotation,
            Scale = scale,
            Opacity = opacity,
            TimeAlive = 0,
            Color = color
        });
    }
    public void Update()
    {
        for (int i = 0; i < particles.Count; i++)
        {
            CompactParticle particle = particles[i];
            updateParticle(particle);
            particle.TimeAlive++;
            if (particle.Dead)
            {
                particles.RemoveAt(i);
                i--;
            }
        }
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 anchor)
    {
        for (int i = 0; i < particles.Count; i++)
        {
            CompactParticle particle = particles[i];
            drawParticle(particle, spriteBatch, anchor);
        }
    }
}