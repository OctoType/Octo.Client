using System;
using OctoType.Audio;
using OctoType.Images;
using OctoType.Inputs;
using Microsoft.Xna.Framework.Graphics;

namespace OctoType.Screens {
    public class TestScreen : Screen
    {
        private AudioManager _audio;
        private ImageManager _images;
        private GameInputManager gameInputManager;
        private bool isPlaying = false;

        public TestScreen(GraphicsDevice grahpics) {
            _images = new ImageManager(grahpics);
        }

        public override void Draw() {
        }

        public override void LoadContent()
        {
            _audio = new AudioManager();
            gameInputManager = new GameInputManager(_audio);
            _audio.LoadFile("song.ogg", "../../../../Charts/TestMap1/song.ogg");
            _audio.LoadFile("hitsound.wav", "../../../../Charts/TestMap1/hitsound.wav");
            this.IsLoaded = true;
        }

        public override void UnloadContent() {
            this.IsLoaded = false;
        }

        public override void OnExit() {
        }

        public override void OnSuspend() {
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
