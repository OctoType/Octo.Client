using System;
using OctoType.Utils;
namespace OctoType {
    public class Conductor {
        public float songTime { set; get; }
        private float startTime;
        public float bpm { set; get; }
        public float offset { set; get; }
        private int barNum;

        public Conductor(float bpm, float offset) {
            this.barNum = 0;
            this.songTime = 0;
            this.bpm = bpm;
            this.offset = offset;
        }

        public void startSong() {

        }

        // call this every frame
        public void updateSongTime() {
            startTime = TimeUtils.Timer;
        }
    }
}