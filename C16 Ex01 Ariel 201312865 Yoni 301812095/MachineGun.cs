using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C16_Ex01_Ariel_201312865_Yoni_301812095.enums;

namespace C16_Ex01_Ariel_201312865_Yoni_301812095
{
    internal class MachineGun : GameObject
    {
        private const int k_AllowedSpaceshipBullets = 2;
        private List<Bullet> m_BulletsShutted;
        private MouseState m_PrevMouseState;
        private readonly Spaceship r_SpaceshipOwner;

        public MachineGun(GameInvaders i_GameInvaders, Spaceship i_SpaceshipOwner) : base(i_GameInvaders)
        {
            m_BulletsShutted = new List<Bullet>();
            r_SpaceshipOwner = i_SpaceshipOwner;
        }

        public override void Update(GameTime i_GameTime)
        {
            MouseState mouseState = Mouse.GetState();
            float X = r_SpaceshipOwner.Position.X + r_SpaceshipOwner.Texture.Bounds.Width / 2 - 3;
            float Y = r_SpaceshipOwner.Position.Y;
            Position = new Vector2(X, Y);

            if (mouseState.LeftButton == ButtonState.Pressed && m_PrevMouseState.LeftButton == ButtonState.Released)
            {
                if (m_BulletsShutted.Count > k_AllowedSpaceshipBullets - 1)
                {
                    for (int i = 0; i < k_AllowedSpaceshipBullets; i++)
                    {
                        if (m_BulletsShutted[i] == null || !m_BulletsShutted[i].isVisible)
                        {
                            m_BulletsShutted[i] = new Bullet(r_GameInvaders, Color.Red, eBulletDirection.Up, Position);
                            break;
                        }
                    }
                }
                else
                {
                    m_BulletsShutted.Add(new Bullet(r_GameInvaders, Color.Red, eBulletDirection.Up, Position));
                }
            }

            m_PrevMouseState = mouseState;

            foreach (Bullet bullet in m_BulletsShutted)
            {
                if (bullet != null)
                {
                    bullet.Update(i_GameTime);
                }
            }
        }

        public override void Draw(SpriteBatch i_SpriteBatch)
        {
            foreach (Bullet bullet in m_BulletsShutted)
            {
                if (bullet != null)
                {
                    bullet.Draw(i_SpriteBatch);
                }
            }
        }
    }
}
