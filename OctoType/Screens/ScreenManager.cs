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
        public ContentManager Content { private set; get; }
        public Vector2 Dimensions { private set; get; }
        private List<Screen> activeScreens = new List<Screen>();
        private Stack<Screen> ScreenStack = new Stack<Screen>();

        public ScreenManager() {
            Dimensions = new Vector2(1600, 900);
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
            activeScreens.Remove(
                ScreenStack.Pop());
        }

        /// <summary>
        /// Loads resources
        /// </summary>
        public void LoadContent(ContentManager Content) {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
        }

        /// <summary>
        /// Unload resources
        /// </summary>
        public void UnloadContent() {
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
