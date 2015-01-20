using System;
using Android.App;

namespace myAndroidApp
{
	public interface IStackNavigation
	{
		Fragment RootFragment{ get ; set ;}
		void PopToRoot();
		void Pop();
		void Push(Fragment fragment);
	}
}

