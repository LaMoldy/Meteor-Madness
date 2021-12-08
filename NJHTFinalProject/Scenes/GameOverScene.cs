using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using NJHTFinalProject.Components;

namespace NJHTFinalProject.Scenes
{
    class GameOverScene : SceneManager
    {
        public GameOverComponent GameOverComponent { get; set; }

        public int Score { get; set; }

        SpriteBatch _spriteBatch;
        SpriteFont _headerFont;
        SpriteFont _regularFont;

        Rectangle _screenSize;

        Texture2D _background;

        Vector2 _position;

        string _header;
        string _score;
        string _controllerMessage;

        public GameOverScene(Game game) : base(game)
        {
            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            _screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);

            _background = g.Content.Load<Texture2D>("Images/Background");
            _headerFont = g.Content.Load<SpriteFont>("Fonts/authorFont");
            _regularFont = g.Content.Load<SpriteFont>("Fonts/regularFont");

            _header = "Game Over!";
            _score = "Your score was: " + Score;
            _controllerMessage = "Press ENTER or Press the A button to continue!";

            _position = new Vector2(700, 450);


            GameOverComponent = new GameOverComponent(game, _spriteBatch, _headerFont, _regularFont, _screenSize, _background, _position, _header, _score, _controllerMessage);

            this.Components.Add(GameOverComponent);
        }


    }
}
