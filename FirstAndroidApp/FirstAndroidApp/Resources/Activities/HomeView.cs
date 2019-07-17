
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using FirstAndroidApp.Adapters;
using FirstAndroidApp.Interfaces;
using FirstAndroidApp.Utilities;
using Refit;

namespace FirstAndroidApp.Resources.Activities
{
    [Activity(Label = "HomeView")]
    public class HomeView : Activity
    {
        List<RowsList> detailsList;

        ListView detailListView;
        private SwipeRefreshLayout refreshLayout;
        RecyclerView mRecycleView;
        LinearLayout btnsLayoutView;
        Button listViewBtn;
        Button recyclerViewBtn;
        Button pocBtn;
        private RecyclerView.LayoutManager mLayoutManager;
        RecyclerViewAdapter mAdapter;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomeView);

            await GetDetailList();


            detailListView = FindViewById<ListView>(Resource.Id.DetailListView);
            var gridview = FindViewById<GridView>(Resource.Id.gridview);
            listViewBtn = FindViewById<Button>(Resource.Id.ListViewBtn);
            recyclerViewBtn = FindViewById<Button>(Resource.Id.RecyclerViewBtn);
            btnsLayoutView = FindViewById < LinearLayout>(Resource.Id.BtnsLayout);
            mRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            pocBtn = FindViewById<Button>(Resource.Id.POCBtn);

            
            mAdapter = new RecyclerViewAdapter(detailsList);
            mRecycleView.SetAdapter(mAdapter);
            refreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swipe_refresh);
            refreshLayout.Refresh += RefreshLayout_Refresh;
            listViewBtn.Click += ListViewBtn_Click;
            recyclerViewBtn.Click += RecyclerViewBtn_Click;
            pocBtn.Click += PocBtn_Click;
        }

        private void PocBtn_Click(object sender, EventArgs e)
        {
            btnsLayoutView.Visibility = ViewStates.Gone;
            if (Utility.IsTablet(this))
            {
                detailListView.Visibility = ViewStates.Gone;
                mRecycleView.Visibility = ViewStates.Visible;
                mLayoutManager = new GridLayoutManager(this,2);
                mRecycleView.SetLayoutManager(mLayoutManager);
            }
            else
            {
                detailListView.Visibility = ViewStates.Gone;
                mRecycleView.Visibility = ViewStates.Visible;
                mLayoutManager = new LinearLayoutManager(this);
                mRecycleView.SetLayoutManager(mLayoutManager);
            }
        }

        private void RecyclerViewBtn_Click(object sender, EventArgs e)
        {
            mLayoutManager = new GridLayoutManager(this, 2);
            mRecycleView.SetLayoutManager(mLayoutManager);
            recyclerViewBtn.Visibility = ViewStates.Gone;
            listViewBtn.Visibility = ViewStates.Gone;
            mRecycleView.Visibility = ViewStates.Visible;
            btnsLayoutView.Visibility = ViewStates.Gone;
            detailListView.Visibility = ViewStates.Gone;
        }

        private void ListViewBtn_Click(object sender, EventArgs e)
        {
            detailListView.Adapter = new HomeViewCardAdapter(detailsList);
            recyclerViewBtn.Visibility = ViewStates.Gone;
            listViewBtn.Visibility = ViewStates.Gone;
            mRecycleView.Visibility = ViewStates.Gone;
            btnsLayoutView.Visibility = ViewStates.Gone;
            detailListView.Visibility = ViewStates.Visible;
        }

        private void RefreshLayout_Refresh(object sender, EventArgs e)
        {
            refreshLayout.Refreshing = false;
        }

        private async Task GetDetailList()
        {
            var nsAPI = RestService.For<IDetailService>("https://dl.dropboxusercontent.com");
            var d = await nsAPI.GetList();
            detailsList = d.rows;
        }
    }
}
