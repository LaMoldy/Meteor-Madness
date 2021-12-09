using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NJHTFinalProject.Scenes;

namespace NJHTFinalProject.Components
{
    public class GameScreenComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Vector2 _spaceShipPosition;
        private Texture2D _spaceship;
        private Texture2D _background;
        private Rectangle _screenSize;
        private SpriteFont _spriteFont;
        private Texture2D _meteor;
        private Texture2D _healthPlanet;
        private GameScene _gameScene;
        private int counter = 0;

        public GameScreenComponent(Game game,
            SpriteBatch spriteBatch,
            Vector2 position,
            Texture2D spaceship,
            Texture2D background,
            Rectangle screenSize,
            SpriteFont spriteFont,
            Texture2D meteor, 
            Texture2D healthPlanet,
            GameScene gameScene) : base(game)
        {
            _spriteBatch = spriteBatch;
            _spaceShipPosition = position;
            _spaceship = spaceship;
            _background = background;
            _screenSize = screenSize;
            _spriteFont = spriteFont;
            _meteor = meteor;
            _healthPlanet = healthPlanet;
            _gameScene = gameScene;

            counter = 0;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            
            
            _spriteBatch.Draw(_background, _screenSize, Color.White);
            _spriteBatch.Draw(_spaceship, new Rectangle((int)_spaceShipPosition.X, (int)_spaceShipPosition.Y, 200, 250), Color.White);

            int lifeCounter = 0;

            Vector2 planetLocation = new Vector2(Shared.stage.X - 145, Shared.stage.Y / 2 + 397);

            

            while (lifeCounter < Shared.PlayerLives)
            {
                _spriteBatch.Draw(_healthPlanet, planetLocation, Color.White);

                planetLocation.X -= 120;
                lifeCounter++;
            }

            if (counter == 30 || counter == 60)
            {
                _gameScene.CreateMeteor();
            }

            if (counter == 60)
            {
                Shared.PlayerScore += (int)Math.Round(Math.Log(76) * new Random().Next(50));
                _spriteBatch.DrawString(_spriteFont, "Score: " + Shared.PlayerScore, new Vector2(Shared.stage.X - 200, 20), Color.White);
                counter = 0;
            }

            _spriteBatch.DrawString(_spriteFont, "Score: " + Shared.PlayerScore, new Vector2(Shared.stage.X - 200, 20), Color.White);
            _spriteBatch.End();

            foreach (var meteors in _gameScene.MeteorComponents)
            {
                meteors.Draw(gameTime);
                meteors.Update(gameTime);
            }

            counter++;

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0)
            {
                _spaceShipPosition.Y -= 10;
                Shared.PlayerHitBox.Y = (int)_spaceShipPosition.Y;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0)
            {
                _spaceShipPosition.Y += 10;
                Shared.PlayerHitBox.Y = (int)_spaceShipPosition.Y;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0)
            {
                _spaceShipPosition.X -= 10;
                Shared.PlayerHitBox.X = (int)_spaceShipPosition.X;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0)
            {
                _spaceShipPosition.X += 10;
                Shared.PlayerHitBox.X = (int)_spaceShipPosition.X;
            }

            base.Update(gameTime);
        }
    }
}
