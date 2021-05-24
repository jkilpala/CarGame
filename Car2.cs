using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CarGame
{
    /// <summary>
    /// Class for all the information for a car
    /// </summary>
    class Car2
    {
        Texture2D img;
        Color[] carTextureData;

        Rectangle boundingRectangle;

        Vector2 position;

        float xSpeed;
        float oldXSpeed;
        float ySpeed;
        float oldYSpeed;
        float testX;
        float testY;

        float fSpeed;

        float mass;

        float maxSpeed;

        float rotation;

        bool skiding = false;

        //Time 
        int seconds;
        int millisecodns = 0;
        float intervall = 1000f;

        //NEW VARIABLES
        int n_Mass = 10;
        float min_Spin = 1;       //1
        float max_torque = 0.12f;//0.3f;
        float max_acel;
        float turnRadius;
        float drag;
        float heading;
        float spin;
        float spinImpact;
        float spinDrag;
        Vector2 vel;
        float _accel;
        float _turn;

        public float Rotation
        {
            get { return rotation; }
        }
        public Boolean Skiding
        {
            get { return skiding; }
        }
        public int Seconds
        {
            get { return seconds; }
        }
        public int MilliSeconds
        {
            get { return millisecodns; }
        }
        public Vector2 Position
        {
            get { return position; }
        }
        public Rectangle BoundingRectangle
        {
            get { return boundingRectangle; }
        }
        public Color[] CarTextureData
        {
            get { return carTextureData; }
        }


        public Car2(Texture2D t2D)
        {
            img = t2D;
            position = new Vector2(200, 500);
            carTextureData = new Color[img.Width * img.Height];
            img.GetData(carTextureData);
            rotation = 0;
            xSpeed = 0;
            ySpeed = 0;
            fSpeed = 0.5f;
            seconds = 0;

            max_acel = 0.2f; //0.6f;
            turnRadius = 80; //90
            drag = 0.05f;
            spinDrag = 0.00002f;//0.0002f; 

            vel = new Vector2(0, 0);
            heading = 0;
            spin = 0;
            _accel = 0;
            _turn = 0;
            spinImpact = 0;

        }





        #region controls
        
        //Set drag
        public void SetDrag(float[] adrag)
        {
            drag = adrag[0];
            spinDrag = adrag[1];
        }
        public void SetAccel(float accel)
        {
            this.max_acel = accel;
        }
        //Forward and reverse
        public void ForwardOn()
        {
            this._accel = 1;
        }
        public void ForwardOff()
        {
            this._accel = 0;
        }
        public void ReverseOn()
        {
            this._accel = -1;
        }
        public void ReverseOff()
        {
            this._accel = 0;
        }
        //Left and right
        public void RightTurnOn()
        {
            this._turn = 1.5f;
        }

        public void RightTurnOff()
        {
            this._turn = 0;
        }

        public void LeftTurnOn()
        {
            this._turn = -1.5f;
        }
        public void LeftTurnOff()
        {
            this._turn = 0;
        }
        #endregion


        public void TurnCar(bool right)
        {
            if (right)
            {
                if (rotation == 1)
                    rotation = 360;
                else
                    rotation -= 1;
            }
            else
            {
                if (rotation == 359)
                    rotation = 0;
                else
                    rotation += 1;
            }
        }
        public void Accelerate()
        {
            fSpeed += 0.1f;
            if (fSpeed > 1f)
                fSpeed = 1f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Vector2 carOrigin = new Vector2(10, 7);
            spriteBatch.Draw(img, position, null, Color.White, rotation, carOrigin, 1, SpriteEffects.None, 1);
            // spriteBatch.Draw(img, new Vector2(0, 0), null, Color.Green, rotation, cannonOrigin, 1,SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            millisecodns += gameTime.ElapsedGameTime.Milliseconds;
            if (millisecodns >= intervall)
            {
                seconds += 1;
                millisecodns = 0;
            }

            boundingRectangle = new Rectangle((int)position.X, (int)position.Y, img.Width, img.Height);
            //Get headin
            //
            //Add drag
            vel.X *= (1 - drag);
            vel.Y *= (1 - drag);

            spinImpact *= spinDrag;
            if (Math.Abs(spinImpact) <= 0) //1)
            {
                spinImpact = 0;
            }

            heading = rotation;

            //Add acceleration
            vel.X += (float)Math.Sin(heading) * _accel * max_acel;
            vel.Y -= (float)Math.Cos(heading) * _accel * max_acel;
            float velMag = (float)Math.Sqrt(vel.X * vel.X + vel.Y * vel.Y);
            spin = velMag / turnRadius * _turn;
            
            //Calculate torque(turnin the car changes the direction it travels)
            Vector2 torque = Vector2.Zero;
            float newHeadin = heading + spin + spinImpact;
            
            torque.X = (float)Math.Sin(newHeadin) * velMag - vel.X;
            torque.Y = (float)-Math.Cos(newHeadin) * velMag - vel.Y;

            float torqueMag = (float)Math.Sqrt(Math.Pow(torque.X, 2) + Math.Pow(torque.Y, 2));

            //Limit torque, so the car will "spin out" if turning too fast
            if (torqueMag > max_torque)
            {
                torque.X = max_torque * torque.X / (torqueMag+2f);
                torque.Y = max_torque * torque.Y / (torqueMag+2f);
                System.Diagnostics.Debug.WriteLine("SCREEEEEK");
                skiding = true;
            }
            else
                skiding = false;

            vel.X += torque.X;
            vel.Y += torque.Y;

            position.X += vel.X;
            position.Y += vel.Y;

            heading = newHeadin;
            if (heading >= MathHelper.ToRadians(360))
                heading -= MathHelper.ToRadians(360);
            if (heading <= MathHelper.ToRadians(0))
                heading += MathHelper.ToRadians(360);
            rotation = heading;

        }
    }
}
