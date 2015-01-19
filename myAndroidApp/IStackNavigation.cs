using System;
using Android.App;

namespace myAndroidApp
{
	public interface IStackNavigation
	{
		void PopToRoot();
		void Pop();
		void Push(Fragment fragment);
	}
}

