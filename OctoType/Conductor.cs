using System;
using OctoType.Audio;
using OctoType.Utils;
namespace OctoType.Audio {
    public class Conductor {

        /// <summary>
        /// The main variable for keeping track of the location inside of a song
        /// ***EVERYTHING*** should be using this variable to keep time
        /// </summary>
        public float SongTime { private set; get; }
        public float AdjustedSongTime { private set; get; }
        public float Bpm { private set; get; }

        /// <summary>
        /// The amount of milliseconds before the song actually starts playing
        /// after opening the file
        /// </summary>
        public float Offset { set; private get; }
        public bool IsPlaying { private set; get; }

        private float lastReportedPlayheadPosition;
        private float InternalStartTime;
        private int barNum;

        private AudioManager _audio;

        public Conductor(float bpm, float offset, ref AudioManager audioManager) {
            barNum = 0;
            SongTime = 0;
            Bpm = bpm;
            Offset = offset;
            _audio = audioManager;
        }

        public void StartSong(string name) {
            if(IsPlaying) return;
            IsPlaying = true;
            lastReportedPlayheadPosition = 0;
            _audio.PlaySong(name);
            InternalStartTime = TimeUtils.Timer;
        }
        
        // call this every frame
        public void UpdateSongTime() {
            SongTime = TimeUtils.Timer - InternalStartTime;
            if(_audio.GetSongPosition() != lastReportedPlayheadPosition) {
                lastReportedPlayheadPosition = _audio.GetSongPosition();
                Console.Write("bad is now " + (lastReportedPlayheadPosition - (SongTime - Offset)));
                Console.WriteLine(" UPDATE PLAYHEAD POSITION TO " +lastReportedPlayheadPosition);
                //SongTime = (SongTime + lastReportedPlayheadPosition) / 2;
            }
            AdjustedSongTime = SongTime - Offset;
        }
    }
}