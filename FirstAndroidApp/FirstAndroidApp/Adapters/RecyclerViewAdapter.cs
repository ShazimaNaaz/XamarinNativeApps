using System;
using System.Collections.Generic;
using System.Net;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace FirstAndroidApp.Adapters
{
    public class RecyclerViewAdapter : RecyclerView.Adapter
	{
		public event EventHandler<int> ItemClick;
		public List<RowsList> mPhotoAlbum;
        Context ParentContext;
		public RecyclerViewAdapter(List<RowsList> photoAlbum)
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
            Picasso.With(ParentContext).Load(mPhotoAlbum[position]?.imageHref).Error(Resource.Mipmap.defaultImage).Into(vh.Image);
            vh.Caption.Text = mPhotoAlbum[position].Title;
			vh.Description.Text = mPhotoAlbum[position].description;
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
            catch (Exception ex)
            {

            }

            return imageBitmap;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RecyclerViewCard, parent, false);
			PhotoViewHolder vh = new PhotoViewHolder(itemView, OnClick);
            ParentContext = parent.Context;
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
