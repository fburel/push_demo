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

		}

		/// <summary>
		/// Push the specified fragment.
		/// </summary>
		/// <param name="fragment">Fragment.</param>
		public void Push (Fragment fragment)
		{
			this.FragmentStack.Add (fragment);

			this.FragmentManager.BeginTransaction ()
				.Replace (Resource.Id.frameLayout1, FragmentStack [FragmentStack.Count - 1])
				.Commit();

		}

		#endregion

	}
}


