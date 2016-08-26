using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sandbox_Game_Client.Content._Fonts;
using Sandbox_Game_Client.Resources;
using Sandbox_Game_Client.Resources._Entity;
using Sandbox_Game_Client.Resources._Menu;
using Sandbox_Game_Client.Resources._World;

namespace Sandbox_Game_Client
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Console.WriteLine("Width: " + graphics.PreferredBackBufferWidth);
            //Console.WriteLine("Height: " + graphics.PreferredBackBufferHeight);

            if ((int)Properties.Settings.Default.Resolution.X != graphics.PreferredBackBufferWidth || (int)Properties.Settings.Default.Resolution.Y != graphics.PreferredBackBufferHeight)
            {
                graphics.PreferredBackBufferWidth = (int)Properties.Settings.Default.Resolution.X;
                graphics.PreferredBackBufferHeight = (int)Properties.Settings.Default.Resolution.Y;
                graphics.ApplyChanges();
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Font.Regular = Content.Load<SpriteFont>("Regular");
            Font.Debug = Content.Load<SpriteFont>("Debug");

            Textures.PLAYER = new Texture2D[1] { Content.Load<Texture2D>("_Textures\\_LivingEntity\\Player.png") };

            Textures.GRASS = Content.Load<Texture2D>("_Textures\\_Entity\\Texture_Grass.jpg");
            Textures.DIRT = Content.Load<Texture2D>("_Textures\\_Entity\\Texture_Dirt.jpg");
            Textures.STONE = Content.Load<Texture2D>("_Textures\\_Entity\\Texture_Stone.jpg");
             
            Textures.CLOUDS = new Texture2D[1] { Content.Load<Texture2D>("_Textures\\_Clouds\\Background_Clouds_01.png") };

            Textures.MOUSE = Content.Load<Texture2D>("_Textures\\_Mouse\\Mouse.png");
            Textures.PAUSE = Content.Load<Texture2D>("_Textures\\Pause.png");

            Textures.BUTTON_CONTINUE = Content.Load<Texture2D>("_Textures\\_Button\\Button_Continue.png");
            Textures.BUTTON_QUIT = Content.Load<Texture2D>("_Textures\\_Button\\Button_Quit.png");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here
            World.Player.World.Update();
            if (!World.Player.Active)
            {
                MenuPause.Update();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            World.Player.World.Draw(spriteBatch);
            MenuPause.Draw(spriteBatch);
            

            spriteBatch.Begin();
            if (Properties.Settings.Default.Debug)
            {
                spriteBatch.DrawString(Font.Debug, "DEBUG MODE\nPlayer: " + World.Player.Name + "\nHealth: " + World.Player.Health + "/" + World.Player.MaxHealth, new Vector2(3, 3), Color.Black);
            }
            if (Properties.Settings.Default.DevelopmentVersion)
            {
                spriteBatch.DrawString(Font.Regular, "Development Version", new Vector2(graphics.PreferredBackBufferWidth - 125, graphics.PreferredBackBufferHeight - 15), Color.Black);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
