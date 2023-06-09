﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TileMaps
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;

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
            _gameManager = new GameManager(this._graphics.GraphicsDevice);
            Globals.Content = Content;
            Globals.WindowSize = new(768, 448);
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            _graphics.ApplyChanges();

        }

        protected override void LoadContent()
        {
            // ladda in alla texturer och lägg dem i Global.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.spriteBatch = _spriteBatch;
            Globals.Tilemap = Content.Load<Texture2D>("Texture/Grass");
            Globals.PlayerSprite = Content.Load<Texture2D>("Texture/Player");
            Globals.StenSprite = Content.Load<Texture2D>("Texture/Props");
            Globals.font = Content.Load<SpriteFont>("sprite");
            Globals.StructTexture = Content.Load<Texture2D>("Texture/Struct");
            Globals.ArrowTexture = Content.Load<Texture2D>("arrow");
            Globals.StartScreen = Content.Load<Texture2D>("start");
            Globals.TeacherCat = Content.Load<Texture2D>("teacher");
           
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _gameManager.Update(gameTime);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            if (!Globals.Lose) _gameManager.Draw();
            else { _gameManager.Lose(); }
            base.Draw(gameTime);
        }
    }
}