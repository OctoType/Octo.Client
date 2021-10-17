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
            _audio.LoadFile("song.ogg", "/Users/fakebear/Projects/OctoType/Charts/TestMap1/song.ogg");
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
            if (!isPlaying)
            {
                Song song = (Song) _audio.GetFile("song.ogg");
                Console.WriteLine(song.Name);
                MediaPlayer.Play(song);
                isPlaying = true;
            }
        }
    }
}
