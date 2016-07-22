using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using C16_Ex01_Ariel_201312865_Yoni_301812095.enums;

namespace C16_Ex01_Ariel_201312865_Yoni_301812095
{
    internal class Spaceship : GameObject
    {
        private MachineGun m_MachineGun;

        public Spaceship(GameInvaders i_GameInvaders) : base(i_GameInvaders)
        {
            this.Texture = TextureRpository.Get("Spaceship");
            this.Color = Color.White;
            m_MachineGun = new MachineGun(r_GameInvaders, this);

            // Get the bottom and center:
            float X = 0;
            float Y = (float)r_GameInvaders.GraphicsDevice.Viewport.Height;

            // Offset:
            Y -= this.Texture.Height / 2;

            // Put it a little bit higher:
            Y -= 30;

            this.Position = new Vector2(X, Y);
        }

        public override void Update(GameTime i_GameTime)
        {
            MouseState mouseState = Mouse.GetState();
            float x =  mouseState.X;

            if (x >= 0 && x < r_GameInvaders.Window.ClientBounds.Width - Texture.Width)
            {
                this.Position = new Vector2(x, Position.Y);
            }

            m_MachineGun.Update(i_GameTime);
        }

        public override void Draw(SpriteBatch i_SpriteBatch)
        {
            i_SpriteBatch.Begin();
            i_SpriteBatch.Draw(Texture, Position, Color);
            i_SpriteBatch.End();

            m_MachineGun.Draw(i_SpriteBatch);
        }
    }
}
