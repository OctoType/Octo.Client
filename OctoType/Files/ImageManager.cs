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

        public override void UnloadFile(string name) {
            Texture2D file = (Texture2D) data[name];
            file.Dispose();
            base.UnloadFile(name);
        }

        public override void UnloadAllFiles() {
            foreach(string name in data.Keys) {
                UnloadFile(name);
            }
            base.UnloadAllFiles();
        }

        /// <summary>
        /// Draws the image into spriteBatch, make sure that spriteBatch has already called begin
        /// </summary>
        public void DrawImage(string name, Vector2 position, ref SpriteBatch spriteBatch) {
            Texture2D file = (Texture2D) data[name];
            spriteBatch.Draw(file, position, Color.White);
        }

        public void DrawImage(string name, Vector2 position, Vector2 targetDimensions, bool maintainProportions, ref SpriteBatch spriteBatch) {
            Texture2D file = (Texture2D) data[name];
            Vector2 scale = new Vector2(targetDimensions.X / file.Width,
                                        targetDimensions.Y / file.Height);
            if(maintainProportions) {
                spriteBatch.Draw(file,
                             position,                      // position
                             null,                          // target area
                             Color.White,                   // tint
                             0,                             // rotation
                             new Vector2(0, 0),             // point of rotation
                             scale.Y,                       // scale
                             SpriteEffects.None,            // sprite effects
                             0);                            // layer depth
            } else {
                spriteBatch.Draw(file,
                             position,                      // position
                             null,                          // target area
                             Color.White,                   // tint
                             0,                             // rotation
                             new Vector2(0, 0),             // point of rotation
                             scale,                         // scale
                             SpriteEffects.None,            // sprite effects
                             0);                            // layer depth
            }
        }
    }
}
