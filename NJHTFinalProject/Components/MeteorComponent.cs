using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NJHTFinalProject.Components
{
    public class MeteorComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;

        private Texture2D _meteor;
        private Vector2 _position;
        private int direction = 0;
        private Rectangle _hitBox;

        bool playerHit = false;

        private GameScreenComponent _gameScreenComponent;

        public MeteorComponent(Game game,
            SpriteBatch spriteBatch,
            Texture2D meteor,
            Vector2 position,
            Rectangle hitBox,
            GameScreenComponent gameScreenComponent) : base(game)
        {
            _meteor = meteor;
            _position = position;
            _hitBox = hitBox;
            _spriteBatch = spriteBatch;
            _gameScreenComponent = gameScreenComponent;

            Random rand = new Random();
            direction = rand.Next(2);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            if (!playerHit)
            {
                _spriteBatch.Draw(_meteor, _hitBox, Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            

            if (direction == 1)
            {
                _hitBox.X += 2;
            }
            else
            {
                _hitBox.X -= 2;
            }

            _hitBox.Y += 4;

            var meteorBounds = this.GetBounds();
            var playerBounds = Shared.GetBounds();

            if (playerBounds.Intersects(meteorBounds))
            {
                _gameScreenComponent.Lives--;
                playerHit = true;
            }

            base.Update(gameTime);
        }

        public Rectangle GetBounds()
        {
            return _hitBox;
        }
    }
}
