using OpenTK;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Shared.Base
{
    public abstract class BaseGame
    {
        /// <summary>
        /// Creates the game
        /// </summary>
        protected BaseGame()
        {
        }

        public virtual Vector2 InitialResolution { get; }

        /// <summary>
        /// Initializes the game
        /// </summary>
        public virtual void Init(Vector2 displayDimensions)
        {
            Single newHeight = (InitialResolution.X / displayDimensions.X) * displayDimensions.Y;
            Vector2 resolution = new Vector2(InitialResolution.X, newHeight);
            Renderer.Instance.Init(resolution, displayDimensions, CalculateExtraOffset(newHeight - InitialResolution.Y));
        }

        /// <summary>
        /// Calculates the offset based on the height differnece
        /// </summary>
        /// <param name="heightDifference"></param>
        /// <returns></returns>
        protected abstract Vector2 CalculateExtraOffset(Single heightDifference);

        /// <summary>
        /// Draws our objects
        /// </summary>
        internal void Draw()
        {
            Renderer.Instance.Draw();
        }
    }
}
