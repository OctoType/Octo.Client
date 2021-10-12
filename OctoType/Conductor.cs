using System;
using OctoType.Utils;
namespace OctoType {
    public class Conductor {

        /// <summary>
        /// The main variable for keeping track of the location inside of a song
        /// ***EVERYTHING*** should be using this variable to keep time
        /// </summary>
        private float songTime;
        public float SongTime { set; get; }

        /// <summary>
        /// The bpm of the song which this conductor is tracking
        /// </summary>
        private float bpm;
        public float Bpm { set; get; }

        /// <summary>
        /// The amount of milliseconds before the song actually starts playing
        /// after opening the file
        /// </summary>
        private float offset;
        public float Offset { set; private get; }

        /// <summary>
        /// Keeps track of whether or not the song is playing (may be put into
        /// audio manager)
        /// </summary>
        private Boolean isPlaying;
        public Boolean IsPlaying { private set; get; }

        private float previousFrameTime;
        private int barNum;

        public Conductor(float bpm, float offset) {
            this.barNum = 0;
            this.songTime = 0;
            this.bpm = bpm;
            this.offset = offset;
        }

        public void startSong() {
            if(this.IsPlaying) return;
            this.IsPlaying = true;
            previousFrameTime = TimeUtils.Timer;
        }

        // call this every frame
        public void updateSongTime() {
            this.SongTime = TimeUtils.Timer - previousFrameTime;
        }
    }
}