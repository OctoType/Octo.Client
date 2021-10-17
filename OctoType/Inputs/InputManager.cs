using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace OctoType.Inputs {

    public abstract class InputHandler {

        protected static List<string> KeysHeld { set; get; }
        protected static List<string> PressedKeys { set; get; }
        protected static List<string> LiftedKeys { set; get; }
        private static List<string> newKeysDown = new List<string>();

        public void Update() {
            newKeysDown.Clear();
            PressedKeys.Clear();
            LiftedKeys.Clear();
            foreach(Keys key in Keyboard.GetState().GetPressedKeys()) {
                string kval = key.ToString();
                newKeysDown.Add(kval);
                if(!KeysHeld.Contains(kval)) {
                    PressedKeys.Add(kval);
                    KeysHeld.Add(kval);          // technically it is held as it's pressed
                }
            }
            foreach(string kval in KeysHeld) {
                if(!newKeysDown.Contains(kval)) {
                    LiftedKeys.Add(kval);
                    KeysHeld.Remove(kval);       // remove keys that no longer are held
                }
            }
            // here, we expect that KeysHeld is equal to newKeysDown
            this.OnUpdate();
        }

        protected abstract void OnUpdate();
    }
}
