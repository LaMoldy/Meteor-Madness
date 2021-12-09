using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace NJHTFinalProject
{
    class Shared
    {
        public static Vector2 stage;

        public static Rectangle PlayerHitBox;

        public static Rectangle GetBounds()
        {
            return new Rectangle(PlayerHitBox.X, PlayerHitBox.Y, 200, 250);
        }
    }
}
