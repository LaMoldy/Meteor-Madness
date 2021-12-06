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
    public class MenuScene : SceneManager
    {
        public MenuComponent Menu { get; set; }

        private SpriteBatch _spriteBatch;

        string[] menuItems = { "Play", "Options", "Help", "About Us", "Exit" };

        public MenuScene(Game game) : base(game)
        {
            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            SpriteFont regularFont = g.Content.Load<SpriteFont>("Fonts/regularFont");
            SpriteFont highlightFont = g.Content.Load<SpriteFont>("Fonts/highlightFont");
            Texture2D background = g.Content.Load<Texture2D>("Images/Background"); // SOURCE: https://www.freepik.com/free-vector/space-banner-with-purple-planet-landscape_13778479.htm#page=1&query=cartoon%20space&position=13&from_view=keyword
            SoundEffect buttonSound = g.Content.Load<SoundEffect>("Sounds/ButtonSound"); // SOURCE: https://www.youtube.com/watch?v=ILaQFzeuamU

            Rectangle screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);

            Menu = new MenuComponent(game, _spriteBatch, regularFont, highlightFont, background, screenSize, buttonSound, menuItems);
            this.Components.Add(Menu);
        }
    }
}
