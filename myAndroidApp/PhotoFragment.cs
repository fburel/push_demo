
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace myAndroidApp
{
	public class PhotoFragment : Fragment
	{
		public string People {
			get;
			set;
		}

		public ImageView PhotoView {
			get;
			set;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			// Association du fragment au XML
			var view = inflater.Inflate (Resource.Layout.PhotoFragment, null);

			// Binding des composants graphiques
			this.PhotoView = view.FindViewById<ImageView> (Resource.Id.imageView1);

		
			if (this.People.Equals ("Filipe")) {
				this.PhotoView.SetImageResource (Android.Resource.Drawable.ButtonStarBigOn);
			}

			return view;
		}
	}
}

