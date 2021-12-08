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
            int startingXCoord = (int)Shared.stage.X / 2 -250;
            int startingYCoord =(int)Shared.stage.Y / 2 - 200;

            _position.X = startingXCoord;
            _position.Y = startingYCoord;

            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            Texture2D spaceship = g.Content.Load<Texture2D>("Images/Spaceship");
            Texture2D background = g.Content.Load<Texture2D>("Images/Space/Space_Stars10");
            Rectangle screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);
            SpriteFont spriteFont = g.Content.Load<SpriteFont>("Fonts/regularFont");
            Texture2D meteor = g.Content.Load<Texture2D>("Images/Meteor");
            Texture2D healthPlanet = g.Content.Load<Texture2D>("Images/HealthPlanet");

            GameComponent = new GameComponent(game, _spriteBatch, _position, spaceship, background, screenSize, spriteFont, meteor, healthPlanet);

            this.Components.Add(GameComponent);
        }
    }
}
