using System;
using OctoType.Files;
using Microsoft.Xna.Framework.Media;

namespace OctoType.Audio {

    public class AudioManager : FileLoader {

        private static readonly string SONG = "song";

        public AudioManager() : base() {
        }

        /// <summary>
        /// Load a file into the audio manager. Because this class supports both songs and sound effects
        /// it is important to note this:
        /// - SONG files for beatmaps **MUST** contain song inside of their name, otherwise they will be loaded as sound effects
        /// - sound effect files **MUST NOT** contain song, otherwise they will be loaded as songs
        /// </summary>
        public override void LoadFile(string name, string path) {
            Uri uri = new Uri(path, UriKind.Relative);
            Console.WriteLine("*LOG: Loading file for " + path + "*");
            Song song = Song.FromUri(name, uri);
            data.Add(name, song);
        }

        /// <summary>
        /// Plays a song with name. The 
        /// </summary>
        public void playSong(string name) {
            if(!name.Contains(SONG))
            MediaPlayer.Play((Song) data[name]);
        }

        public void pause() {

        }

        public void stop() {

        }

        public void resume() {

        }
    }
}
