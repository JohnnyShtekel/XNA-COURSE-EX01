using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace C16_Ex01_Ariel_201312865_Yoni_301812095
{
    internal class Background : GameObject
    {
        public Background(GameInvaders i_GameInvaders) : base(i_GameInvaders)
        {
            this.Texture = TextureRpository.Get("Background");
            this.Position = Vector2.Zero;
            this.Color = Color.Gray;
        }

        public override void Draw(SpriteBatch i_SpriteBatch)
        {
            i_SpriteBatch.Begin();
            i_SpriteBatch.Draw(this.Texture, this.Position, Color);
            i_SpriteBatch.End();
        }

        public override void Update(GameTime i_GameTime)
        {
            //Nothing to update - an empty implementation
        }
    }
}
