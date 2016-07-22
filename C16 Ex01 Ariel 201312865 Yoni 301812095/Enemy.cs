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
    internal class Enemy : GameObject, IVulnerable
    {
        private static float m_TimeToMove = 0.0f;

        public Enemy(GameInvaders i_GameInvaders, eEnemyShip i_EnemyShip) : base(i_GameInvaders)
        {
            switch (i_EnemyShip)
            {
                case eEnemyShip.Type1:
                    {
                        this.Color = Color.Pink;
                        this.Texture = TextureRpository.Get("Enemy1");
                        break;
                    }
                case eEnemyShip.Type2:
                    {
                        this.Color = Color.PaleTurquoise;
                        this.Texture = TextureRpository.Get("Enemy2");
                        break;
                    }
                case eEnemyShip.Type3:
                    {
                        this.Color = Color.FloralWhite;
                        this.Texture = TextureRpository.Get("Enemy3");
                        break;
                    }
            }
        }

        public static float TimeToMove
        {
            get
            {
                return m_TimeToMove;
            }
            private set
            {
                m_TimeToMove = value;
            }
        }

        public override void Update(GameTime i_GameTime)
        {
            throw new NotImplementedException();
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

        public void Hit()
        {
            isVisible = false;
            TimeToMove -= (TimeToMove / 100) * 6;
        }
    }
}
