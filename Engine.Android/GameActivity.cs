using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Engine.Shared.Base;
using OpenTK;

namespace Engine.Android
{
    public abstract class GameActivity : Activity
    {
        /// <summary>
        /// The view for our game
        /// </summary>
        protected CustomGLView _view;

        /// <summary>
        /// The instance of the game
        /// </summary>
        protected BaseGame _gameInstance;

        /// <summary>
        /// Creates the activity
        /// </summary>
        /// <param name="gameInstance"></param>
        protected GameActivity(BaseGame gameInstance)
        {
            _gameInstance = gameInstance;
        }

        /// <summary>
        /// Called when the activity is created - it creates the view and the game
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _view = new CustomGLView(this, _gameInstance);
            Point point = new Point();
            WindowManager.DefaultDisplay.GetRealSize(point);
            _gameInstance.Init(new Vector2(point.X, point.Y));
            Window.DecorView.SystemUiVisibility |= (StatusBarVisibility)(int)
                (SystemUiFlags.HideNavigation
                | SystemUiFlags.Fullscreen
                | SystemUiFlags.LayoutFullscreen
                | SystemUiFlags.ImmersiveSticky
                | SystemUiFlags.LayoutStable);

            SetContentView(_view);
        }

        /// <summary>
        /// Called when the activity is paused = it pauses the view
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            _view.Pause();
        }

        /// <summary>
        /// Called when the activity is reusmed - it resumes the view
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            _view.Resume();
        }
    }
}