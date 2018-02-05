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

        public Vector2 InitialResolution { get; }

        /// <summary>
        /// Initializes the game
        /// </summary>
        public virtual void Init()
        {
            Renderer.Instance.Init(InitialResolution);
        }

        /// <summary>
        /// Draws our objects
        /// </summary>
        internal void Draw()
        {
            Renderer.Instance.Draw();
        }
    }
}
