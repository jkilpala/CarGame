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
    /// Class to handle User interface
    /// </summary>
    class Ui
    {
        //Textures 
        Texture2D raceUI;
        //Fonts
        SpriteFont spriteFont;

        //Text positions
        Vector2 currentTrack = new Vector2(1000, 20);
        //Player time
        int playerSeconds;
        int playerMilliseconds;

        public Ui(ContentManager content)
        {
            raceUI = content.Load<Texture2D>("Textures/UI");
            spriteFont = content.Load<SpriteFont>("Font");
        }


        public int PlayerSeconds
        {
            set { playerSeconds = value; }
        }
        public int PlayerMilliseconds
        {
            set { playerMilliseconds = value; }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(raceUI,new Rectangle(0,0,raceUI.Width, raceUI.Height), Color.White);
            spriteBatch.DrawString(spriteFont, "Muu " +playerSeconds.ToString() +":" +playerMilliseconds.ToString(), currentTrack, Color.Gold);
        }

    }
}
