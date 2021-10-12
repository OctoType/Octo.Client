using System;

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

        public void LoadContent() {

        }

        public void UnloadContent() {

        }

        public void Update() {

        }

        public void Draw() {

        }
    }
}
