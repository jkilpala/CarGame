using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CarGame
{
    /// <summary>
    /// Class to handle all the data on track
    /// </summary>
    class Track
    {
        Texture2D img;
        Color[] imgData;
        Rectangle trackRect;

        Color roadSurface = new Color(100, 100, 100);
        Color grassSurface = new Color(8, 68, 8);
        public String ImgName
        {
            get { return img.Name; }
        }

        public Track(Texture2D img)
        {
            this.img = img;
            imgData = new Color[img.Width * img.Height];
            img.GetData(imgData);
            BoundinRectangle();
            
        }
        public Track()
        {

        }
        public void BoundinRectangle()
        {
            trackRect = new Rectangle(0, 0, img.Width, img.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(img,new Rectangle(0,0,img.Width,img.Height),Color.White);
        }

        public float[] CheckRoadSurface(Rectangle carRect, Color[] carImageData, float x, float y)
        {
            float[] drag = new float[2];

            if (Util.IntersectPixels(trackRect, imgData, carRect, carImageData))
            {
                if (imgData[Util.Convert2Dto1D((int)x, (int)y, img.Width, img.Height)] == roadSurface)
                {
                    //System.Diagnostics.Debug.WriteLine("Road");
                    //drag[0] = 0.05f;
                    //drag[1] = 0.0002f;

                    drag[0] = 0.03f;
                    drag[1] = 0.0002f;
                }
                else if (imgData[Util.Convert2Dto1D((int)x, (int)y, img.Width, img.Height)] == grassSurface)
                {
                    //System.Diagnostics.Debug.WriteLine("Grass");
                    drag[0] = 0.08f;
                    drag[1] = 0.0002f;
                }
                else
                {
                    drag[0] = 0.03f;
                    drag[1] = 0.0002f;
                }
                // System.Diagnostics.Debug.WriteLine(imgData);
                //System.Diagnostics.Debug.WriteLine(imgData[Util.Convert2Dto1D((int) x, (int) y, img.Width, img.Height)]);
                //System.Diagnostics.Debug.WriteLine("muuu");
            }
            return drag;
        }
    }
}
