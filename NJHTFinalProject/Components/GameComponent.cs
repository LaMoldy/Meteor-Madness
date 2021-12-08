using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NJHTFinalProject.Components
{
    public class GameComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Vector2 _spaceShipPosition;
        private Texture2D _spaceship;
        private Texture2D _background;
        private Rectangle _screenSize;
        private SpriteFont _spriteFont;
        private Texture2D _meteor;
        private Texture2D _healthPlanet;
        private int counter = 0;
        private int Lives { get; set; }

        public int Score { get; set; }

        public GameComponent(Game game,
            SpriteBatch spriteBatch,
            Vector2 position,
            Texture2D spaceship,
            Texture2D background,
            Rectangle screenSize,
            SpriteFont spriteFont,
            Texture2D meteor, 
            Texture2D healthPlanet) : base(game)
        {
            _spriteBatch = spriteBatch;
            _spaceShipPosition = position;
            _spaceship = spaceship;
            _background = background;
            _screenSize = screenSize;
            _spriteFont = spriteFont;
            _meteor = meteor;
            _healthPlanet = healthPlanet;

            Score = 0;
            counter = 0;
            Lives = 3;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            
            
            _spriteBatch.Draw(_background, _screenSize, Color.White);
            _spriteBatch.Draw(_spaceship, _spaceShipPosition, Color.White);

            int lifeCounter = 0;

            Vector2 planetLocation = new Vector2(Shared.stage.X - 145, Shared.stage.Y / 2 + 397);

            while (lifeCounter < Lives)
            {
                _spriteBatch.Draw(_healthPlanet, planetLocation, Color.White);

                planetLocation.X -= 120;
                lifeCounter++;
            }

            if (counter % 12 == 0)
            {
                //_spriteBatch.Draw(_meteor, new Vector2(new Random().Next((int)Shared.stage.X), new Random().Next((int)Shared.stage.Y)), Color.White);
            }

            if (counter == 60)
            {
                Score += (int)Math.Round(Math.Log(200) * new Random().Next(50));
                _spriteBatch.DrawString(_spriteFont, "Score: " + Score, new Vector2(Shared.stage.X - 200, 20), Color.White);
                counter = 0;
            }

            _spriteBatch.DrawString(_spriteFont, "Score: " + Score, new Vector2(Shared.stage.X - 200, 20), Color.White);
            _spriteBatch.End();

            counter++;

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0)
            {
                _spaceShipPosition.Y -= 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0)
            {
                _spaceShipPosition.Y += 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0)
            {
                _spaceShipPosition.X -= 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0)
            {
                _spaceShipPosition.X += 10;
            }

            base.Update(gameTime);
        }
    }
}
