using System;
using System.Collections.Generic;
using System.Net;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace FirstAndroidApp.Adapters
{
    public class HomeViewCardAdapter : BaseAdapter<RowsList>  
    {  
        List<RowsList> users;

        public HomeViewCardAdapter(List<RowsList> users)
        {
            this.users = users;
        }

        public override RowsList this[int position]
        {
            get
            {
                return users[position];
            }
        }

        public override int Count
        {
            get
            {
                return users.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.DetailListRow, parent, false);

                var photo = view.FindViewById<ImageView>(Resource.Id.imageViewRef);
                var title = view.FindViewById<TextView>(Resource.Id.titleTextView);
                var description = view.FindViewById<TextView>(Resource.Id.DescriptionTextView);

                view.Tag = new ViewHolder() { Photo = photo, Title = title, Description = description };
            }

            var holder = (ViewHolder)view.Tag;
            //var imageBitmap = GetImageBitmapFromUrl(users[position].imageHref);
            //holder.Photo.SetImageBitmap(imageBitmap);
            holder.Title.Text = users[position].Title;
            holder.Description.Text = users[position].description;
            Picasso.With(parent.Context).Load(users[position]?.imageHref).Error(Resource.Mipmap.defaultImage).Into(holder.Photo);
            return view;
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;
            try
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return imageBitmap;
        }
    }

    public class ViewHolder : Java.Lang.Object
    {
        public ImageView Photo { get; set; }
        public TextView Title { get; set; }
        public TextView Description { get; set; }
    }


}
