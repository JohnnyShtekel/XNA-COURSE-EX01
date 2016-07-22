using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C16_Ex01_Ariel_201312865_Yoni_301812095
{
    internal class GameLogic
    {
        public readonly List<GameObject> AllGameObjects = new List<GameObject>();
        private EnemiesMatrix m_EnemyMatrix;
        private Spaceship m_Spaceship;
        private Background m_Background;
        private readonly GameInvaders r_GameInvaders;

        public GameLogic(GameInvaders i_GameInvaders)
        {
            r_GameInvaders = i_GameInvaders;

            m_Background = new Background(r_GameInvaders);
            m_EnemyMatrix = new EnemiesMatrix(r_GameInvaders);
            m_Spaceship = new Spaceship(r_GameInvaders);

            AllGameObjects.Add(m_Background);     //must be drawn first
            AllGameObjects.Add(m_EnemyMatrix);
            AllGameObjects.Add(m_Spaceship);
        }

        public void UpdateAll(GameTime i_GameTime)
        {
            foreach (GameObject obj in AllGameObjects)
            {
                obj.Update(i_GameTime);
            }

            BulletsCollasionManager.Manage(new List<GameObject>(m_EnemyMatrix.Matrix.Cast<GameObject>().ToList()));
        }

        public void DrawAll(GameTime i_GameTime, SpriteBatch m_SpriteBatch)
        {
            foreach (GameObject obj in AllGameObjects)
            {
                obj.Draw(m_SpriteBatch);
            }
        }
    }
}
