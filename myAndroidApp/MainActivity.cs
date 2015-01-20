using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace myAndroidApp
{
	[Activity (Label = "myAndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, IStackNavigation
	{

		public IStackNavigation NavigationFragment {
			get;
			set;
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			if (NavigationFragment == null) {
				NavigationFragment = new StackNavigationFragment ();
				NavigationFragment.RootFragment = new ListFragment ();
			}
		}

		#region IStackNavigation implementation

		#endregion

		public override void OnBackPressed ()
		{
			try {
				NavigationFragment.Pop();
			} catch (Exception ex) {
				base.OnBackPressed ();
			}
		}
	}
}


