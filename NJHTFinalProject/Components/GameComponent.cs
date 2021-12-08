using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NJHTFinalProject.Components
{
    public class GameComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Vector2 _position;
        private Texture2D _spaceship;
        private Texture2D _background;
        private Rectangle _screenSize;
        private SpriteFont _spriteFont;

        private int counter;

        private int previousScore;

        public int Score { get; set; }

        public GameComponent(Game game,
            SpriteBatch spriteBatch,
            Vector2 position,
            Texture2D spaceship,
            Texture2D background,
            Rectangle screenSize,
            SpriteFont spriteFont) : base(game)
        {
            _spriteBatch = spriteBatch;
            _position = position;
            _spaceship = spaceship;
            _background = background;
            _screenSize = screenSize;
            _spriteFont = spriteFont;

            Score = 0;
            counter = 0;
            previousScore = Score;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            
            _spriteBatch.Draw(_background, _screenSize, Color.White);
            _spriteBatch.Draw(_spaceship, _position, Color.White);

            if (counter == 60)
            {
                Score++;
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
                _position.Y -= 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0)
            {
                _position.Y += 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0)
            {
                _position.X -= 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0)
            {
                _position.X += 10;
            }

            base.Update(gameTime);
        }
    }
}
