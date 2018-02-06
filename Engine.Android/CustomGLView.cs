using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Engine.Shared.Base;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Platform.Android;

namespace Engine.Android
{
    public class CustomGLView : AndroidGameView
    {
        /// <summary>
        /// The instance of our game
        /// </summary>
        protected readonly BaseGame _gameInstance;

        /// <summary>
        /// Creates the view
        /// </summary>
        /// <param name="context"></param>
        /// <param name="gameInstance"></param>
        public CustomGLView(Context context, BaseGame gameInstance)
            : base(context)
        {
            _gameInstance = gameInstance;
        }

        /// <summary>
        /// Called when the view is loaded - it starts running the game
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Run(60);
        }

        /// <summary>
        /// Creates the frame buffer
        /// </summary>
        protected override void CreateFrameBuffer()
        {
            try
            {
                GLContextVersion = GLContextVersion.Gles2_0;
                base.CreateFrameBuffer();
                return;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Called every frame to render all objects
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            _gameInstance.Draw();
            SwapBuffers();
        }
    }
}