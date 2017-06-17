
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Graphics;
using Android.Support.V7.Widget;

namespace DesignLayout
{
	[Activity (Label = "CollapsingToolbarLayoutActivity", Theme = "@style/Base.Theme.DesignDemo")]			
	public class CollapsingToolbarLayoutActivity : AppCompatActivity
	{
		//http://blog.csdn.net/u010687392/article/details/46906657
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.activity_collapsingtoolbarlayout);
			// Create your application here
			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.toolbar);
            toolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_mtrl_am_alpha);
            
			SetSupportActionBar (toolbar);

            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

           

            CollapsingToolbarLayout collapsingToolbarLayout = (CollapsingToolbarLayout)FindViewById (Resource.Id.collapsing_toolbar_layout);  
			collapsingToolbarLayout.Title = "CollapsingTL";  

			var recyclerView = FindViewById<RecyclerView> (Resource.Id.recyclerView);
			recyclerView.SetAdapter (new CustomAdapter ());
			recyclerView.SetLayoutManager (new LinearLayoutManager (this));
		}

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    this.OnBackPressed();
                    break;
                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

    }
}

