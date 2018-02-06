using Android.App;
using Android.Widget;
using Android.OS;
using Engine.Android;
using Game.Shared.Base;
using Android.Content.PM;

namespace Game.Android
{
    [Activity(Label = "Game.Android", MainLauncher = true, Theme = "@style/MainTheme", ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : GameActivity
    {
        /// <summary>
        /// Creates the activity
        /// </summary>
        public MainActivity()
            :base(new GLGame())
        {

        }
    }
}

