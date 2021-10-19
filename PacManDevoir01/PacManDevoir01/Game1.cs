using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacManDevoir01
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _arrierePlan;
        private Texture2D _PacmanAvant;
        private Texture2D _Pacmanleft;
        private Texture2D _PacmanRightt;

        Vector2 positionPacman;
       

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
          
    }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //la Position initiale du PacMan
            positionPacman = new Vector2(100.0f, 100.0f);
            positionPacman.X = 325.0f;
            positionPacman.Y = 325.0f;

            //


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _arrierePlan = Content.Load<Texture2D>("plateau");

            _PacmanAvant = Content.Load<Texture2D>("Pac-1");

        // TODO: use this.Content to load your game content here
    }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(_arrierePlan, position: Vector2.Zero, Color.White);
            //pacMan
        _spriteBatch.Draw(_PacmanAvant, positionPacman, Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
        }
    }
}
