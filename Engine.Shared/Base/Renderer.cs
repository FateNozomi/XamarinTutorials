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
        /// The viewport dimensions that have been scaled up/down
        /// </summary>
        private Vector2 _scaledDimensions;

        /// <summary>
        /// The target dimensions of the display
        /// </summary>
        private Vector2 _viewOffset;

        /// <summary>
        /// The instance of the renderer
        /// </summary>
        public static Renderer Instance => _instance ?? (_instance = new Renderer());

        /// <summary>
        /// The target dimensions of the display
        /// </summary>
        public Vector2 TargetDimensions => _targetDimensions;

        /// <summary>
        /// The dimensions scaled to fit the display
        /// </summary>
        public Vector2 ScaledDimensions => _scaledDimensions;

        /// <summary>
        /// The view offset
        /// </summary>
        public Vector2 ViewOffset => _viewOffset;

        /// <summary>
        /// The scale of the dimensions
        /// </summary>
        public Vector2 ScreenScale { get; private set; }

        /// <summary>
        /// The constructor of the renderer
        /// </summary>
        private Renderer()
        {
        }

        /// <summary>
        /// Creates the renderer
        /// </summary>
        /// <param name="targetDimensions">The target dimensions for the display</param>
        internal void Init(Vector2 targetDimensions, Vector2 deviceDimensions, Vector2 viewportOffset)
        {
            _targetDimensions = targetDimensions;
            ScreenScale = new Vector2(targetDimensions.X / deviceDimensions.X, targetDimensions.Y / deviceDimensions.Y);
            _scaledDimensions = deviceDimensions;
            _viewOffset = viewportOffset;
        }

        /// <summary>
        /// This will draw all objects for our game
        /// </summary>
        internal void Draw()
        {
            GL.Viewport((int)_viewOffset.X, (int)_viewOffset.Y, (int)_scaledDimensions.X, (int)_scaledDimensions.Y);
            GL.ClearColor(0f, 0.4f, 0f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}
