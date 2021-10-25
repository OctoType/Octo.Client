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
        
        public Vector2 Dimensions { private set; get; }
        private List<Screen> activeScreens = new List<Screen>();
        private Stack<Screen> ScreenStack = new Stack<Screen>();

        public ScreenManager() {
            Dimensions = new Vector2(1366, 768);
        }

        /// <summary>
        /// Adds a screen to be managed by the screen manager
        /// </summary>
        public void AddScreen(Screen screen) {
            activeScreens.Add(screen);
            ScreenStack.Push(screen);
        }

        /// <summary>
        /// Removes a screen from the top of all managed screens
        /// </summary>
        public void RemoveScreen() {
            Screen screen = ScreenStack.Pop();
            screen.UnloadContent();
            activeScreens.Remove(screen);
        }

        /// <summary>
        /// Loads resources for screen into memory
        /// </summary>
        public void LoadContent(Screen screen) {
            screen.LoadContent();
        }
        /// <summary>
        /// Loads all resources for all active screens into memory
        /// </summary>
        public void LoadAllContent() {
            foreach(Screen screen in activeScreens) {
                screen.LoadContent();
            }
        }

        /// <summary>
        /// Unload resources for screen (free memory)
        /// </summary>
        public void UnloadContent(Screen screen) {
            screen.UnloadContent();
        }

        public void Update() {
            foreach(Screen screen in activeScreens) {
                screen.Update();
            }
        }

        public void Draw() {
            foreach(Screen screen in activeScreens) {
                screen.Draw();
            }
        }
    }
}
