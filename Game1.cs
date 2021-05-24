using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CarGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        //TESTI ALUE
        //Checkpoint2 cp1;
        Checkpoint cp;
        //Car car1;
        Input input;
        CurrentTrack currentTrack;
        //Test for lines etc.
        Primitives brush;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _graphics.PreferredBackBufferWidth = 1280; //_graphics.GraphicsDevice.DisplayMode.Width;//1280;  //1280
            _graphics.PreferredBackBufferHeight = 1024; //_graphics.GraphicsDevice.DisplayMode.Height;//1024;
            //_graphics.IsFullScreen = true;           
            _graphics.ApplyChanges();
            // TODO: use this.Content to load your game content here
            currentTrack = new CurrentTrack(Content, _graphics.GraphicsDevice);
            input = new Input();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            currentTrack.Update(input,gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            currentTrack.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
