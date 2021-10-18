using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace OctoType.Inputs {

    public abstract class InputHandler {

        protected List<string> HeldKeys;
        protected List<string> PressedKeys;
        protected List<string> LiftedKeys;
        private List<string> newKeysDown = new List<string>();

        public InputHandler() {
            HeldKeys = new List<string>();
            PressedKeys = new List<string>();
            LiftedKeys = new List<string>();
            newKeysDown = new List<string>();
        }

        public virtual void Update() {
            newKeysDown.Clear();
            PressedKeys.Clear();
            LiftedKeys.Clear();
            foreach(Keys key in Keyboard.GetState().GetPressedKeys()) { 
                string kval = key.ToString();
                Console.WriteLine(kval);
                newKeysDown.Add(kval);
                if(!HeldKeys.Contains(kval)) {   
                    PressedKeys.Add(kval);       
                    HeldKeys.Add(kval);          // technically it is held as it's pressed
                }
            }
            foreach(string kval in HeldKeys) {
                if(!newKeysDown.Contains(kval)) {
                    LiftedKeys.Add(kval);
                    HeldKeys.Remove(kval);       // remove keys that no longer are held
                }
            }
            // here, we expect that KeysHeld is equal to newKeysDown
        }
    }
}
