using System;
using OctoType.Audio;
using Microsoft.Xna.Framework.Input;

namespace OctoType.Screens {
    public class TestScreen : Screen
    {
        private AudioManager _audio;
        private bool isPlaying = false;

        public override void Draw() {
        }

        public override void LoadContent()
        {
            _audio = new AudioManager();
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
            if(Keyboard.GetState().IsKeyDown(Keys.A)) {
                _audio.PlaySoundEffect("hitsound.wav");
            }
        }
    }
}
