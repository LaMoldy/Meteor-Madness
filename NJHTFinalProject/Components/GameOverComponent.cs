using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace NJHTFinalProject.Components
{
    class GameOverComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        SpriteFont _headerFont;
        SpriteFont _regularFont;

        Rectangle _screenSize;

        Texture2D _background;

        Vector2 _position;

        string _header;
        string _score;
        string _controllerMessage;

        public GameOverComponent(Game game,
            SpriteBatch spriteBatch,
            SpriteFont headerFont,
            SpriteFont regularFont,
            Rectangle screenSize,
            Texture2D background,
            Vector2 position,
            string header,
            string score,
            string controllerMessage) : base(game)
        {
            _spriteBatch = spriteBatch;
            _headerFont = headerFont;
            _regularFont = regularFont;
            _screenSize = screenSize;
            _background = background;
            _position = position;
            _header = header;
            _score = score;
            _controllerMessage = controllerMessage;
        }
        
        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, _screenSize, Color.White);

            _spriteBatch.DrawString(_headerFont, _header, _position, Color.White);
            _spriteBatch.DrawString(_headerFont, _score, new Vector2(_position.X, _position.Y + 40), Color.White);
            _spriteBatch.DrawString(_regularFont, _controllerMessage, new Vector2(_position.X, _position.Y + 80), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
