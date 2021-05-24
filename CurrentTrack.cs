using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CarGame
{
    class CurrentTrack
    {
        short numOfCheckPoints;

        List<Checkpoint> checkPointList;
        //List<Car> carList;
        Track track1;

        Ui UI;
        //Testi
        LoadSaveTrackInfo lsInfo;
        TrackInfo trackInfo;

        //TESTI
        Car2 car2;
        Texture2D skid;
        List<Skid> skidList;
        //Ai track
        //AiRoute aiRoute;
        //Ai ai;
        //Ai car
        Car2 carAi;

        public CurrentTrack(ContentManager content, GraphicsDevice device)
        {

            
            UI = new Ui(content);
            checkPointList = new List<Checkpoint>();
            //carList = new List<Car>();
            //Testi
            checkPointList.Add(new Checkpoint(content.Load<Texture2D>("Textures/Check")));
            checkPointList.Add(new Checkpoint(content.Load<Texture2D>("Textures/Check")));
            checkPointList.Add(new Checkpoint(content.Load<Texture2D>("Textures/Check")));
            checkPointList.Add(new Checkpoint(content.Load<Texture2D>("Textures/Check")));
            checkPointList.Add(new Checkpoint(content.Load<Texture2D>("Textures/Check")));

            foreach (Checkpoint cp in checkPointList)
            {
                cp.BoundinRectangle();
            }
            //carList.Add(new Car(content.Load<Texture2D>("Textures/car1")));
            //carList.Add(new Car(content.Load<Texture2D>("Textures/car1")));
            //Lisätään 5 check pointtia
            track1 = new Track(content.Load<Texture2D>("Textures/track1"));
            
            //Testi
            car2 = new Car2(content.Load<Texture2D>("Textures/car1"));

            lsInfo = new LoadSaveTrackInfo();
            trackInfo = new TrackInfo();

            lsInfo.Save(trackInfo);
            
            skid = content.Load<Texture2D>("Textures/skid");
            skidList = new List<Skid>();

            //AI ROUTES
            //aiRoute = new AiRoute(device);
            //ai = new Ai(aiRoute, content);
            //Ai car
            carAi = new Car2(content.Load<Texture2D>("Textures/car1"));
            carAi.SetAccel(1.0f);

        }


        public void Update(Input input, GameTime gameTime)
        {
            //Testi
            car2.Update(gameTime);
            if(car2.Skiding)
                skidList.Add(new Skid(skid,car2.Position));
            
            // foreach (Car car in carList)
            // {
            //     car.Update(gameTime);
            // }

            // foreach (Car car in carList)
            // {

            //     foreach (Checkpoint cp in checkPointList)
            //     {
            //         cp.CheckCollision(car.BoundingRectangle, car.CarTextureData);
            //         //System.Diagnostics.Debug.WriteLine(car);
            //     }
            // }
            //foreach (Car car in carList)
            //{
            //    track1.CheckRoadSurface(car.BoundingRectangle, car.CarTextureData, car.Position.X, car.Position.Y);
            //}

            //input.getInput(carList[0]);
            //Testi
            input.getNewInput(car2);

            //Time Update
            //UI.PlayerSeconds = carList[0].Seconds;
            //UI.PlayerMilliseconds = carList[0].MilliSeconds;
            car2.SetDrag(track1.CheckRoadSurface(car2.BoundingRectangle, car2.CarTextureData, car2.Position.X, car2.Position.Y));
               
            //Ai
            //ai.Update(car2);
            carAi.Update(gameTime);
            carAi.SetDrag(track1.CheckRoadSurface(car2.BoundingRectangle, car2.CarTextureData, car2.Position.X, car2.Position.Y));
            //ai.Update(carAi);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            track1.Draw(spriteBatch);
            
            foreach (Checkpoint cp in checkPointList)
            {
                cp.Draw(spriteBatch);
            }
            foreach (Skid sk in skidList)
            {
                sk.Draw(spriteBatch);
            }
            // foreach (Car car in carList)
            // {
            //     car.Draw(spriteBatch);
            // }
            UI.Draw(spriteBatch);
            
            car2.Draw(spriteBatch);

            //Ai draw
            //ai.Draw(spriteBatch);
            //aiRoute.Draw(spriteBatch);

            carAi.Draw(spriteBatch);
        }


    }
}
