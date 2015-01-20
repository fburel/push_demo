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

		public List<Fragment> FragmentStack {
			get;
			set;
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			if (FragmentStack == null) {
				FragmentStack = new List<Fragment> ();
				FragmentStack.Add (new ListFragment ());

				PopToRoot ();
			}
		}

		#region IStackNavigation implementation
		/// <summary>
		/// Retourne au 1er fragment de la stack
		/// </summary>
		public void PopToRoot ()
		{
			this.FragmentManager.BeginTransaction ()
				.Add (Resource.Id.frameLayout1, FragmentStack[0])
				.Commit();
		}

		/// <summary>
		/// Retourne au fragment précédent
		/// </summary>
		public void Pop ()
		{
			if(this.FragmentStack.Count > 1)
			{
				Fragment last = FragmentStack [FragmentStack.Count - 1];
				FragmentStack.Remove (last);
				this.FragmentManager.BeginTransaction ()
					.SetCustomAnimations(Resource.Animation.slide_in_right, Resource.Animation.slide_out_left)
					.Replace (Resource.Id.frameLayout1, FragmentStack [FragmentStack.Count - 1])
					.Commit();
			}
			else
			{
				throw new Exception ("Error during pop");
			}
		}

		/// <summary>
		/// Push the specified fragment.
		/// </summary>
		/// <param name="fragment">Fragment.</param>
		public void Push (Fragment fragment)
		{
			this.FragmentStack.Add (fragment);

			this.FragmentManager.BeginTransaction ()
				.SetCustomAnimations(Resource.Animation.slide_in_left, Resource.Animation.slide_out_right)
				.Replace (Resource.Id.frameLayout1, FragmentStack [FragmentStack.Count - 1])
				.Commit();

		}

		#endregion

		public override void OnBackPressed ()
		{
			if(this.FragmentStack.Count > 1)
			{
				Pop ();
			}
			else
			{
				base.OnBackPressed ();
			}
		}
	}
}


