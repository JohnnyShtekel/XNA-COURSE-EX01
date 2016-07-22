using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using C16_Ex01_Ariel_201312865_Yoni_301812095.enums;

namespace C16_Ex01_Ariel_201312865_Yoni_301812095
{
    internal class Bullet : GameObject
    {
        private const int k_Speed = -110;

        public Bullet(GameInvaders i_GameInvaders, Color i_BulletColor, eBulletDirection i_Direction, Vector2 i_StartCoordinates) : base(i_GameInvaders)
        {
            BulletsCollasionManager.Add(this);
            this.Texture = TextureRpository.Get("Bullet");
            this.Color = i_BulletColor;
            this.Position = i_StartCoordinates;
        }

        public override void Update(GameTime i_GameTime)
        {
            float Y = Position.Y + k_Speed * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
            Position = new Vector2(Position.X, Y);
        }

        public override void Draw(SpriteBatch i_SpriteBatch)
        {
            if (isVisible)
            {
                i_SpriteBatch.Begin();
                i_SpriteBatch.Draw(Texture, Position, Color);
                i_SpriteBatch.End();
            }
        }
    }
}
