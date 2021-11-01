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
        private Conductor conductor;
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
            _audio.LoadFile("song.wav", "../../../../Charts/TestMap1/song.wav");
            _audio.LoadFile("hitsound.wav", "../../../../Charts/TestMap1/hitsound.wav");
            _images.LoadFile("background.jpg", "../../../../Charts/TestMap1/background.jpg");

            conductor = new Conductor(120, 0, ref _audio);
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
            if(!conductor.IsPlaying) {
                conductor.StartSong("song.wav");
            } else {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("song time: " + conductor.AdjustedSongTime);
            }
            conductor.UpdateSongTime();
            gameInputManager.Update();
        }
    }
}
