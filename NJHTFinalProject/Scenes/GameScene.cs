using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NJHTFinalProject.Components;

namespace NJHTFinalProject.Scenes
{
    class GameScene : SceneManager
    {
        public SpaceshipComponent Spaceship { get; set; }

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

            Spaceship = new SpaceshipComponent(game, _spriteBatch, _position, spaceship);
            this.Components.Add(Spaceship);
        }
    }
}
