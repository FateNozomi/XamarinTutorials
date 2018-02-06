using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Shared.Base
{
    public class Renderer
    {
        /// <summary>
        /// The instance of the renderer
        /// </summary>
        private static Renderer _instance;

        /// <summary>
        /// The target dimensions for the display
        /// </summary>
        private Vector2 _targetDimensions;

        /// <summary>
        /// The instance of the renderer
        /// </summary>
        public static Renderer Instance => _instance ?? (_instance = new Renderer());

        /// <summary>
        /// The target dimensions of the display
        /// </summary>
        public Vector2 TargetDimensions => _targetDimensions;

        private Renderer()
        {
        }

        /// <summary>
        /// Creates the renderer
        /// </summary>
        /// <param name="targetDimensions">The target dimensions for the display</param>
        internal void Init(Vector2 targetDimensions)
        {
            _targetDimensions = targetDimensions;
        }

        /// <summary>
        /// This will draw all objects for our game
        /// </summary>
        internal void Draw()
        {
            GL.ClearColor(0f, 0.4f, 0f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}
