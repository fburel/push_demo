
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

		public FrameLayout StackNabigationFrameLayout{
			get;
			set;
		}
			

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.StackNavigationFragment, null);
			StackNabigationFrameLayout = view.FindViewById<FrameLayout> (Resource.Id.frameLayout1);

			if (FragmentStack == null) {
				FragmentStack = new List<Fragment> ();
				FragmentStack.Add (RootFragment);
				PopToRoot ();
			}


			return view;
		}



		#region IStackNavigation implementation

		public Fragment RootFragment {
			get ;
			set ;
		}


		/// <summary>
		/// Retourne au 1er fragment de la stack
		/// </summary>
		public void PopToRoot ()
		{
			this.FragmentManager.BeginTransaction ()
				.Add (StackNabigationFrameLayout.Id, FragmentStack[0])
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
					.Replace (StackNabigationFrameLayout.Id, FragmentStack [FragmentStack.Count - 1])
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
				.Replace (StackNabigationFrameLayout.Id, FragmentStack [FragmentStack.Count - 1])
				.Commit();

		}

		#endregion
	}
}

