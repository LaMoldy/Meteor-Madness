using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NJHTFinalProject.Components;

namespace NJHTFinalProject.Scenes
{
    public class StartScene : SceneManager
    {
        public MenuComponent Menu { get; set; }

        private SpriteBatch _spriteBatch;

        string[] menuItems = { "Play", "Options", "Help", "About", "Exit" };

        public StartScene(Game game) : base(game)
        {
            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            SpriteFont regularFont = g.Content.Load<SpriteFont>("Fonts/regularFont");
            SpriteFont highlightFont = g.Content.Load<SpriteFont>("Fonts/highlightFont");

            Menu = new MenuComponent(game, _spriteBatch, regularFont, highlightFont, menuItems);
            this.Components.Add(Menu);
        }
    }
}
