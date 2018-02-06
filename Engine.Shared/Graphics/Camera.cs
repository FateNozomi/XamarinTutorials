using OpenTK;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Shared.Graphics
{
    public class Camera
    {
        /// <summary>
        /// The position of the camera
        /// </summary>
        protected Vector2 _position;

        /// <summary>
        /// The dimensions of the camera viewport
        /// </summary>
        protected Vector2 _dimensions;

        /// <summary>
        /// The view matrix for our camera
        /// Notes: Will change when moving the camera around
        /// </summary>
        protected Matrix4 _viewMatrix;

        /// <summary>
        /// The projection matrix for our camera
        /// Notes: Should be fixed
        /// </summary>
        protected Matrix4 _projectionMatrix;

        /// <summary>
        /// The view projection matrix for our camera
        /// </summary>
        protected Matrix4 _viewProjectionMatrix;

        /// <summary>
        /// Creates the camera
        /// </summary>
        /// <param name="position"></param>
        /// <param name="dimensions"></param>
        public Camera(Vector2 position, Vector2 dimensions)
        {
            _position = position;
            _dimensions = dimensions;
            _projectionMatrix = Matrix4.CreateOrthographic(_dimensions.X, _dimensions.Y, 1, 1000);
            UpdateViewProjectionMatrix();
        }

        /// <summary>
        /// The position of the camera
        /// </summary>
        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                MatrixInvalid = true;
            }
        }

        /// <summary>
        /// The view projection matrix for our camera
        /// </summary>
        public Matrix4 ViewProjectionMatrix => _viewProjectionMatrix;

        /// <summary>
        /// Whether or not the view projection matrix is invalid
        /// </summary>
        public bool MatrixInvalid { get; private set; }

        /// <summary>
        /// Updates the view projection matrix when something has changed on the camera
        /// </summary>
        public virtual void UpdateViewProjectionMatrix()
        {
            _viewProjectionMatrix = Matrix4.Identity;
            _viewMatrix = Matrix4.LookAt(new Vector3(_position.X, _position.Y, 1), new Vector3(_position.X, _position.Y, 0), new Vector3(0, 1, 0));
            _projectionMatrix = Matrix4.Mult(_viewMatrix, _projectionMatrix);
            MatrixInvalid = false;
        }
    }
}
