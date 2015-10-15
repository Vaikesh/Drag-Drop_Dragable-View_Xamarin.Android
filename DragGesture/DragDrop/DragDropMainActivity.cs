using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Content.PM;

namespace DragGesture
{
	[Activity (Label = "Drag & Drop", Icon = "@drawable/icon")]			
	public class DragDropMainActivity : Activity
	{		
		#region Admin Variables
		List<Active_Controls> Admin = new List<Active_Controls>();
		ListView Admin_List;
		Controls_Adapter adap_Admin;
		#endregion

		#region User Variables
		List<Active_Controls> User = new List<Active_Controls>();
		ListView User_List;
		Controls_Adapter adap_User;
		#endregion

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.DragDropMainLayout);
			Drawable _icon = Resources.GetDrawable (Resource.Drawable.Icon);

			#region List of controls
			Admin.Add(new Active_Controls("Settings", "ic_settings"));
			Admin.Add(new Active_Controls("Map","ic_map"));
			Admin.Add(new Active_Controls("Calender","ic_calender"));
			#endregion

			#region Admin side list (Right)
			Admin_List= FindViewById<ListView> (Resource.Id.Admin_List);
			adap_Admin=new Controls_Adapter(this, Admin);
			Admin_List.Adapter = adap_Admin;

			Admin_List.ItemClick += (s, args) =>{
				AlertDialog.Builder builder = new AlertDialog.Builder(this,AlertDialog.ThemeHoloLight);
				AlertDialog alertDialog = builder.Create();
				alertDialog.SetTitle ("Alert");
				alertDialog.SetIcon(Resources.GetDrawable(Resource.Drawable.Icon));
				alertDialog.SetMessage("This is ADMIN side.");
				alertDialog.SetButton("OK", (sender, e) => { });
				alertDialog.Show();
			};

			//Drag element is triggered
			Admin_List.ItemLongClick += (s, args) => {
				
				//To check whether the object is moved or not
				ClipData data = ClipData.NewPlainText ("Admin", args.Position.ToString ());

				//Initializing Shadow Builder to get the shadow view of the selected Item.
				MyDragShadowBuilder my_shadown_screen = new MyDragShadowBuilder(args.View);

				//Start to drag
				args.View.StartDrag (data, my_shadown_screen, null, 0);
			};

			// Drag event in listview
			Admin_List.Drag += (s, args) => 
			{
				switch (args.Event.Action) {

				//Object started dragging
				case DragAction.Started:
					args .Handled = true;
					break;

					//Object dragged in the view
				case DragAction.Entered:
					args.Handled = true;
					break;

					//Object dragged out the view
				case DragAction.Exited:
					args.Handled = true;
					break;

					//Object is released
				case DragAction.Drop:
					args.Handled = true;

					//Verifying the dragged is whether from the another view
					if(args.Event.ClipDescription.Label.Equals("User"))
					{
						//Recover the index
						int position=int.Parse(args.Event.ClipData.GetItemAt(0).Text);

						//Adding the object where it is released
						adap_Admin.add(adap_User.AdminSearch(position));
						adap_User.remove (position);
					}
					break;

					//Triggred when drag operation is finished
				case DragAction.Ended:
					args.Handled = true;
					break;
				}
			};
			#endregion

			#region User side list (Left)
			User_List= FindViewById<ListView> (Resource.Id.User_List);
			adap_User=new Controls_Adapter(this, User);
			User_List.Adapter = adap_User;

			User_List.ItemClick += (s, args) =>{
				AlertDialog.Builder builder = new AlertDialog.Builder(this,AlertDialog.ThemeHoloLight);
				AlertDialog alertDialog = builder.Create();
				alertDialog.SetTitle ("Alert");
				alertDialog.SetIcon(Resources.GetDrawable(Resource.Drawable.Icon));
				alertDialog.SetMessage("USER");
				alertDialog.SetButton("OK", (sender, e) => { });
				alertDialog.Show();
			};

			//Drag element is triggered
			User_List.ItemLongClick += (s, args) =>
			{
				//To check whether the object is moved or not
				ClipData data = ClipData.NewPlainText ("User",args.Position.ToString());

				//Initializing Shadow Builder to get the shadow view of the selected Item.
				MyDragShadowBuilder my_shadown_screen = new MyDragShadowBuilder (args.View);

				//Start to drag
				args.View.StartDrag (data, my_shadown_screen, null, 0);
			};

			// Drag event in listview
			User_List.Drag += (s, args) => 
			{

				switch (args.Event.Action) {

				//Object started dragging
				case DragAction.Started:
					args .Handled = true;
					break;

					//Object dragged in the view
				case DragAction.Entered:
					args.Handled = true;
					break;

					//Object dragged out the view
				case DragAction.Exited:
					args.Handled = true;
					break;

					//Object is released
				case DragAction.Drop:
					args.Handled = true;

					//Verifying the dragged is whether from the another view
					if(args.Event.ClipDescription.Label.Equals("Admin"))
					{
						//Recover the index
						int position=int.Parse(args.Event.ClipData.GetItemAt(0).Text);

						//Adding the object where it is released
						adap_User.add (adap_Admin.AdminSearch(position));
						adap_Admin.remove (position);
					}
					break;

					//Triggred when drag operation is finished
				case DragAction.Ended:
					args.Handled = true;
					break;
				}
			};
			#endregion
		}



		#region View of the dragging object
		private class MyDragShadowBuilder : View.DragShadowBuilder
		{
			//We define our Drawable will serve to draw
			private Drawable shadow;

			public MyDragShadowBuilder(View v): base (v)
			{
				//Enabling cache of the view that's dragging
				v.DrawingCacheEnabled =true;
				//Recovering bitmap object of the view that's dragging
				Bitmap bm = v.DrawingCache;
				//Initialize Drawable
				shadow = new BitmapDrawable(bm);
				//Filtering color
				shadow.SetColorFilter(Color.ParseColor("#4EB1FB") ,PorterDuff.Mode.Multiply);
			}

			public override void OnProvideShadowMetrics (Point size, Point touch)
			{
				//Dimensions of View
				int width = View.Width;
				int height = View.Height;

				//Assigning dimensions to drawable
				shadow.SetBounds (0, 0, width, height);

				//Establishing the dimensions to Shadow Builder
				size.Set (width, height);

				//Defining position to Shadow Builder while dragging
				touch.Set(width/2, height/2);
			}

			#region Shadown Builder
			public override void OnDrawShadow (Canvas canvas) 
			{
				base.OnDrawShadow (canvas);
				shadow.Draw(canvas);
			}
			#endregion
		}
		#endregion
	}
}

