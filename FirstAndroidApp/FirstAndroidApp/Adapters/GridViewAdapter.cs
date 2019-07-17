using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Square.Picasso;

namespace FirstAndroidApp.Adapters
{
    public class GridViewAdapter :BaseAdapter<RowsList>
    {
        Context context;
        List<RowsList> GridViewList;
        public GridViewAdapter(List<RowsList> gridViewList)
        {
            GridViewList = gridViewList;
        }

        public override RowsList this[int position]
        {
            get
            {
                return GridViewList[position];
            }
        }

        public override int Count
        {
            get
            {
                return GridViewList.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view;
            if (convertView == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.GRidViewCell, parent, false);
            }
            else
            {
                view = convertView;
            }


            var imageView = view.FindViewById<ImageView>(Resource.Id.card_image_view);
          //  Picasso.With(parent.Context).Load(GridViewList[position]?.imageHref).Error(Resource.Mipmap.defaultImage);

            var titleTextView = view.FindViewById<TextView>(Resource.Id.titleTextView);
            titleTextView.Text = GridViewList[position].Title;

            var descriptionTextView = view.FindViewById<TextView>(Resource.Id.DescriptionTextView);
            descriptionTextView.Text = GridViewList[position].description;
            return view;
        }

    }
}
