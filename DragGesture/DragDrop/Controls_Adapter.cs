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

namespace DragGesture
{
	class Controls_Adapter : BaseAdapter<Active_Controls>
	{
		List<Active_Controls> items;

		Activity context;

		// Adapter Builder
		public Controls_Adapter(Activity context,List<Active_Controls> items) : base()
		{
			this.context = context;
			this.items = items;
		}

		// Implemented abstract members of BaseAdapter
		public override long GetItemId (int position)
		{
			return position ;
		}

		//Generating a view
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			//Obtain the object for listing
			var item = items[position];
			View view = convertView;

			if (view == null)
				view = context.LayoutInflater.Inflate(Resource.Layout.DragDropControlCell, null);

			//Assigning TextView
			view.FindViewById<TextView> (Resource.Id.ViewTxt).Text = item.Title;

			//Assigning ImageView
			int id_img = context.Resources.GetIdentifier (item.Icon, "drawable", context.PackageName);
			view.FindViewById<ImageView>(Resource.Id.ViewIcon).SetImageResource(id_img);

			return view;
		}

		//Count of Adapter
		public override int Count
		{
			get { return items.Count; }
		}

		// implemented abstract members of BaseAdapter
		public override Active_Controls this [int index]
		{
			get
			{
				return items[index]; 
			}
		}

		//Updates the changes in Adapter
		public override void NotifyDataSetChanged ()
		{
			base.NotifyDataSetChanged ();
		}

		//Add a new element to Adapter
		public void add(Active_Controls p)
		{
			items.Add (p);
			NotifyDataSetChanged ();
		}

		//Remove elements from Adapter
		public void remove(int index)
		{
			items.RemoveAt (index);
			NotifyDataSetChanged ();
		}

		//Returning the object type
		public Active_Controls AdminSearch(int index)
		{
			return items[index];
		}
	}
}

