using System;
using OctoType.Audio;
using OctoType.Utils;

namespace OctoType.Inputs {

    public class GameInputManager : InputHandler {

        private AudioManager audio;

        public GameInputManager(AudioManager audio) {
            this.audio = audio;
        }

        public override void Update() {
            base.Update();
            // do checking validation for held keys etc.
        }

        protected override void OnKeyPress(string key) {
            Console.WriteLine("hit key " + key + " at time " +TimeUtils.Timer);
            audio.PlaySoundEffect("hitsound.wav");
        }
    }
}
