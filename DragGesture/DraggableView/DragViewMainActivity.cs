using Android.App;
using Android.OS;
using Android.Views;
namespace DragGesture
{
	[Activity (Label = "Draggable View", Icon = "@drawable/icon")]			
	public class DragViewMainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			View v = new DragView (this);
			SetContentView (v);

			v.Click += (sender, args) => {
				AlertDialog.Builder builder = new AlertDialog.Builder(this,AlertDialog.ThemeHoloDark);
				AlertDialog alertDialog = builder.Create();
				alertDialog.SetTitle ("Alert");
				alertDialog.SetIconAttribute(Android.Resource.Attribute.AlertDialogIcon);
				alertDialog.SetMessage("This is View will drag.");
				alertDialog.SetButton("OK", (s, e) => { });
				alertDialog.Show();
			};


			v.LongClick += (sender, args) => {
				AlertDialog.Builder builder = new AlertDialog.Builder(this,AlertDialog.ThemeHoloDark);
				AlertDialog alertDialog = builder.Create();
				alertDialog.SetTitle ("Alert");
				alertDialog.SetIconAttribute(Android.Resource.Attribute.AlertDialogIcon);
				alertDialog.SetMessage("This is View will drag.");
				alertDialog.SetButton("OK", (s, e) => { });
				alertDialog.Show();
			};
		}
	}
}

