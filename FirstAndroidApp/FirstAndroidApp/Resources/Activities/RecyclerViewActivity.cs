
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace FirstAndroidApp.Resources.Activities
{
    public class RecyclerViewActivity : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<RowsList> mPhotoAlbum;
        public RecyclerViewActivity(List<RowsList> photoAlbum)
        {
            mPhotoAlbum = photoAlbum;
        }
        public override int ItemCount
        {
            get { return mPhotoAlbum.Count; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;

            //vh.Image.SetImageResource(mPhotoAlbum[position].imageHref);
           // Picasso.With(parent.Context).Load(mPhotoAlbum[position]?.imageHref).Error(Resource.Mipmap.defaultImage).Into(holder.It);

            vh.Caption.Text = mPhotoAlbum[position].Title;
            vh.Description.Text = mPhotoAlbum[position].description;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RecyclerViewCard, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }


    public class Photo
    {
        public int mPhotoID { get; set; }
        public string mCaption { get; set; }
    }
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public TextView Description { get; set; }
        public PhotoViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemview.FindViewById<TextView>(Resource.Id.captionTextView);
            Description = itemview.FindViewById<TextView>(Resource.Id.descriptionTextView);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}
