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

        private Texture2D Pacman;

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
            _PacmanRightt = Content.Load<Texture2D>("Pac-2");
            _Pacmanleft = Content.Load<Texture2D>("Pac-3");

            Pacman = _PacmanAvant;




            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !Keyboard.GetState().IsKeyDown(Keys.Right))

            {
                Pacman =  _Pacmanleft;
                positionPacman.X = System.Math.Max(positionPacman.X -
                    gameTime.ElapsedGameTime.Milliseconds * 0.5f, 0.0f);

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && !Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Pacman= _PacmanRightt;
                positionPacman.X = System.Math.Min(positionPacman.X + gameTime.ElapsedGameTime.Milliseconds * 0.5f, _graphics.GraphicsDevice.Viewport.Width - Pacman.Width);

            }
            else
                Pacman = _PacmanAvant;

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && !Keyboard.GetState().IsKeyDown(Keys.Down))

            {

               positionPacman.Y = System.Math.Max(positionPacman.Y - gameTime.ElapsedGameTime.Milliseconds * 0.5f, 0.0f);

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && !Keyboard.GetState().IsKeyDown(Keys.Up))
            {

               positionPacman.Y = System.Math.Min(positionPacman.Y + gameTime.ElapsedGameTime.Milliseconds * 0.5f, _graphics.GraphicsDevice.Viewport.Width - Pacman.Width);
            }


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

            _spriteBatch.Draw(Pacman, positionPacman, Color.White);
      




            _spriteBatch.End();

        base.Draw(gameTime);
        }
    }
}
