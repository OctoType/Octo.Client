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
        private int song = -1;

        public GameScreen(GraphicsDevice grahpics) {
            _images = new ImageManager(grahpics);
            _sprites = new SpriteBatch(grahpics);
        }

        public override void LoadContent() {
            _audio = new AudioManager();
            chartManager = new ChartManager();
            Conductor conductor = new Conductor(115, 0, ref _audio);
            gameInputManager = new GameInputManager(ref _audio, ref conductor);

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
            if(song == -1) {
                song = _audio.PlaySong("song.ogg");
            } else {
                Console.WriteLine(_audio.GetSongPosition(song));
            }
            gameInputManager.Update();
        }
    }
}
