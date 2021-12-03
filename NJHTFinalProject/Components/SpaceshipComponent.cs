using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NJHTFinalProject.Components
{
    public class SpaceshipComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Vector2 _position;
        private Texture2D _spaceship;

        public SpaceshipComponent(Game game,
            SpriteBatch spriteBatch,
            Vector2 position,
            Texture2D spaceship) : base(game)
        {
            _spriteBatch = spriteBatch;
            _position = position;
            _spaceship = spaceship;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_spaceship, _position, Color.White);
            _spriteBatch.End();

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
