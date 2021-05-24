using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CarGame
{
    class Primitives
    {
        Texture2D pixel;
        List<Vector2> vectors;

        Color Colour;

        Vector2 Position;

        float Depth;

        public List<Vector2> Vectors
        {
            get { return vectors; }
        }

        public int CountVectors
        {
            get { return vectors.Count; }
        }

        public Texture2D Image
        {
            get { return pixel; }
        }
        public Primitives(GraphicsDevice device)
        {
            //Create pixel
            //pixel = new Texture2D(device, 1, 1, 1, TextureUsage.None, SurfaceFormat.Color);
            pixel = new Texture2D(device, 1,1, false, SurfaceFormat.Color);
            Color[] pixels = new Color[1];
            pixels[0] = Color.Yellow;
            pixel.SetData<Color>(pixels);

            Colour = Color.White;
            Position = new Vector2(0, 0);
            Depth = 0;

            vectors = new List<Vector2>();
        }

        public void AddVector(Vector2 vector)
        {
            vectors.Add(vector);
        }

        public void InsertVector(int index, Vector2 vector)
        {
            vectors.Insert(index, vector);
        }
        public void RemoveVector(int index)
        {
            vectors.RemoveAt(index);
        }


        
        public void Render(SpriteBatch spriteBatch)
        {
            if (vectors.Count < 2)
                return;

            for (int i = 1; i < vectors.Count; i++)
            {
                Vector2 vector1 = (Vector2)vectors[i - 1];
                Vector2 vector2 = (Vector2)vectors[i];

                //Calculate the distance between the two vectors
                float distance = Util.CalculateDistanceBetweenVectors(vector1, vector2);

                //Calculate the angle between the two vectors
                float angle = Util.CalculateAngleBetweenVectors(vector1, vector2);

                //streh the pixel between the two vectors
                spriteBatch.Draw(pixel,
                    Position + vector1,
                    null,
                    Colour,
                    angle,
                    Vector2.Zero,
                    new Vector2(distance, 1),
                    SpriteEffects.None,
                    Depth);
            }
        }

        public void CreateCircle(float radius, int sides, Vector2 position)
        {
            vectors.Clear();
            float max = 2 * (float)Math.PI;
            float step = max / (float)sides;
            for (float theta = 0; theta < max; theta += step)
            {
                vectors.Add(new Vector2(position.X +radius * (float)Math.Cos((double)theta),
                    position.Y + radius * (float)Math.Sin((double)theta)));
            }
            //then add the first vector again so it's coplete loop
            vectors.Add(new Vector2(position.X+radius * (float)Math.Cos(0),
                position.Y+radius * (float)Math.Sin(0)));
        }

    }
}
