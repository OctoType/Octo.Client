using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using OctoType.Audio;

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
        }
    }
}
