
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
	public class StackNavigationFragment : Fragment, IStackNavigation
	{
		public List<Fragment> FragmentStack {
			get;
			set;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return base.OnCreateView (inflater, container, savedInstanceState);


			// inflate layout...

			PopToRoot ();
		}



		#region IStackNavigation implementation

		public Fragment RootFragment{ get ; set ;}

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
	}
}

