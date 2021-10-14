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
            _audio.LoadFile("blueberry.mp3", "D:\\J\\Music\\blueberry.mp3");
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
                Song song = (Song) _audio.GetFile("blueberry.mp3");
                MediaPlayer.Play(song);
                isPlaying = true;
            }
        }
    }
}
