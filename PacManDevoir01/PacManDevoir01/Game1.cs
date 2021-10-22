using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace PacManDevoir01
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        // Creation du texture2D spriteBatch,ArrierePaln,PacmanAvant
        private SpriteBatch _spriteBatch;
        private Texture2D _arrierePlan;
        
        // Creation du texture2D  pour les pacman
        private Texture2D cherryTexture;
        private Texture2D pacmanTexture;
        private Texture2D ghostTexture;
      
        //Hitboxes
        private FormeEnglobante pacmanHitbox;
        
        //cerises
        private FormeEnglobante cherryHitbox;
        private FormeEnglobante cherryHitbox2;
        private FormeEnglobante cherryHitbox3;
        private FormeEnglobante cherryHitbox4;
        
        private FormeEnglobante ghostHitbox;

        //paramètres cerises mangées ou pas
        private bool cherry1Eaten = false;
        private bool cherry2Eaten = false;
        private bool cherry3Eaten = false;
        private bool cherry4Eaten = false;

        private double TempsEcoule = 0;
        private const double MouvementGhost = 1.0; //en secondes
        private int ghostDirection = 0;


        // Creation des vector
        Vector2 positionPacman;
        Vector2 positionGhost;
        Vector2 positionCherry;
        Vector2 positionCherry2;
        Vector2 positionCherry3;
        Vector2 positionCherry4;
        Vector2 poisitionBackGround;

        //Animation pacman
        private Animation chomp = new Animation(new int[] { 0, 1, 2, 1 }, interval: 100);
        private Animation standStill = new Animation(new int[] { 0 }, interval: 1);
        private Animation AnimationPlaying;

        private SpriteEffects LeftOrRight;
        private float rotation;

        private Palette pacmanSprite;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
          
    }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 685;
            _graphics.PreferredBackBufferHeight = 757;
            _graphics.ApplyChanges();
            
            // position du backGround ...
            poisitionBackGround = new Vector2(10f, 10f);
            poisitionBackGround.X = 0.0f;
            poisitionBackGround.Y = 0.0f; 
            
            //la Position de PacMan
            positionPacman = new Vector2(100.0f, 100.0f);
            positionPacman.X = 325.0f;
            positionPacman.Y = 325.0f;
            
            AnimationPlaying = standStill;
            

            //Possitionment de Ghost sur le background
            positionGhost = new Vector2(100.0f, 100.0f);
            
            //Position de la cherry
            positionCherry = new Vector2(400.0f, 40.0f);
            positionCherry2 = new Vector2(55f, 500f);
            positionCherry3 = new Vector2(35f, 120f);
            positionCherry4 = new Vector2(550f, 685f);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // load les image png
            //plateau
            _arrierePlan = Content.Load<Texture2D>("plateau");
            
            //front PacMan
            pacmanTexture = Content.Load<Texture2D>("pacman");
            pacmanSprite = new Palette(pacmanTexture, 32, 32);

            //Ghost & Cherry load
            ghostTexture = Content.Load<Texture2D>("ghost");
            cherryTexture = Content.Load<Texture2D>("cherry");
 
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // ajoute de les touche pour le pacman (left & right)
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                AnimationPlaying = chomp;
                LeftOrRight = SpriteEffects.FlipHorizontally;
                rotation = 0;

                positionPacman.X = Math.Max(positionPacman.X -
                    gameTime.ElapsedGameTime.Milliseconds * 0.5f, 16);

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && !Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                AnimationPlaying = chomp;
                LeftOrRight = SpriteEffects.None;
                rotation = 0;

                positionPacman.X = System.Math.Min(positionPacman.X + gameTime.ElapsedGameTime.Milliseconds * 0.5f, _graphics.GraphicsDevice.Viewport.Width - 16);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && !Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                AnimationPlaying = chomp;
                LeftOrRight = SpriteEffects.None;
                rotation = 3 * MathHelper.Pi / 2;

                positionPacman.Y = System.Math.Max(positionPacman.Y - gameTime.ElapsedGameTime.Milliseconds * 0.5f, 16);

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && !Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                AnimationPlaying = chomp;
                LeftOrRight = SpriteEffects.None;
                rotation = MathHelper.Pi / 2;
                positionPacman.Y = System.Math.Min(positionPacman.Y + gameTime.ElapsedGameTime.Milliseconds * 0.5f, _graphics.GraphicsDevice.Viewport.Height - 16);
            }
            else
            {
                AnimationPlaying = standStill;
            }

            TempsEcoule += gameTime.ElapsedGameTime.TotalSeconds;

            if (TempsEcoule >= MouvementGhost){
                TempsEcoule -= MouvementGhost;
                Random ran = new Random();
                ghostDirection = ran.Next(4);    
            }

            switch(ghostDirection){
                //Déplace le fantome vers la gauche
                case 0:
                    positionGhost.X = Math.Max(positionGhost.X -
                    gameTime.ElapsedGameTime.Milliseconds * 0.5f, 16);
                    break;
                
                //Déplace le fantome vers la droite
                case 1:
                   positionGhost.X = Math.Min(positionGhost.X + 
                   gameTime.ElapsedGameTime.Milliseconds * 0.5f, _graphics.GraphicsDevice.Viewport.Width - 32); 
                    break;
                
                //Déplace le fantome vers le haut
                case 2:
                    positionGhost.Y = Math.Max(positionGhost.Y - 
                    gameTime.ElapsedGameTime.Milliseconds * 0.5f, 16);
                    break;

                //Déplace le fantome vers le bas
                case 3:
                    positionGhost.Y = Math.Min(positionGhost.Y + 
                    gameTime.ElapsedGameTime.Milliseconds * 0.5f, _graphics.GraphicsDevice.Viewport.Height - 32);
                    break;
                
                default:
                    break;
            }

            if (poisitionBackGround.Y > _graphics.GraphicsDevice.Viewport.Height) 
                poisitionBackGround.Y -= _arrierePlan.Height;

            
            pacmanHitbox = new FormeEnglobante(positionPacman - new Vector2(16, 16), 32, 32);

            cherryHitbox = new FormeEnglobante(positionCherry - new Vector2(16, 16), 32, 32);
            cherryHitbox2 = new FormeEnglobante(positionCherry2 - new Vector2(16, 16), 32, 32);
            cherryHitbox3 = new FormeEnglobante(positionCherry3 - new Vector2(16, 16), 32, 32);
            cherryHitbox4 = new FormeEnglobante(positionCherry4 - new Vector2(16, 16), 32, 32);
            
            ghostHitbox = new FormeEnglobante(positionGhost - new Vector2(16, 16), 32, 32);
            
            AnimationPlaying.Update(gameTime);
            
            //Détection de collision avec les cerises
            if (pacmanHitbox.EnCollisionAvec(cherryHitbox)) {
                cherry1Eaten = true;
            }

            if (pacmanHitbox.EnCollisionAvec(cherryHitbox2)) {
                cherry2Eaten = true;
            }

            if (pacmanHitbox.EnCollisionAvec(cherryHitbox3)) {
                cherry3Eaten = true;
            }

            if (pacmanHitbox.EnCollisionAvec(cherryHitbox4)) {
                cherry4Eaten = true;
            }

            if (pacmanHitbox.EnCollisionAvec(ghostHitbox)){
                   this.Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
            //spriteBatch.Draw pour les Background et sa position
            
            _spriteBatch.Draw(_arrierePlan,
                position: new Vector2(poisitionBackGround.X, poisitionBackGround.Y - _arrierePlan.Height)
                , Color.White);

            _spriteBatch.Draw(_arrierePlan, position: poisitionBackGround, Color.White);

            _spriteBatch.Draw(_arrierePlan, position: Vector2.Zero, Color.White);


            //SpriteBatch.Draw pour pacMan, Chost, Cherry
            _spriteBatch.Draw(_arrierePlan, poisitionBackGround, Color.White);

            _spriteBatch.Draw(
                pacmanTexture, 
                destinationRectangle: new Rectangle((int)positionPacman.X, (int)positionPacman.Y, 32, 32),
                sourceRectangle: pacmanSprite.SourceRect(AnimationPlaying.CurrentFrame), 
                Color.White,
                rotation: rotation,
                origin: new Vector2(16f, 16f),
                effects: LeftOrRight,
                layerDepth: 0);
            
            //Paramètre de direction pour l'affichage

            _spriteBatch.Draw(ghostTexture, positionGhost,Color.White); 
            
            //Affiche les cerises si elle ne sont pas mangées
            if (!cherry1Eaten)
                _spriteBatch.Draw(cherryTexture, positionCherry, Color.White);

            if(!cherry2Eaten)
                _spriteBatch.Draw(cherryTexture, positionCherry2, Color.White);

            if(!cherry3Eaten)
                _spriteBatch.Draw(cherryTexture, positionCherry3, Color.White);
            
            if(!cherry4Eaten)
                _spriteBatch.Draw(cherryTexture, positionCherry4, Color.White);

            _spriteBatch.End();

        base.Draw(gameTime);
        }
    }
}
