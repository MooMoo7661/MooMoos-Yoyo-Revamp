using CombinationsMod.Content.Configs;
using CombinationsMod.Content.ModPlayers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Global_Classes.Projectiles
{
    public class YoyoAIModifications : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.aiStyle == 99;
        }

        public bool mainYoyo = false; // false = main yoyo, true = second yoyo

        public override void Load()
        {
            Terraria.On_Projectile.AI_099_2 += YoyoAIDetour;
        }

        public override void Unload()
        {
            Terraria.On_Projectile.AI_099_2 -= YoyoAIDetour;
        }

        private void YoyoAIDetour(Terraria.On_Projectile.orig_AI_099_2 orig, Projectile projectile)
        {
            Player player = Main.player[projectile.owner];

            mainYoyo = false;

            for (int i = 0; i < projectile.whoAmI; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == projectile.owner && Main.projectile[i].aiStyle == 99 && !Main.projectile[i].counterweight)
                {
                    mainYoyo = true;
                }
            }

            if (projectile.owner == Main.myPlayer)
            {
                projectile.localAI[0] += 1f; // Timer in ticks

                if (mainYoyo)
                {
                    projectile.localAI[0] += (float)Main.rand.Next(10, 31) * 0.1f;
                }

                float num = projectile.localAI[0] / 60f; // Timer in seconds

                num /= (1f + Main.player[projectile.owner].GetAttackSpeed(DamageClass.Melee)) / 2f;

                float num2 = ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type];

                if (num2 != -1f && num > num2)
                {
                    projectile.ai[0] = -1f; // Sets when the yoyo is killed
                }
            }

            if (projectile.type == 603 && projectile.owner == Main.myPlayer) // All of this is for terrarian's homing orbs
            {
                projectile.localAI[1] += 1f;
                if (projectile.localAI[1] >= 6f)
                {
                    float num3 = 400f;
                    Vector2 vector = projectile.velocity;
                    Vector2 vector2 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    vector2.Normalize();
                    vector2 *= (float)Main.rand.Next(10, 41) * 0.1f;
                    if (Main.rand.NextBool(3))
                    {
                        vector2 *= 2f;
                    }
                    vector *= 0.25f;
                    vector += vector2;
                    for (int j = 0; j < 200; j++)
                    {
                        if (Main.npc[j].CanBeChasedBy(this))
                        {
                            float num4 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                            float num5 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                            float num6 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num4) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num5);
                            if (num6 < num3 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[j].position, Main.npc[j].width, Main.npc[j].height))
                            {
                                num3 = num6;
                                vector.X = num4;
                                vector.Y = num5;
                                vector -= projectile.Center;
                                vector.Normalize();
                                vector *= 8f;
                            }
                        }
                    }
                    vector *= 0.8f; // Terrarian Beam
                    Projectile.NewProjectile(Projectile.InheritSource(projectile), projectile.Center.X - vector.X, projectile.Center.Y - vector.Y, vector.X, vector.Y, 604, projectile.damage, projectile.knockBack, projectile.owner);
                    projectile.localAI[1] = 0f;
                }
            }

            bool isCounterweight = false;

            if (projectile.counterweight) // Setting the counterweight flag depending on the projectile
            {
                isCounterweight = true;
                Main.NewText("Counterweight was true on " + projectile.Name);
            }

            if (Main.player[projectile.owner].dead) // Kill projectile when projectile.owner is dead
            {
                projectile.Kill();
                return;
            }

            if (!isCounterweight && !mainYoyo) // if not counterweight and current yoyo
            {
                Main.player[projectile.owner].heldProj = projectile.whoAmI;
                Main.player[projectile.owner].GetModPlayer<YoyoModPlayer>().currentYoyo = projectile.whoAmI;
                //projectile.localAI[0] = -1;

                if (ModContent.GetInstance<YoyoModConfig>().MainYoyoDust)
                {
                    if (Main.rand.NextBool(5))
                    {
                        int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height,
                        DustID.CrimsonTorch, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 200, default, 0.7f);
                        Main.dust[dust].noLight = true;
                        Main.dust[dust].scale = 1.3f;
                    }
                }

                Main.player[projectile.owner].SetDummyItemTime(2);

                // Below 2 set the player's direction depending on where the yoyo is (left, right)
                if (projectile.position.X + (float)(projectile.width / 2) > Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2))
                {
                    Main.player[projectile.owner].ChangeDir(1);
                    projectile.direction = 1;
                }
                else
                {
                    Main.player[projectile.owner].ChangeDir(-1);
                    projectile.direction = -1;
                }
            }

            // If somehow the yoyo's velocity gets super high or fucked up, kill it
            if (projectile.velocity.HasNaNs())
            {
                projectile.Kill();
            }

            projectile.timeLeft = 6;
            float stringLength = ProjectileID.Sets.YoyosMaximumRange[projectile.type];

            float yoyoSpeed = player.GetModPlayer<YoyoModPlayer>().GetModifiedPlayerYoyoSpeed(ProjectileID.Sets.YoyosTopSpeed[projectile.type], player);
            float modifiedStringLength = Main.player[projectile.owner].GetModPlayer<YoyoModPlayer>().GetModifiedPlayerYoyoStringLength(stringLength, player);

            if (projectile.type == 545) // Cascade dusts
            {
                if (Main.rand.NextBool(6))
                {
                    int num11 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
                    Main.dust[num11].noGravity = true;
                }
            }
            else if (projectile.type == 553 && Main.rand.NextBool(2)) // Hel-Fire dusts
            {
                int num12 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
                Main.dust[num12].noGravity = true;
                Main.dust[num12].scale = 1.6f;
            }
            if (Main.player[projectile.owner].yoyoString) // Extends range
            {
                // modifiedStringLength is ProjectileID.Sets.YoyosMaximumRange + modifictions from modplayer to increase range
                modifiedStringLength += 150f;
            }

            modifiedStringLength *= (1f + Main.player[projectile.owner].GetAttackSpeed(DamageClass.Melee) * 3f) / 4f;
            //modifiedStringLength = 120f + modifiedStringLength / 5;
            yoyoSpeed *= (1f + Main.player[projectile.owner].GetAttackSpeed(DamageClass.Melee) * 3f) / 4f;
            float num7 = 14f - yoyoSpeed / 2f;
            if (num7 < 1f)
            {
                num7 = 1f;
            }
            float num9 = 5f + yoyoSpeed / 2f;
            if (mainYoyo)
            {
                //ABILITY - EXTENDED REACH : Yoyo range is greatly increased with second ai. Change 20f to 100f+
                if (player.GetModPlayer<YoyoModPlayer>().moonTrick) { num9 += 150f; }
                else { num9 += 20f; }
            }
            if (projectile.ai[0] >= 0f)
            {
                if (projectile.velocity.Length() > yoyoSpeed)
                {
                    projectile.velocity *= 0.98f;
                }
                bool flag3 = false;
                bool flag4 = false;
                Vector2 vector3 = Main.player[projectile.owner].Center - projectile.Center;
                if (vector3.Length() > modifiedStringLength)
                {
                    flag3 = true;
                    if ((double)vector3.Length() > (double)modifiedStringLength * 1.3)
                    {
                        flag4 = true;
                    }
                }
                if (projectile.owner == Main.myPlayer)
                {
                    if (!Main.player[projectile.owner].channel || Main.player[projectile.owner].stoned || Main.player[projectile.owner].frozen)
                    {
                        projectile.ai[0] = -1f; // ai[0] = -1 kills projectile. I assume this is to recall yoyos when the player is dead / should not be active
                        projectile.ai[1] = 0f;
                        projectile.netUpdate = true;
                    }
                    else
                    {
                        // Makes it so the controls aren't fucked up when the player is upside down
                        Vector2 vector4 = Main.ReverseGravitySupport(Main.MouseScreen) + Main.screenPosition;
                        float x = vector4.X;
                        float y = vector4.Y;
                        Vector2 vector5 = new Vector2(x, y) - Main.player[projectile.owner].Center;
                        if (vector5.Length() > modifiedStringLength)
                        {
                            vector5.Normalize();
                            vector5 *= modifiedStringLength;
                            vector5 = Main.player[projectile.owner].Center + vector5;
                            x = vector5.X;
                            y = vector5.Y;
                        }
                        if (projectile.ai[0] != x || projectile.ai[1] != y)
                        {
                            // Limit the range for the yoyo
                            Vector2 vector6 = new Vector2(x, y) - Main.player[projectile.owner].Center;
                            if (vector6.Length() > modifiedStringLength - 1f)
                            {
                                vector6.Normalize();
                                vector6 *= modifiedStringLength - 1f;
                                Vector2 vector7 = Main.player[projectile.owner].Center + vector6;
                                x = vector7.X;
                                y = vector7.Y;
                            }

                            // Sets the ai values equal to the X and Y pos
                            projectile.ai[0] = x;
                            projectile.ai[1] = y;
                            projectile.netUpdate = true;
                        }
                    }
                }
                if (flag4 && projectile.owner == Main.myPlayer)
                {
                    projectile.ai[0] = -1f;
                    projectile.netUpdate = true;
                }
                if (projectile.ai[0] >= 0f)
                {
                    if (flag3)
                    {
                        num7 /= 2f;
                        yoyoSpeed *= 2f;
                        if (projectile.Center.X > Main.player[projectile.owner].Center.X && projectile.velocity.X > 0f)
                        {
                            projectile.velocity.X *= 0.5f;
                        }
                        if (projectile.Center.Y > Main.player[projectile.owner].Center.Y && projectile.velocity.Y > 0f)
                        {
                            projectile.velocity.Y *= 0.5f;
                        }
                        if (projectile.Center.X < Main.player[projectile.owner].Center.X && projectile.velocity.X < 0f)
                        {
                            projectile.velocity.X *= 0.5f;
                        }
                        if (projectile.Center.Y < Main.player[projectile.owner].Center.Y && projectile.velocity.Y < 0f)
                        {
                            projectile.velocity.Y *= 0.5f;
                        }
                    }
                    Vector2 vector8 = new Vector2(projectile.ai[0], projectile.ai[1]) - projectile.Center;
                    if (flag3)
                    {
                        num7 = 1f;
                    }
                    projectile.velocity.Length();
                    float num13 = vector8.Length();
                    if (num13 > num9)
                    {
                        vector8.Normalize();
                        float num14 = Math.Min(num13 / 2f, yoyoSpeed);
                        if (flag3)
                        {
                            num14 = Math.Min(num14, yoyoSpeed / 2f);
                        }
                        vector8 *= num14;
                        projectile.velocity = (projectile.velocity * (num7 - 1f) + vector8) / num7;
                    }
                    else if (mainYoyo)
                    {
                        if ((double)projectile.velocity.Length() < (double)yoyoSpeed * 0.6)
                        {
                            vector8 = projectile.velocity;
                            vector8.Normalize();
                            vector8 *= yoyoSpeed * 0.6f;
                            projectile.velocity = (projectile.velocity * (num7 - 1f) + vector8) / num7;
                        }
                    }
                    else
                    {
                        projectile.velocity *= 0.8f;
                    }
                    if (mainYoyo && !flag3 && (double)projectile.velocity.Length() < (double)yoyoSpeed * 0.6)
                    {
                        projectile.velocity.Normalize();
                        projectile.velocity *= yoyoSpeed * 0.6f;
                    }
                }
            }
            else
            {
                // Changing this causes the yoyo to be more elastic, or "floppy" when using.
                // Vanilla sets this to 0.8, but I chose to do 3.25.
                num7 = (int)((double)num7 * 3.25);

                projectile.tileCollide = false;
                Vector2 vector9 = Main.player[projectile.owner].Center - projectile.Center;
                float num15 = vector9.Length();

                if (num15 < yoyoSpeed + 10f || num15 == 0f || num15 > 2000f)
                {
                    projectile.Kill();
                }
                else
                {
                    vector9.Normalize();
                    vector9 *= yoyoSpeed;
                    projectile.velocity = (projectile.velocity * (num7 - 1f) + vector9) / num7;
                }
            }
            projectile.rotation += 0.45f;
        }
    }
}
