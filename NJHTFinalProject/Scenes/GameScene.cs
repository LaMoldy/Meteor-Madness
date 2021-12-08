using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NJHTFinalProject.Components;
using GameComponent = NJHTFinalProject.Components.GameComponent;

namespace NJHTFinalProject.Scenes
{
    class GameScene : SceneManager
    {
        public GameComponent GameComponent { get; set; }

        private SpriteBatch _spriteBatch;

        private Vector2 _position;


        public GameScene(Game game) : base(game)
        {
            const int startingXCoord = 150;
            const int startingYCoord = 100;

            _position.X = startingXCoord;
            _position.Y = startingYCoord;

            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            Texture2D spaceship = g.Content.Load<Texture2D>("Images/Spaceship");
            Texture2D background = g.Content.Load<Texture2D>("Images/Space/Space_Stars1");
            Rectangle screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);
            SpriteFont spriteFont = g.Content.Load<SpriteFont>("Fonts/regularFont");

            GameComponent = new Components.GameComponent(game, _spriteBatch, _position, spaceship, background, screenSize, spriteFont);
            this.Components.Add(GameComponent);
        }
    }
}
