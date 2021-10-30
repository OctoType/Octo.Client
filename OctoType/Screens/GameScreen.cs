using System;
using OctoType.Audio;
using OctoType.Images;
using OctoType.Inputs;
using OctoType.Charts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OctoType.Screens {
    public class GameScreen : Screen {

        private AudioManager _audio;
        private ImageManager _images;
        private GameInputManager gameInputManager;
        private ChartManager chartManager;
        private SpriteBatch _sprites;
        private bool isPlaying = false;

        public GameScreen(GraphicsDevice grahpics) {
            _images = new ImageManager(grahpics);
            _sprites = new SpriteBatch(grahpics);
        }

        public override void LoadContent() {
            _audio = new AudioManager();
            chartManager = new ChartManager();
            gameInputManager = new GameInputManager(_audio);

            // TODO: load in data for the chart from chart manager
            base.LoadContent();
        }

        public override void UnloadContent() {
            _images.UnloadAllFiles();
            _audio.UnloadAllFiles();
            base.UnloadContent();
        }

        public override void OnExit() {
            UnloadContent();
        }

        public override void OnSuspend() {
        }

        public override void Draw() {
            //background UI elements
            _sprites.Begin();
            
            _sprites.End();
        }

        public override void Update() {
            if(!isPlaying) {
                isPlaying = true;
                _audio.PlaySong("song.ogg");
            } else {
                Console.WriteLine(_audio.GetSongPosition());
            }
            gameInputManager.Update();
        }
    }
}
