using System;

namespace OctoType.Screens {

    public interface IScreen {

        public bool IsLoaded { get; set; }

        /// <summary>
        /// Updates the status of the contents of the screen
        /// </summary>
        public void Update();

        /// <summary>
        /// Drawing the contents of the screen
        /// </summary>
        public void Draw();

        /// <summary>
        /// Loads all assets involved in the screen
        /// </summary>
        public void LoadContent();

        /// <summary>
        /// Unloads all the assets involved in the screen
        /// </summary>
        public void UnloadContent();

        /// <summary>
        /// Code to run upon exiting the screen
        /// </summary>
        public void OnExit();

        /// <summary>
        /// Code to run upon suspending the screen
        /// </summary>
        public void OnSuspend();
    }
}
