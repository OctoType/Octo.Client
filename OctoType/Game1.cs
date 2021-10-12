using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OctoType.Utils;
using OctoType.Screens;
using System;

namespace OctoType {

    public class Game1 : Game {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            _graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ScreenManager.Instance.LoadAllContent();
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            // Updating game time
            TimeUtils.Timer = (float)gameTime.TotalGameTime.TotalMilliseconds;
            ScreenManager.Instance.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            ScreenManager.Instance.Draw();
            base.Draw(gameTime);
        }
    }
}
