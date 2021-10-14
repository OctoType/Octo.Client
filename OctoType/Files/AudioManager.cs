using System;
using OctoType.Files;
using Microsoft.Xna.Framework.Media;

namespace OctoType.Audio {

    public class AudioManager : FileLoader {

        public AudioManager() {
            
        }

        public override void LoadFile(string name, string path) {
            Uri uri = new Uri(path);
            Song song = Song.FromUri(name, uri);
            MediaPlayer.Play(song);
        }
    }
}
