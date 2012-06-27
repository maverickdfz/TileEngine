using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TileEngine
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Texture2D> textures = new List<Texture2D>();

        int[,] tileMap = new int[,]
        {
            {1, 6, 1, 4, 1, 0, 0, 0, 1, 6, 1, 4, 1, 0, 0, 0},
            {1, 6, 1, 4, 1, 0, 0, 0, 1, 6, 1, 4, 1, 0, 0, 0},
            {1, 6, 1, 4, 1, 1, 1, 3, 1, 6, 1, 4, 1, 1, 1, 3},
            {1, 6, 1, 4, 4, 4, 1, 3, 1, 6, 1, 4, 4, 4, 1, 3},
            {1, 6, 1, 1, 1, 4, 1, 3, 1, 6, 1, 1, 1, 4, 1, 3},
            {1, 6, 1, 5, 1, 4, 1, 3, 1, 6, 1, 5, 1, 4, 1, 3},
            {1, 6, 1, 5, 1, 4, 1, 3, 1, 6, 1, 5, 1, 4, 1, 3},
            {1, 6, 1, 5, 1, 4, 1, 3, 1, 6, 1, 5, 1, 4, 1, 3},
            {1, 6, 1, 4, 1, 0, 0, 0, 1, 6, 1, 4, 1, 0, 0, 0},
            {1, 6, 1, 4, 1, 0, 0, 0, 1, 6, 1, 4, 1, 0, 0, 0},
            {1, 6, 1, 4, 1, 1, 1, 3, 1, 6, 1, 4, 1, 1, 1, 3},
            {1, 6, 1, 4, 4, 4, 1, 3, 1, 6, 1, 4, 4, 4, 1, 3},
            {1, 6, 1, 1, 1, 4, 1, 3, 1, 6, 1, 1, 1, 4, 1, 3},
            {1, 6, 1, 5, 1, 4, 1, 3, 1, 6, 1, 5, 1, 4, 1, 3},
            {1, 6, 1, 5, 1, 4, 1, 3, 1, 6, 1, 5, 1, 4, 1, 3},
            {1, 6, 1, 5, 1, 4, 1, 3, 1, 6, 1, 5, 1, 4, 1, 3},
        };

        int tileWidth = 64;
        int tileHeight = 64;

        int cameraPositionX = 0;
        int cameraPositionY = 0;
        Point cameraPosition = Point.Zero;
        Vector2 cameraMove = Vector2.Zero;
        float cameraSpeed = 5.0f;

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

            // TODO: use this.Content to load your game content here
            Texture2D temp;

            //temp = Content.Load<Texture2D>("bricks");
            //textures.Add(temp);

            //temp = Content.Load<Texture2D>("bricks_nm");
            //textures.Add(temp);

            //temp = Content.Load<Texture2D>("ciottoli_bw");
            //textures.Add(temp);

            //temp = Content.Load<Texture2D>("ciottoli_cm");
            //textures.Add(temp);

            //temp = Content.Load<Texture2D>("ciottoli_normal");
            //textures.Add(temp);

            //temp = Content.Load<Texture2D>("mud_wa_nm");
            //textures.Add(temp);

            temp = Content.Load<Texture2D>("se_free_dirt_texture");
            textures.Add(temp);

            temp = Content.Load<Texture2D>("se_free_grass_texture");
            textures.Add(temp);

            temp = Content.Load<Texture2D>("se_free_ground_texture");
            textures.Add(temp);

            temp = Content.Load<Texture2D>("se_free_mud_texture");
            textures.Add(temp);

            temp = Content.Load<Texture2D>("se_free_road_texture");
            textures.Add(temp);

            temp = Content.Load<Texture2D>("se_free_rock_texture");
            textures.Add(temp);

            temp = Content.Load<Texture2D>("se_free_wood_texture");
            textures.Add(temp);

            //temp = Content.Load<Texture2D>("wood_axis");
            //textures.Add(temp);

            //temp = Content.Load<Texture2D>("wood_axis_light");
            //textures.Add(temp);

            //temp = Content.Load<Texture2D>("wood_axis_lightwood");
            //textures.Add(temp);

            //temp = Content.Load<Texture2D>("wood_base");
            //textures.Add(temp);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            cameraMove = Vector2.Zero;

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                cameraMove.Y -= 1.0f;
                //cameraPositionY--;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                cameraMove.Y += 1.0f;
                //cameraPositionY++;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                cameraMove.X -= 1.0f;
                //cameraPositionX--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                cameraMove.X += 1.0f;
                //cameraPositionX++;

            if (cameraMove.Length() != 0)
                cameraMove.Normalize();

            cameraMove *= cameraSpeed;

            cameraPosition.X += (int)cameraMove.X;
            cameraPosition.Y += (int)cameraMove.Y;

            if (cameraPosition.X < 0)
                cameraPosition.X = 0;
            if (cameraPosition.Y < 0)
                cameraPosition.Y = 0;

            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;

            int tileMapWidth = tileMap.GetLength(1) * tileWidth;
            int tileMapHeight = tileMap.GetLength(0) * tileHeight;

            if (cameraPosition.X > tileMapWidth - screenWidth)
                cameraPosition.X = tileMapWidth - screenWidth;
            if (cameraPosition.Y > tileMapHeight - screenHeight)
                cameraPosition.Y = tileMapHeight - screenHeight;

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
            spriteBatch.Begin();

            int tileMapWidth = tileMap.GetLength(1);
            int tileMapHeight = tileMap.GetLength(0);

            for (int x = 0; x < tileMapWidth; x++)
            {
                for (int y = 0; y < tileMapHeight; y++)
                {
                    int textureIndex = tileMap[y, x];
                    Texture2D texture = textures[textureIndex];

                    spriteBatch.Draw(texture, new Rectangle(x * tileWidth - cameraPosition.X, y * tileHeight - cameraPosition.Y, tileWidth, tileHeight), Color.White);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
