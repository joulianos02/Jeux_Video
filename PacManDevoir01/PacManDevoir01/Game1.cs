using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacManDevoir01
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        // Creation du texture2D spriteBatch,ArrierePaln,PacmanAvant
        private SpriteBatch _spriteBatch;
        private Texture2D _arrierePlan;
        private Texture2D _PacmanAvant;
        // Creation du texture2D  pour les pacman
        private Texture2D PacManRight1;
        private Texture2D PacManRight2;
        private Texture2D PacManLeft1;
        private Texture2D PacManLeft2;
        private Texture2D PacmanUP;
        private Texture2D PacMandown;
        // Creation du texture2D  pour les pacman
        private Texture2D Ghost1;
        private Texture2D Cherry;
        private Texture2D Pacman;
      
        // Creation des vector
        Vector2 positionPacman;
        Vector2 positionGhost;
        Vector2 positionCherry;
        Vector2 poisitionBackGround;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
          
    }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            poisitionBackGround = new Vector2(10f, 10f);
            poisitionBackGround.X = 0.0f;
            poisitionBackGround.Y = 0.0f; 

            //la Position de PacMan
            positionPacman = new Vector2(100.0f, 100.0f);
            positionPacman.X = 325.0f;
            positionPacman.Y = 325.0f;
            //Possitionment de Ghost sur le background
            positionGhost = new Vector2(100.0f, 100.0f);
            positionGhost.X = 40.0f;
            positionGhost.Y = 40.0f;
            //Position de la cherry
            positionCherry = new Vector2(100.0f, 100.0f);
            positionCherry.X = 400.0f;
            positionCherry.Y = 40.0f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _arrierePlan = Content.Load<Texture2D>("plateau");


            _PacmanAvant = Content.Load<Texture2D>("Pac-1");
            //
            PacManRight2 = Content.Load<Texture2D>("Pac-2");
            PacManRight1 = Content.Load<Texture2D>("Pac-3");
            //
            PacManLeft1 = Content.Load<Texture2D>("Pac-2 UP Left");
            //
            PacmanUP = Content.Load<Texture2D>("Pac-2 Up");
            //
            PacMandown = Content.Load<Texture2D>("Pac-2 Down");
            //
            Ghost1 = Content.Load<Texture2D>("ghost-r1");
            Cherry = Content.Load<Texture2D>("cherry");


            Pacman = _PacmanAvant;
            




            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !Keyboard.GetState().IsKeyDown(Keys.Right))

            {
                Pacman = PacManLeft1;
               
                positionPacman.X = System.Math.Max(positionPacman.X -
                    gameTime.ElapsedGameTime.Milliseconds * 0.5f, 0.0f);

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && !Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Pacman= PacManRight2;
                positionPacman.X = System.Math.Min(positionPacman.X + gameTime.ElapsedGameTime.Milliseconds * 0.5f, _graphics.GraphicsDevice.Viewport.Width - Pacman.Width);

            }
            else
                Pacman = _PacmanAvant;

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && !Keyboard.GetState().IsKeyDown(Keys.Down))

            {
                Pacman = PacmanUP;
               positionPacman.Y = System.Math.Max(positionPacman.Y - gameTime.ElapsedGameTime.Milliseconds * 0.5f, 0.0f);

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && !Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Pacman = PacMandown;
               positionPacman.Y = System.Math.Min(positionPacman.Y + gameTime.ElapsedGameTime.Milliseconds * 0.5f, _graphics.GraphicsDevice.Viewport.Width - Pacman.Width);
            }


           
            if (poisitionBackGround.Y > _graphics.GraphicsDevice.Viewport.Height) 
                poisitionBackGround.Y -= _arrierePlan.Height;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

            _spriteBatch.Draw(_arrierePlan,
                position: new Vector2(poisitionBackGround.X, poisitionBackGround.Y - _arrierePlan.Height)
                , Color.White);

            _spriteBatch.Draw(_arrierePlan, position: poisitionBackGround, Color.White);

            _spriteBatch.Draw(_arrierePlan, position: Vector2.Zero, Color.White);


            //pacMan
            _spriteBatch.Draw(_arrierePlan, poisitionBackGround, Color.White);
            _spriteBatch.Draw(Pacman, positionPacman, Color.White);
            _spriteBatch.Draw(Ghost1, positionGhost, Color.White);
            _spriteBatch.Draw(Cherry, positionCherry, Color.White);
           









            _spriteBatch.End();

        base.Draw(gameTime);
        }
    }
}
