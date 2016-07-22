using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C16_Ex01_Ariel_201312865_Yoni_301812095
{
    internal class BulletsCollasionManager
    {
        private static readonly List<Bullet> sr_AllGameBullets = new List<Bullet>();

        public static void Manage(GameObject i_VulnerableGameObject) 
        {
            IVulnerable vulnerableGameObject = i_VulnerableGameObject as IVulnerable;

            if (vulnerableGameObject != null)
            {
                Rectangle objectBounds = i_VulnerableGameObject.Texture.Bounds;
                objectBounds.X = (int)i_VulnerableGameObject.Position.X;
                objectBounds.Y = (int)i_VulnerableGameObject.Position.Y;

                int index = 0;
                List<int> indexesOfBulletsToDelete = new List<int>();
                foreach (Bullet bullet in sr_AllGameBullets)
                {
                    if (i_VulnerableGameObject.isVisible && objectBounds.Contains(bullet.Position))
                    {
                        vulnerableGameObject.Hit();
                        bullet.isVisible = false;
                        indexesOfBulletsToDelete.Add(index);
                    }

                    index++;
                }

                foreach (int ind in indexesOfBulletsToDelete)
                {
                    sr_AllGameBullets.RemoveAt(ind);
                }
            }
            else
            {
                throw new InvalidOperationException("Given GameObject must implements IVulnerable interface");
            }
        }

        public static void Manage(List<GameObject> i_ListOfVulnerableGameObject)
        {
            foreach(GameObject obj in i_ListOfVulnerableGameObject)
            {
                Manage(obj);
            }
        }

        public static void Add(Bullet bullet)
        {
            sr_AllGameBullets.Add(bullet);
        }
    }
}
