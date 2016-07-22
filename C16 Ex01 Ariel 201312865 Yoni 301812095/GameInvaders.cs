using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace C16_Ex01_Ariel_201312865_Yoni_301812095
{
    public class GameInvaders : Game
    {
        private GraphicsDeviceManager m_Graphics;
        private SpriteBatch m_SpriteBatch;
        private GameLogic m_GameLogic;

        public GameInvaders()
        {
            this.IsMouseVisible = true;
            m_Graphics = new GraphicsDeviceManager(this);
            m_Graphics.PreferredBackBufferWidth = 1024;
            m_Graphics.PreferredBackBufferHeight = 768;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            m_GameLogic = new GameLogic(this);
        }

        protected override void LoadContent()
        {
            m_SpriteBatch = new SpriteBatch(GraphicsDevice);

            TextureRpository.Add("Background", Content.Load<Texture2D>(@"Sprites\BG_Space01_1024x768"));
            TextureRpository.Add("Enemy1", Content.Load<Texture2D>(@"Sprites\Enemy0101_32x32"));
            TextureRpository.Add("Enemy2", Content.Load<Texture2D>(@"Sprites\Enemy0201_32x32"));
            TextureRpository.Add("Enemy3", Content.Load<Texture2D>(@"Sprites\Enemy0301_32x32"));
            TextureRpository.Add("Spaceship", Content.Load<Texture2D>(@"Sprites\Ship01_32x32"));
            TextureRpository.Add("MotherShip", Content.Load<Texture2D>(@"Sprites\MotherShip_32x120"));
            TextureRpository.Add("Bullet", Content.Load<Texture2D>(@"Sprites\Bullet"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            m_GameLogic.UpdateAll(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            m_GameLogic.DrawAll(gameTime, m_SpriteBatch);  

            base.Draw(gameTime);
        }
    }
}
