using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NJHTFinalProject.Components;

namespace NJHTFinalProject.Scenes
{
    public class GameScene : SceneManager
    {
        public GameScreenComponent GameComponent { get; set; }

        private Texture2D meteor;
        private Game _game;
        public List<MeteorComponent> MeteorComponents { get; set; }
        private SpriteBatch _spriteBatch;

        private Vector2 _position;


        public GameScene(Game game) : base(game)
        {
            int startingXCoord = (int)Shared.stage.X / 2 -150;
            int startingYCoord =(int)Shared.stage.Y / 2 - 120;

            _position.X = startingXCoord;
            _position.Y = startingYCoord;

            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            Texture2D spaceship = g.Content.Load<Texture2D>("Images/Spaceship");
            Texture2D background = g.Content.Load<Texture2D>("Images/Space/Space_Stars10");
            Rectangle screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);
            SpriteFont spriteFont = g.Content.Load<SpriteFont>("Fonts/regularFont");
            Texture2D healthPlanet = g.Content.Load<Texture2D>("Images/HealthPlanet");
            meteor = g.Content.Load<Texture2D>("Images/Meteor/Meteor/rotationY1");

            _game = game;

            GameComponent = new GameScreenComponent(game, _spriteBatch, _position, spaceship, background, screenSize, spriteFont, meteor, healthPlanet, this);
            MeteorComponents = new List<MeteorComponent>();

            this.Components.Add(GameComponent);
            
            foreach(var meteors in MeteorComponents)
            {
                this.Components.Add(meteors);
            }
        }

        public void CreateMeteor()
        {
            GameScreen g = (GameScreen)_game;
            _spriteBatch = g._spriteBatch;
            Random rand = new Random();

            Vector2 position = new Vector2(rand.Next((int)Shared.stage.X), -7);

            Rectangle hitBox = new Rectangle((int)position.X, (int)position.Y, 100, 100);
            var meteorSprite = new MeteorComponent(_game, _spriteBatch, meteor, position, hitBox, GameComponent);

            MeteorComponents.Add(meteorSprite);
        }
    }
}
