using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

namespace DragGesture
{
	[Activity (Label = "Drag Gesture", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation= ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			Button DragnDropBtn = FindViewById<Button> (Resource.Id.DragnDropBtn);
			Button DraggableViewBtn = FindViewById<Button> (Resource.Id.DraggableViewBtn);

			DragnDropBtn.Click += (sender, e) => {
				StartActivity(typeof(DragDropMainActivity));
			};

			DraggableViewBtn.Click += (sender, e) => {
				StartActivity(typeof(DragViewMainActivity));
			};
		}
	}
}


