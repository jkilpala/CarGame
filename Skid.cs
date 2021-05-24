using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CarGame
{
    class Skid
    {
        Texture2D img;
        Vector2 position;

        public Skid(Texture2D image, Vector2 position)
        {
            img = image;
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(img, position, Color.White);
        }
    }
}
