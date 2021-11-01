using System;
using OctoType.Files;
using OctoType.Utils;
using ManagedBass;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace OctoType.Audio {

    public class AudioManager : FileLoader {

        private static readonly string SONG = "song";

        public AudioManager() : base() {
            Bass.Init();
        }

        /// <summary>
        /// Load a file into the audio manager. Because this class supports both songs and sound effects
        /// it is important to note this:
        /// - SONG files for beatmaps **MUST** contain song inside of their name, otherwise they will be loaded as sound effects
        /// - Additionally, song file names must match the file name (recommended to be song.ogg)
        /// - sound effect files **MUST NOT** contain song, otherwise they will be loaded as songs
        /// </summary>
        public override void LoadFile(string name, string path)
        {
            Uri uri = new Uri(path, UriKind.Relative);
            if (StringUtils.Normalize(name).Contains(SONG))
            {
                Console.WriteLine("loading SONG: " + name);
                int fileAudioStream = Bass.CreateStream(uri.ToString());
                data.Add(name, fileAudioStream);
            }
            else
            {
                Console.WriteLine("loading SOUND EFFECT, " + name);
                SoundEffect soundEffect = SoundEffect.FromFile(path);
                data.Add(name, soundEffect);
            }
        }

        /// <summary>
        /// Plays a song with name. The name MUST contain song 
        /// </summary>
        public int PlaySong(string name) {
            if (StringUtils.Normalize(name).Contains(SONG)) {
                Bass.ChannelPlay((int) data[name]);
                return (int) data[name];
            }
            else {
                Console.WriteLine("ERR: line 31 AudioManager " + name + " is not a song.");
            }
            return -1;
        }
        
        public void PauseSong(int song) {
            Bass.ChannelPause(song);
        }

        public void StopSong(int song)
        {
            Bass.ChannelStop(song);
        }

        public void ResumeSong(int song) {
            Bass.ChannelPlay(song);
        }

        public float GetSongPosition(int song) {
            return (float) Bass.ChannelBytes2Seconds(song, Bass.ChannelGetPosition(song)) * 1000;
        }

        public int PlaySoundEffect(string name) {
            if (! StringUtils.Normalize(name).Contains(SONG)) {
                SoundEffect soundEffect = (SoundEffect) data[name];
                soundEffect.Play();
            }
            else {
                Console.WriteLine("ERR: line 31 AudioManager " + name + " is not a sound effect.");
            }
            return -1;
        }
    }
}
