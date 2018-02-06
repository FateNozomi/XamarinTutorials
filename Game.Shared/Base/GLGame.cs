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
        /// <summary>
        /// The target resolution for the game
        /// </summary>
        public override Vector2 InitialResolution => new Vector2(1920, 1080);

        /// <summary>
        /// Creates our game
        /// </summary>
        public GLGame()
        {
        }

        /// <summary>
        /// Calculates the extra offset based on the difference in height between the target and the actual resolution
        /// </summary>
        /// <param name="heightDifference"></param>
        /// <returns></returns>
        protected override Vector2 CalculateExtraOffset(float heightDifference)
        {
            return new Vector2(0, 0);
        }
    }
}
