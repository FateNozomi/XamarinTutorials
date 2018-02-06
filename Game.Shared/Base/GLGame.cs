using System;
using System.Collections.Generic;
using System.Text;
using Engine.Shared.Base;
using OpenTK;

namespace Game.Shared.Base
{
    /// <summary>
    /// The instance of our game
    /// </summary>
    public class GLGame : BaseGame
    {
        public override Vector2 InitialResolution => new Vector2(1920, 1080);

        /// <summary>
        /// Creates our game
        /// </summary>
        public GLGame()
        {
        }
    }
}
