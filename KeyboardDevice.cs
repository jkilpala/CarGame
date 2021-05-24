using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace CarGame
{
    public class KeyboardDevice : InputDevice<KeyboardState>
    {
        //The last and current KeyboardStates
        KeyboardState last;
        KeyboardState current;

        //The keys that were pressed in the current state
        Keys[] currentKeys;

        //Public properties for the above members
        public override KeyboardState State
        {
            get { return current; }
        }
        public Keys[] PressedKeys
        {
            get { return currentKeys; }
        }

        //Events for when a key is pressed, released, and held. This
        //event can be handled by our InputEventHandler class
        public event InputEventHandler<Keys, KeyboardState> KeyPressed;
        public event InputEventHandler<Keys, KeyboardState> KeyReleased;
        public event InputEventHandler<Keys, KeyboardState> KeyHeld;

        //Constructor sets up the current state and updates for the 
        //first time
        public KeyboardDevice()
        {
            current = Keyboard.GetState();
            Update();
        }

        public void Update()
        {
            //Set the last staate to the current one and update the
            //current state
            last = current;
            current = Keyboard.GetState();

            //Set the currently pressed key to the keys defined in 
            //the current state
            currentKeys = current.GetPressedKeys();

            //For every key on the keyboard...
            foreach (Keys key in Util.GetEnumValues<Keys>())
            {
                //If it is a new key press (this is the first frame
                //it is down), trigger the corresponding event
                if (WasKeyPressed(key))
                    if (KeyPressed != null)
                        KeyPressed(this, new InputDeviceEventArgs
                            <Keys, KeyboardState>(key, this));

                //If it was just released(this is the first frame
                //it is up), trigger the corresponding event
                if (WasKeyReleased(key))
                    if (KeyReleased != null)
                        KeyReleased(this, new InputDeviceEventArgs
                        <Keys, KeyboardState>(key, this));
                //If it has been held (it has been down for more
                //than one frame), trigger the corresponding event
                if (WasKeyHeld(key))
                    if (KeyHeld != null)
                        KeyHeld(this, new InputDeviceEventArgs
                            <Keys, KeyboardState>(key, this));
            }
        }

        //Functions for states

        //Whether the specified key is currently down
        public bool IsKeyDown(Keys Key)
        {
            return current.IsKeyDown(Key);
        }

        //Whether the specified key is currently up
        public bool IsKeyUp(Keys Key)
        {
            return current.IsKeyUp(Key);
        }

        //Whether the specified key is down for the first time
        //this frame
        public bool WasKeyPressed(Keys Key)
        {
            if (last.IsKeyUp(Key) && current.IsKeyDown(Key))
                return true;
            return false;
        }

        //Whether the specified key is up for the first time
        //this frame
        public bool WasKeyReleased(Keys Key)
        {
            if (last.IsKeyDown(Key) && current.IsKeyUp(Key))
                return true;

            return false;
        }

        //Wheather the specified key has been down for more than 
        //one frame
        public bool WasKeyHeld(Keys Key)
        {
            if (last.IsKeyDown(Key) && current.IsKeyDown(Key))
                return true;

            return false;
        }
    }
}
