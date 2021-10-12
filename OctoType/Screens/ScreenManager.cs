using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OctoType.Screens {

    public class ScreenManager {

        /// <summary>
        /// Singleton class pattern, only once instance of ScreenManager allowed
        /// </summary>
        private static ScreenManager instance;
        public static ScreenManager Instance {
            get {
                if(instance == null) instance = new ScreenManager();
                return instance;
            }
        }

        public ScreenManager() {
            Dimensions = new Vector2(1600,900);
        }
        
        public Vector2 Dimensions { private set; get; }
        private List<IScreen> activeScreens = new List<IScreen>();
        private Stack<IScreen> ScreenStack = new Stack<IScreen>();

        /// <summary>
        /// Adds a screen to be managed by the screen manager
        /// </summary>
        public void AddScreen(IScreen screen) {
            activeScreens.Add(screen);
            ScreenStack.Push(screen);
        }

        /// <summary>
        /// Removes a screen from the top of all managed screens
        /// </summary>
        public void RemoveScreen() {
            activeScreens.Remove(
                ScreenStack.Pop());
        }

        /// <summary>
        /// Loads resources for all currently managed screens
        /// </summary>
        public void LoadAllContent() {
            foreach(IScreen screen in activeScreens) {
                screen.LoadContent();
            }
        }

        /// <summary>
        /// Loads resources for an individual screen
        /// </summary>
        public void LoadContent(IScreen screen) {
            screen.LoadContent();
        }

        /// <summary>
        /// Unload resources for an individual screen
        /// </summary>
        public void UnloadContent(IScreen screen) {
            screen.UnloadContent();
        }

        public void Update() {
            foreach(IScreen screen in activeScreens) {
                screen.Update();
            }
        }

        public void Draw() {
            foreach(IScreen screen in activeScreens) {
                screen.Draw();
            }
        }
    }
}
