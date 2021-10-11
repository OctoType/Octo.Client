using System;
using OctoType.Utils;
namespace OctoType {
    public class Conductor {

        private float songTime;
        public float SongTime { set; get; }
        private float bpm;
        public float Bpm { set; get; }
        private float offset;
        public float Offset { set; private get; }

        private float previousFrameTime;
        private int barNum;

        public Conductor(float bpm, float offset) {
            this.barNum = 0;
            this.songTime = 0;
            this.bpm = bpm;
            this.offset = offset;
        }

        public void startSong() {
            previousFrameTime = TimeUtils.Timer;
        }

        // call this every frame
        public void updateSongTime() {
            this.SongTime = TimeUtils.Timer - previousFrameTime;
        }
    }
}