using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OctoType.Files;

namespace OctoType.Images {

    public class ImageManager : FileLoader {

        private GraphicsDevice graphics;

        public ImageManager(GraphicsDevice graphics) : base() {
            this.graphics = graphics;
        }

        public override void LoadFile(string name, string path) {
            Texture2D file = Texture2D.FromFile(graphics, path);
            data.Add(name, file);
        }
    }
}
