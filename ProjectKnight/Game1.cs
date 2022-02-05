using HonasGame.Assets;
using HonasGame.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectKnight.Entities.Knight;

namespace ProjectKnight
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Scene _scene;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _scene = new Scene();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            AssetLibrary.AddAsset("knight", Content.Load<Texture2D>("Sprites/Entities/Knight/Knight"));

            Sprite sprKnight = new Sprite(AssetLibrary.GetAsset<Texture2D>("knight"));
            sprKnight.Animations.Add("idle", SpriteAnimation.FromSpritesheet(4, 0.1, 0, 0, 32, 32));
            sprKnight.Animations.Add("walk", SpriteAnimation.FromSpritesheet(6, 0.1, 32*4, 0, 32, 32));
            sprKnight.Animations.Add("jump", SpriteAnimation.FromSpritesheet(3, 0.1, 32*10, 0, 32, 32));
            AssetLibrary.AddAsset("sprKnight", sprKnight);
            _scene.AddEntity(new Knight());

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _scene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _scene.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
