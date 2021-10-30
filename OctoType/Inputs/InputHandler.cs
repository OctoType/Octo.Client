using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace OctoType.Inputs {

    public abstract class InputHandler {

        protected HashSet<string> HeldKeys;
        protected HashSet<string> PressedKeys;
        protected HashSet<string> LiftedKeys;
        private HashSet<string> newKeysDown = new HashSet<string>();

        public InputHandler() {
            HeldKeys = new HashSet<string>();
            PressedKeys = new HashSet<string>();
            LiftedKeys = new HashSet<string>();
            newKeysDown = new HashSet<string>();
        }

        public virtual void Update() {
            newKeysDown.Clear();
            PressedKeys.Clear();
            LiftedKeys.Clear();
            foreach(Keys key in Keyboard.GetState().GetPressedKeys()) { 
                string kval = key.ToString();
                newKeysDown.Add(kval);
                if(!HeldKeys.Contains(kval)) {
                    PressedKeys.Add(kval);
                    HeldKeys.Add(kval);          // technically it is held as it's pressed
                    OnKeyPress(kval);
                }
            }
            foreach(string kval in HeldKeys) {
                if(!newKeysDown.Contains(kval)) {
                    LiftedKeys.Add(kval);
                    OnKeyLift(kval);
                }
            }
            HeldKeys.RemoveWhere(x => !newKeysDown.Contains(x));
            // here, we expect that HeldKeys is equal to newKeysDown
        }

        /// <summary>
        /// NOTE! DO NOT USE: HeldKeys, PressedKeys, LiftedKeys IN THIS METHOD
        /// THEY WILL NOT PROVIDE ACCURATE VALUES
        /// </summary>
        protected virtual void OnKeyPress(string key) { }

        /// <summary>
        /// NOTE! DO NOT USE: HeldKeys, PressedKeys, LiftedKeys IN THIS METHOD
        /// THEY WILL NOT PROVIDE ACCURATE VALUES
        /// </summary>
        protected virtual void OnKeyLift(string key) { }
    }
}
