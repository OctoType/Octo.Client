using System;
using OctoType.Audio;
using OctoType.Utils;

namespace OctoType.Inputs {

    public class GameInputManager : InputHandler {

        private AudioManager audio;
        private Conductor conductor;

        public GameInputManager(ref AudioManager audio, ref Conductor conductor) {
            this.audio = audio;
            this.conductor = conductor;
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
