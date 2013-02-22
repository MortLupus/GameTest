using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    /// <summary>
    ///     This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private Texture2D _myTexture;
        private Vector2 _spritePosition;
        private Vector2 _spriteSpeed;
        private SpriteBatch _spriteBatch;
        private int _screenWidth;
        private int _screenHeight;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferHeight = 500;
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            Window.Title = "test";


            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            var device = _graphics.GraphicsDevice;

            _screenWidth = device.PresentationParameters.BackBufferWidth;
            _screenHeight = device.PresentationParameters.BackBufferHeight;

            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _spritePosition = Vector2.Zero;
            _spriteSpeed = new Vector2(50.0f, 50.0f);


            _myTexture = Content.Load<Texture2D>("bitmap1");
        }

        
        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     all content.
        /// </summary>
        protected override void UnloadContent()
        {

            Content.Unload();
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState(PlayerIndex.One).GetPressedKeys().Any(x => x == Keys.Space))
                Exit();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            _spritePosition += _spriteSpeed*(float) gameTime.ElapsedGameTime.TotalSeconds;

            int maxX = _graphics.GraphicsDevice.Viewport.Width - _myTexture.Width;
            int minX = 0;
            int maxY = _graphics.GraphicsDevice.Viewport.Height - _myTexture.Height;
            int minY = 0;

            // Check for bounce.
            if (_spritePosition.X > maxX)
            {
                _spriteSpeed.X *= -1;
                _spritePosition.X = maxX;
            }

            else if (_spritePosition.X < minX)
            {
                _spriteSpeed.X *= -1;
                _spritePosition.X = minX;
            }

            if (_spritePosition.Y > maxY)
            {
                _spriteSpeed.Y *= -1;
                _spritePosition.Y = maxY;
            }

            else if (_spritePosition.Y < minY)
            {
                _spriteSpeed.Y *= -1;
                _spritePosition.Y = minY;
            }


            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            _spriteBatch.Draw(_myTexture, _spritePosition, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawScenery()
        {

        }

    }
}