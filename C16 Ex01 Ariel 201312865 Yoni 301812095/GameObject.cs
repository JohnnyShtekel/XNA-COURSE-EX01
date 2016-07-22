using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C16_Ex01_Ariel_201312865_Yoni_301812095
{
    internal abstract class GameObject
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public bool isVisible { get; set; }
        protected readonly GameInvaders r_GameInvaders;

        public GameObject(GameInvaders i_GameInvaders)
        {
            isVisible = true;
            r_GameInvaders = i_GameInvaders;
        }

        public abstract void Draw(SpriteBatch i_SpriteBatch);

        public abstract void Update(GameTime i_GameTime);
    }
}
