using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CarGame
{
    class Checkpoint
    {
        Texture2D checkPoint;
        Vector2 position;

        Color[] checkPointTextureData;

        bool collision = false;

        short id;

        Rectangle safeBounds;

        Rectangle boundingRectangle;

        public Checkpoint(Texture2D check)
        {
            checkPoint = check;
            checkPointTextureData = new Color[checkPoint.Width * checkPoint.Height];
            checkPoint.GetData(checkPointTextureData);

        }

        public void BoundinRectangle()
        {
            boundingRectangle = new Rectangle((int)position.X, (int)position.Y, checkPoint.Width, checkPoint.Height);
        }

        public void CheckCollision(Rectangle tRect, Color[] tColor)
        {
            if (Util.IntersectPixels(tRect, tColor, boundingRectangle, checkPointTextureData))
            {
                this.collision = true;
                System.Diagnostics.Debug.WriteLine("Collision");
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(checkPoint, position, Color.White);
        }

        

    }
}
