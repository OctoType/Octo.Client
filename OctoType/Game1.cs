using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OctoType.Utils;
using OctoType.Screens;
using System;

namespace OctoType {

    public class Game1 : Game {

        private GraphicsDeviceManager _graphics;

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            _graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            _graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
            _graphics.ApplyChanges();

            // TODO: This is for testing only, remove this line later
            ScreenManager.Instance.AddScreen(new TestScreen(GraphicsDevice));
            //ScreenManager.Instance.RemoveScreen();
            //ScreenManager.Instance.AddScreen(new GameScreen(GraphicsDevice));

            base.Initialize();
        }

        protected override void LoadContent() {
            ScreenManager.Instance.LoadAllContent();
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Updating game time
            TimeUtils.Timer = (float) gameTime.TotalGameTime.TotalMilliseconds;
            ScreenManager.Instance.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            ScreenManager.Instance.Draw();
            base.Draw(gameTime);
        }
    }
}
