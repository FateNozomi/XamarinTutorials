using System;
using System.Collections.Generic;
using System.Text;
using Engine.Shared.Base;

namespace Engine.Shared.Graphics
{
    /// <summary>
    /// The canvas will draw all the objects using the camera attached
    /// </summary>
    public class Canvas : IDisposable
    {
        /// <summary>
        /// The camera that draws the object on the canvas
        /// </summary>
        protected readonly Camera _camera;

        /// <summary>
        /// The camera that draws the object on the canvas
        /// </summary>
        public Camera Camera => _camera;

        /// <summary>
        /// Creates the canvas
        /// </summary>
        /// <param name="camera"></param>
        public Canvas(Camera camera)
        {
            _camera = camera;
            Renderer.Instance.AddCanvas(this);
        }

        /// <summary>
        /// Draws the objects on the canvas
        /// </summary>
        public void Draw()
        {
            bool viewChanged = _camera.MatrixInvalid;
            if (viewChanged)
            {
                _camera.UpdateViewProjectionMatrix();
            }
        }

        /// <summary>
        /// Dispose of the canvas
        /// </summary>
        public void Dispose()
        {
            Renderer.Instance.RemoveCanvas(this);
        }
    }
}
