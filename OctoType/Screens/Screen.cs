using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OctoType.Screens {

    public abstract class Screen {

        public bool IsLoaded { get; internal set; }

        /// <summary>
        /// Updates the status of the contents of the screen
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Drawing the contents of the screen
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Loads all assets involved in the screen
        /// </summary>
        public abstract void LoadContent();

        /// <summary>
        /// Unloads all the assets involved in the screen
        /// </summary>
        public abstract void UnloadContent();

        /// <summary>
        /// Code to run upon exiting the screen
        /// </summary>
        public abstract void OnExit();

        /// <summary>
        /// Code to run upon suspending the screen
        /// </summary>
        public abstract void OnSuspend();
    }
}
