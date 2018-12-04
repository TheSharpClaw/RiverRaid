using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.IO;

namespace RiverRaid
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        StateManager manager;

        public Game1()
        {
            Globals.graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            Globals.graphics.PreferredBackBufferWidth = 160;
            Globals.graphics.PreferredBackBufferHeight = 240;
            Globals.graphics.SupportedOrientations = DisplayOrientation.Portrait | DisplayOrientation.PortraitDown;

            Globals.gameWindowSize = new Vector2(Globals.graphics.PreferredBackBufferWidth, Globals.graphics.PreferredBackBufferHeight);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Globals.graphics.IsFullScreen = true;
            Globals.graphics.ApplyChanges();

            Globals.screenResolution = new Vector2(Globals.graphics.GraphicsDevice.Viewport.Width, Globals.graphics.GraphicsDevice.Viewport.Height);

            Globals.scaleX = Globals.screenResolution.X / Globals.gameWindowSize.X;
            Globals.scaleY = Globals.screenResolution.Y / Globals.gameWindowSize.Y;

            Globals.Scale = Matrix.CreateScale(new Vector3(Globals.scaleX, Globals.scaleY, 1));

            base.Initialize();
        }

        private List<string> LoadLevel(string levelPath)
        {
            using (var stream = TitleContainer.OpenStream(levelPath))
            {
                using (var reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();

                    List<string> levelRows = new List<string>();

                    while (line != null)
                    {
                        if (!String.IsNullOrEmpty(line))
                        {
                            levelRows.Add(line);
                        }
                        line = reader.ReadLine();
                    }

                    return levelRows;
                }
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            #region Cores
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            manager = new StateManager();
            #endregion

            #region Fonts
            Globals.defaultFont = Content.Load<SpriteFont>("fonts/font");
            #endregion

            #region Level
            Globals.levelStartPath = Path.Combine(Content.RootDirectory, "tileMapStart.txt");
            Globals.level1Path = Path.Combine(Content.RootDirectory, "tileMap1.txt");
            Globals.level2Path = Path.Combine(Content.RootDirectory, "tileMap2.txt");
            Globals.level3Path = Path.Combine(Content.RootDirectory, "tileMap3.txt");
            Globals.level4Path = Path.Combine(Content.RootDirectory, "tileMap4.txt");

            Globals.levelStartRows = LoadLevel(Globals.levelStartPath);
            Globals.level1Rows = LoadLevel(Globals.level1Path);
            Globals.level2Rows = LoadLevel(Globals.level2Path);
            Globals.level3Rows = LoadLevel(Globals.level3Path);
            Globals.level4Rows = LoadLevel(Globals.level4Path);
            #endregion

            #region Songs

            #endregion

            #region SoundEffects

            #endregion

            #region Textures2D
            Globals.airplane = Content.Load<Texture2D>("textures/airplane");
            Globals.airplaneLeft = Content.Load<Texture2D>("textures/airplaneLeft");
            Globals.airplaneRight = Content.Load<Texture2D>("textures/airplaneRight");
            Globals.background = Content.Load<Texture2D>("textures/background");
            Globals.buttonLeft = Content.Load<Texture2D>("textures/buttonLeft");
            Globals.buttonRight = Content.Load<Texture2D>("textures/buttonRight");
            Globals.buttonShoot = Content.Load<Texture2D>("textures/buttonShoot");
            Globals.bullet = Content.Load<Texture2D>("textures/bullet");
            Globals.enemyHelicopter = Content.Load<Texture2D>("textures/enemyHelicopter");
            Globals.enemyPlane = Content.Load<Texture2D>("textures/enemyPlane");
            Globals.enemyShip = Content.Load<Texture2D>("textures/enemyShip");
            Globals.fuel = Content.Load<Texture2D>("textures/fuel");
            Globals.fuelBar = Content.Load<Texture2D>("textures/fuelBar");
            Globals.fuelPointer = Content.Load<Texture2D>("textures/fuelPointer");
            Globals.gui = Content.Load<Texture2D>("textures/gui");

            #region Tiles
            Globals.enlargementLeftBig = Content.Load<Texture2D>("textures/tiles/enlargmentLeftBig");
            Globals.enlargementLeftSmall = Content.Load<Texture2D>("textures/tiles/enlargmentLeftSmall");
            Globals.enlargementRightBig = Content.Load<Texture2D>("textures/tiles/enlargmentRightBig");
            Globals.enlargementRightSmall = Content.Load<Texture2D>("textures/tiles/enlargmentRightSmall");
            Globals.ground = Content.Load<Texture2D>("textures/tiles/ground");
            Globals.narrowingLeftBig = Content.Load<Texture2D>("textures/tiles/narrowingLeftBig");
            Globals.narrowingLeftSmall = Content.Load<Texture2D>("textures/tiles/narrowingLeftSmall");
            Globals.narrowingRightBig = Content.Load<Texture2D>("textures/tiles/narrowingRightBig");
            Globals.narrowingRightSmall = Content.Load<Texture2D>("textures/tiles/narrowingRightSmall");
            Globals.roadDown = Content.Load<Texture2D>("textures/tiles/roadDown");
            Globals.roadMiddle = Content.Load<Texture2D>("textures/tiles/roadMiddle");
            Globals.roadUp = Content.Load<Texture2D>("textures/tiles/roadUp");
            Globals.water = Content.Load<Texture2D>("textures/tiles/water");
            #endregion
            #endregion
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Globals.exit == true)
                Exit();

            manager.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            base.Draw(gameTime);
        }
    }
}
