using System;
using OctoType.Files;
using OctoType.Utils;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace OctoType.Audio {

    public class AudioManager : FileLoader {

        private static readonly string SONG = "song";

        public AudioManager() : base() {
        }

        /// <summary>
        /// Load a file into the audio manager. Because this class supports both songs and sound effects
        /// it is important to note this:
        /// - SONG files for beatmaps **MUST** contain song inside of their name, otherwise they will be loaded as sound effects
        /// - Additionally, song file names must match the file name (recommended to be song.ogg)
        /// - sound effect files **MUST NOT** contain song, otherwise they will be loaded as songs
        /// </summary>
        public override void LoadFile(string name, string path) {
            if(StringUtils.Normalize(name).Contains(SONG)) {
                Uri uri = new Uri(path, UriKind.Relative);
                Song song = Song.FromUri(name, uri);
                data.Add(name, song);
            } else {
                SoundEffect soundEffect = SoundEffect.FromFile(path);
                data.Add(name, soundEffect);
            }
            
        }

        /// <summary>
        /// Plays a song with name. The name MUST contain song 
        /// </summary>
        public void PlaySong(string name) {
            if(StringUtils.Normalize(name).Contains(SONG))
                MediaPlayer.Play((Song)data[name]);
            else {
                Console.WriteLine("ERR: line 31 AudioManager " + name + " is not a song.");
            }
        }
        
        public void PauseSong() {
            MediaPlayer.Pause();
        }

        public void StopSong() {
            MediaPlayer.Stop();
        }

        public void ResumeSong() {
            MediaPlayer.Resume();
        }

        public void PlaySoundEffect(string name) {
            SoundEffect soundEffect = (SoundEffect) data[name];
            soundEffect.Play();
        }
    }
}
