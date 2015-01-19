
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
	public class ListFragment : Fragment
	{
		public string[] People {
			get {
				return new[]{ "Jean", "Paul", "Mike", "Filipe" };
			}
		}

		public ListView PeopleListView { get ; set ; }

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			// Association du fragment au XML
			var view = inflater.Inflate (Resource.Layout.ListFragment, null);

			// Binding des composants graphiques
			PeopleListView = view.FindViewById<ListView> (Resource.Id.listView1);

			// Alimentation de la liste via un adapter
			//! Array adapter == DEBUG Only!
//			var adapter = new ArrayAdapter<string> (this.Activity,  	// context
//				Android.Resource.Layout.SimpleListItem1, 				// Layout par defaut
//				People);												// Liste a afficher

			var adapter = new PeopleAdapter (this.Activity, People);

			PeopleListView.Adapter = adapter;

			return view;
		}

	
		public class PeopleAdapter : BaseAdapter<string>
		{

			private Context context;
			private string[] people;

			public PeopleAdapter (Context context, string[] people)
			{
				this.context = context;
				this.people = people;

			}

			#region implemented abstract members of BaseAdapter

			public override long GetItemId (int position)
			{
				return position;
			}

			public override View GetView (int position, View convertView, ViewGroup parent)
			{

				// Recuperer le people a afficher
				string name = this.people[position];

				// Creer une cellule pour afficher la vue
				View cell = convertView;
				if(cell == null)
				{
					LayoutInflater inflater;
					inflater = (LayoutInflater) this.context.GetSystemService (Context.LayoutInflaterService);
					cell = inflater.Inflate (Resource.Layout.Cell, null);

					ViewHolder vh = new ViewHolder ();
					vh.nameTextView = cell.FindViewById<TextView> (Resource.Id.textView2);
					vh.imageView = cell.FindViewById<ImageView> (Resource.Id.imageView1);

					cell.Tag = vh;
				}


				ViewHolder holder = (ViewHolder)cell.Tag;
				holder.nameTextView.Text = name;
				holder.imageView.SetImageResource(Android.Resource.Drawable.ButtonStarBigOn);


				return cell;
			}

			public override int Count {
				get {
					return this.people.Length;
				}
			}

			#endregion

			#region implemented abstract members of BaseAdapter

			public override string this [int index] {
				get {
					return this.people[index];
				}
			}

			#endregion

			public class ViewHolder : Java.Lang.Object
			{
				public TextView nameTextView {
					get;
					set;
				}

				public ImageView imageView {
					get;
					set;
				}
			}
		}
	}
}

