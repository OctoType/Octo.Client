using System;
using OctoType.Audio;

namespace OctoType.Inputs {

    public class GameInputManager : InputHandler {

        private AudioManager audio;

        public GameInputManager(AudioManager audio) {
            this.audio = audio;
        }

        public override void Update() {
            base.Update();
        }
    }
}
