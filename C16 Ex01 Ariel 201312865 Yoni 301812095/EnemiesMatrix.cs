using C16_Ex01_Ariel_201312865_Yoni_301812095.enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C16_Ex01_Ariel_201312865_Yoni_301812095
{
    internal class EnemiesMatrix : GameObject
    {
        private const int k_Width = 9;
        private const int k_HeightEnemy1 = 1;
        private const int k_HeightEnemy2 = 2;
        private const int k_HeightEnemy3 = 3;
        private const int k_enemyWidth = 32;
        private const float k_DistanceBetweenEnemies = (float)(k_enemyWidth * 0.6);
        private const int k_Height = k_HeightEnemy1 + k_HeightEnemy2 + k_HeightEnemy3;
        private bool m_isMovedDownLastUpdate = false;
        private readonly Enemy[,] m_Matrix;
        private int m_PixelsToMove;
        private float m_CountTimeToMove = 0;

        public EnemiesMatrix(GameInvaders i_GameInvaders) : base(i_GameInvaders)
        {
            m_Matrix = new Enemy[k_Height, k_Width];
            addRowOfEnemies(eEnemyShip.Type1, 0, k_HeightEnemy1);
            addRowOfEnemies(eEnemyShip.Type2, k_HeightEnemy1, k_HeightEnemy2);
            addRowOfEnemies(eEnemyShip.Type3, k_HeightEnemy1 + k_HeightEnemy2, k_HeightEnemy3);

            m_PixelsToMove = m_Matrix[0, 0].Texture.Bounds.Width / 2;
        }

        public Enemy[,] Matrix
        {
            get
            {
                return m_Matrix;
            }
        }


        private void addRowOfEnemies(eEnemyShip i_Type, int i_FromRow, int i_NumOfRows)
        {
            if (i_FromRow < 0 || i_FromRow >= k_Height)
            {
                throw new ArgumentOutOfRangeException(String.Format("Row number must be betwwen 0 - {0}!", k_Height - 1));
            }
            else if (i_NumOfRows < 0 || k_Height < i_FromRow + i_NumOfRows)
            {
                throw new ArgumentOutOfRangeException(String.Format("Num of rows can be between 0 - {0}!", i_FromRow + i_NumOfRows));
            }
            else
            {
                for (int i = 0; i < i_NumOfRows; i++)
                {
                    for (int j = 0; j < k_Width; j++)
                    {
                        m_Matrix[i_FromRow + i, j] = new Enemy(r_GameInvaders, i_Type);
                        float X = j * (k_enemyWidth + k_DistanceBetweenEnemies);
                        float Y = (i_FromRow + i) * (k_enemyWidth + k_DistanceBetweenEnemies) + 3 * m_Matrix[i_FromRow + i, j].Texture.Height;
                        m_Matrix[i_FromRow + i, j].Position = new Vector2(X, Y);
                    }
                }
            }
        }

        public override void Draw(SpriteBatch i_SpriteBatch)
        {
            foreach (Enemy enemy in m_Matrix)
            {
                enemy.Draw(i_SpriteBatch);
            }
        }

        public override void Update(GameTime i_GameTime)
        {
            if (!checkIfGameOver())
            {
                m_CountTimeToMove += (float)i_GameTime.ElapsedGameTime.TotalSeconds;
                if (m_CountTimeToMove >= Enemy.TimeToMove)
                {
                    m_CountTimeToMove -= Enemy.TimeToMove;

                    float leftPos = m_Matrix[0, 0].Position.X;
                    float rightPos = m_Matrix[0, k_Width - 1].Position.X + m_Matrix[0, k_Width - 1].Texture.Width;

                    if ((rightPos >= r_GameInvaders.Window.ClientBounds.Width || leftPos < 0)
                        &&
                        !m_isMovedDownLastUpdate)
                    {
                        m_PixelsToMove *= -1;
                        updatePositionToAllEnemies(0, Math.Abs(m_PixelsToMove));
                        m_isMovedDownLastUpdate = true;
                    }
                    else
                    {
                        updatePositionToAllEnemies(m_PixelsToMove, 0);
                        m_isMovedDownLastUpdate = false;
                    }
                }
            }
        }

        public bool checkIfGameOver()
        {
            bool isOver = false;

            for (int i = 0; i < k_Height; i++)
            {
                for (int j = 0; j < k_Width; j++)
                {
                    //Check if enemies reached window bottom
                    if (m_Matrix[i, j].isVisible && m_Matrix[i, j].Position.Y + m_Matrix[i, j].Texture.Bounds.Height > r_GameInvaders.Window.ClientBounds.Bottom)
                    {
                        isOver = true;
                        break;
                    }
                }
            }

            return isOver;
        }

        private void updatePositionToAllEnemies(int i_PixelsToMoveHorizontal, int i_PixelsToMoveVertical)
        {
            foreach (Enemy enemy in m_Matrix)
            {
                float X = enemy.Position.X + i_PixelsToMoveHorizontal;
                float Y = enemy.Position.Y + i_PixelsToMoveVertical;
                enemy.Position = new Vector2(X, Y);
            }
        }
    }
}
