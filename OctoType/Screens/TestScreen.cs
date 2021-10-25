using System;
using OctoType.Audio;
using OctoType.Images;
using OctoType.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OctoType.Screens {
    public class TestScreen : Screen {
        private AudioManager _audio;
        private ImageManager _images;
        private GameInputManager gameInputManager;
        private SpriteBatch _sprites;
        private bool isPlaying = false;

        public TestScreen(GraphicsDevice grahpics) {
            _images = new ImageManager(grahpics);
            _sprites = new SpriteBatch(grahpics);
        }

        public override void LoadContent() {
            _audio = new AudioManager();
            gameInputManager = new GameInputManager(_audio);
            _audio.LoadFile("song.ogg", "../../../../Charts/TestMap1/song.ogg");
            _audio.LoadFile("hitsound.wav", "../../../../Charts/TestMap1/hitsound.wav");
            _images.LoadFile("background.jpg", "../../../../Charts/TestMap1/background.jpg");
            base.LoadContent();
        }

        public override void UnloadContent() {
            if(_images != null) _images.UnloadAllFiles();
            if(_audio != null) _audio.UnloadAllFiles();
            base.UnloadContent();
        }

        public override void OnExit() {
            UnloadContent();
        }

        public override void OnSuspend() {
        }

        public override void Draw() {
            _sprites.Begin();
            _images.DrawImage("background.jpg",
                              new Vector2(0,0),
                              ScreenManager.Instance.Dimensions,
                              true,
                              ref _sprites);
            _sprites.End();
        }

        public override void Update() {
            if (!isPlaying) {
                isPlaying = true;
                _audio.PlaySong("song.ogg");
            } else {
                Console.WriteLine(_audio.GetSongPosition());
            }
            gameInputManager.Update();
        }
    }
}
