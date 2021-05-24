using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace CarGame
{
    class Input
    {
        KeyboardDevice keyboard;

        public Input()
        {
            keyboard = new KeyboardDevice();
        }

        // public void getInput(Car pcar)
        // {
        //     keyboard.Update();
        //     if (keyboard.IsKeyDown(Keys.S))
        //     {
        //         System.Diagnostics.Debug.WriteLine("Key was pressed");
        //     }
        //     else if (keyboard.IsKeyDown(Keys.W))
        //     {
        //         //System.Diagnostics.Debug.WriteLine("Key was pressed");
        //         pcar.Accelerate();
        //     }
        //     if (keyboard.IsKeyDown(Keys.D))
        //     {
        //         pcar.TurnCar(false);
        //     }
        //     if (keyboard.IsKeyDown(Keys.A))
        //     {
        //         pcar.TurnCar(true);
        //     }
            
        // }
        public void getNewInput(Car2 pcar)
        {
            keyboard.Update();
            //BACK
            if (keyboard.IsKeyDown(Keys.S))
            {
                pcar.ReverseOn();
            }
            if (keyboard.WasKeyReleased(Keys.S))
                pcar.ReverseOff();
            //FORWARD
            if (keyboard.IsKeyDown(Keys.W))
            {
                pcar.ForwardOn();
            }
            if (keyboard.WasKeyReleased(Keys.W))
                pcar.ForwardOff();
            //LEFT
            if (keyboard.IsKeyDown(Keys.A))
            {
                pcar.LeftTurnOn();
               
            }
            if (keyboard.WasKeyReleased(Keys.A))
                pcar.LeftTurnOff();
            //RIGHT
            if (keyboard.IsKeyDown(Keys.D))
            {
                pcar.RightTurnOn();
                
            }
            if (keyboard.WasKeyReleased(Keys.D))
                pcar.RightTurnOff();

        }
    }
}
