using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NJHTFinalProject.Components
{
    public class HelpComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _background;
        private Rectangle _screenSize;
        private SpriteFont _regularFont;

        public HelpComponent(Game game,
            SpriteBatch spriteBatch,
            Texture2D background,
            Rectangle screenSize,
            SpriteFont regularFont) : base(game)
        {
            _spriteBatch = spriteBatch;
            _background = background;
            _screenSize = screenSize;
            _regularFont = regularFont;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, _screenSize, Color.White);

            string mouseHeader = "Mouse and Keyboard\n\n";
            string mouseControls = "W: Move up\nA: Left left\nS: Move down\nD: Move right\n\n\n";
            string controllerHeader = "Controller:\n\n";
            string controllerControls = "Left stick up: Move up\nLeft stick left: Move left\nLeft stick down: Move down\nLeft stick right: Move right";

            _spriteBatch.DrawString(_regularFont, mouseHeader + mouseControls + controllerHeader + controllerControls, new Vector2(Shared.stage.X / 2 - 150, 250), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}