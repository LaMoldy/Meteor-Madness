using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NJHTFinalProject.Components
{
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private SpriteFont _regularFont, _highlightFont;
        private string[] _menuItems;
        private Vector2 _position;
        private Color _regularColor = Color.White;
        private Color _highlightColor = Color.Red;

        private KeyboardState oldState;
        private GamePadState oldGPState;
        
        public int SelectedIndex { get; set; }

        public MenuComponent(Game game,
            SpriteBatch spriteBatch,
            SpriteFont regularFont,
            SpriteFont highlightFont,
            string[] menuItems) : base(game)
        {
            _spriteBatch = spriteBatch;
            _regularFont = regularFont;
            _highlightFont = highlightFont;
            _menuItems = menuItems;
            _position = new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2);
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPosition = _position;

            _spriteBatch.Begin();
            
            for (int i = 0; i < _menuItems.Length; i++)
            {
                if (SelectedIndex == i)
                {
                    _spriteBatch.DrawString(_highlightFont, _menuItems[i], tempPosition, _highlightColor);
                    tempPosition.Y += _highlightFont.LineSpacing;
                }
                else
                {
                    _spriteBatch.DrawString(_regularFont, _menuItems[i], tempPosition, _regularColor);
                    tempPosition.Y += _regularFont.LineSpacing;
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            if ((keyboardState.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down)) 
                || (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed && oldGPState.DPad.Down == ButtonState.Released)
                || (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0 && oldGPState.ThumbSticks.Left.Y == 0))
            {
                SelectedIndex++;
                if (SelectedIndex == _menuItems.Length)
                {
                    SelectedIndex = 0;
                }
            }

            if ((keyboardState.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
                || (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed && oldGPState.DPad.Up == ButtonState.Released)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0 && oldGPState.ThumbSticks.Left.Y == 0)
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = _menuItems.Length - 1;
                }
            }

            oldState = keyboardState;
            oldGPState = gamePadState;

            base.Update(gameTime);
        }
    }
}
