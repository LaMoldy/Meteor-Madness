using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NJHTFinalProject.Scenes;

namespace NJHTFinalProject
{
    public class GameScreen : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        // Declares all scenes
        private StartScene startScene;
        private GameScene gameScene;

        private void HideAllScenes()
        {
            SceneManager gs = null;
            foreach (SceneManager component in Components)
            {
                component.Hide();
            }
        }

        public GameScreen()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            Shared.stage = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            startScene = new StartScene(this);
            gameScene = new GameScene(this);

            this.Components.Add(startScene);
            this.Components.Add(gameScene);

            startScene.Show();
        }

        protected override void Update(GameTime gameTime)
        {

            int selectedIndex = startScene.Menu.SelectedIndex;

            if (startScene.Enabled)
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Enter) 
                    || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) {
                    if (selectedIndex == 0)
                    {
                        HideAllScenes();
                        gameScene.Show();
                    }
                    else if (selectedIndex == 1)
                    {
                        HideAllScenes();
                    }
                    else if (selectedIndex == 2)
                    {
                        HideAllScenes();
                    }
                    else if (selectedIndex == 3)
                    {
                        HideAllScenes();
                    }
                    else if (selectedIndex == 4)
                    {
                        this.Exit();
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
    }
}
