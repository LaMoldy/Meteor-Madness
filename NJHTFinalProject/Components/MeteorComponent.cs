using System;
using System.Collections.Generic;
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
        private Rectangle _hitBox;

        public MeteorComponent(Game game,
            SpriteBatch spriteBatch,
            Texture2D meteor,
            Vector2 position,
            Rectangle hitBox) : base(game)
        {
            _meteor = meteor;
            _position = position;
            _hitBox = hitBox;
            _spriteBatch = spriteBatch;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_meteor, _hitBox, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
