using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using NJHTFinalProject.Scenes;

namespace NJHTFinalProject
{
    public class GameScreen : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private SoundEffect _menuMusic;
        private SoundEffect _buttonSelected;
        private SoundEffectInstance _buttonSelectedIntance;
        private SoundEffectInstance _menuInstance;
        private KeyboardState oldState;
        private GamePadState oldGPState;

        // Declares all scenes
        private MenuScene startScene;
        private GameScene gameScene;
        private AboutScene aboutScene;
        private HelpScene helpScene;
        private GameOverScene gameOverScene;

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
            Window.Title = "Meteor Madness";

            _graphics = new GraphicsDeviceManager(this);

            _graphics.IsFullScreen = true;
            
            

            _graphics.GraphicsProfile = GraphicsProfile.HiDef;

            if (_graphics.IsFullScreen)
            {
                _graphics.PreferredBackBufferWidth = 1920;
                _graphics.PreferredBackBufferHeight = 1080;
                _graphics.ApplyChanges();
            }
            else
            {
                Window.AllowUserResizing = true;
                _graphics.PreferredBackBufferWidth = 1916;
                _graphics.PreferredBackBufferHeight = 1020;
                _graphics.ApplyChanges();
            }

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

            startScene = new MenuScene(this);
            gameScene = new GameScene(this);
            aboutScene = new AboutScene(this);
            helpScene = new HelpScene(this);
            gameOverScene = new GameOverScene(this);

            _menuMusic = Content.Load<SoundEffect>("Sounds/MenuMusic");
            _buttonSelected = Content.Load<SoundEffect>("Sounds/ButtonSelected");

            this.Components.Add(startScene);
            this.Components.Add(gameScene);
            this.Components.Add(aboutScene);
            this.Components.Add(helpScene);
            this.Components.Add(gameOverScene);

            _menuInstance = _menuMusic.CreateInstance();
            _menuInstance.IsLooped = true;
            _menuInstance.Play();

            _buttonSelectedIntance = _buttonSelected.CreateInstance();

            startScene.Show();
        }

        protected override void Update(GameTime gameTime)
        {
            int selectedIndex = startScene.Menu.SelectedIndex;

            

            if (startScene.Enabled)
            {
                

                KeyboardState keyboardState = Keyboard.GetState();
                GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

                

                if ((keyboardState.IsKeyDown(Keys.Enter) && oldState.IsKeyUp(Keys.Enter))
                    || (gamePadState.Buttons.A == ButtonState.Pressed && oldGPState.Buttons.A == ButtonState.Released)) {
                    if (selectedIndex == 0)
                    {
                        _buttonSelectedIntance.Play();

                        HideAllScenes();
                        gameScene.Show(); // Goes to play scene
                        _menuInstance.Stop();
                    }
                    else if (selectedIndex == 1)
                    {
                        _buttonSelectedIntance.Play();

                        HideAllScenes(); // Goes to options scene
                        _menuInstance.Stop();
                    }
                    else if (selectedIndex == 2)
                    {
                        _buttonSelectedIntance.Play();

                        HideAllScenes(); // Goes to help scene
                        helpScene.Show();
                    }
                    else if (selectedIndex == 3)
                    {
                        _buttonSelectedIntance.Play();
                        HideAllScenes(); // Goes to about scene

                        aboutScene.Show();
                    }
                    else if (selectedIndex == 4)
                    {
                        _buttonSelectedIntance.Play();
                        _menuInstance.Stop();

                        Exit(); // Exits the program
                    }

                    
                }
                oldGPState = gamePadState;
                oldState = keyboardState;
            }
            else if (aboutScene.Enabled)
            {
                KeyboardState keyboardState = Keyboard.GetState();
                GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

                if (keyboardState.IsKeyDown(Keys.Escape) || gamePadState.Buttons.B == ButtonState.Pressed)
                {
                    aboutScene.Hide();
                    startScene.Show();
                }
            }
            else if (helpScene.Enabled)
            {
                KeyboardState keyboardState = Keyboard.GetState();
                GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
                if (keyboardState.IsKeyDown(Keys.Escape) || gamePadState.Buttons.B == ButtonState.Pressed)
                {
                    helpScene.Hide();
                    startScene.Show();
                }
            }
            else if (gameOverScene.Enabled)
            {
                KeyboardState keyboardState = Keyboard.GetState();
                GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
                if ((keyboardState.IsKeyDown(Keys.Enter) || oldState.IsKeyUp(Keys.Enter)) || (gamePadState.Buttons.A == ButtonState.Pressed) && oldGPState.Buttons.A == ButtonState.Released)
                {
                    gameOverScene.Hide();
                    startScene.Show();
                }
                oldState = keyboardState;
                oldGPState = gamePadState;
            }
            else if (gameScene.Enabled)
            {
                KeyboardState keyboardState = Keyboard.GetState();
                GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
                if (keyboardState.IsKeyDown(Keys.Escape) || gamePadState.Buttons.B == ButtonState.Pressed)
                {

                    gameScene.Hide();
                    gameScene.GameComponent.Score = 0;
                    startScene.Show();
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
