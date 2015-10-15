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
	class Active_Controls
	{
		public Active_Controls(string title, string icon)
		{
			this.Title  = title;
			this.Icon = icon;
		}

		public string Title
		{
			get;
			set;
		}

		public string Icon
		{
			get;
			set;
		}
	}
}

