using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Support.V4.View;
using Java.Interop;

namespace DesignLayout
{
	[Activity (Label = "DesignLayout", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/Base.Theme.DesignDemo")]
	public class MainActivity : AppCompatActivity
	{

		private DrawerLayout drawerLayout;
		private NavigationView navigationView;
        private Android.Support.V7.Widget.Toolbar toolbar;
        //private Android.Support.V7.Widget.SearchView searchview;

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.toolbar);
			toolbar.SetNavigationIcon (Resource.Drawable.ic_menu);
			SetSupportActionBar (toolbar);
            //toolbar.InflateMenu(Resource.Menu.search_menu);
            drawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);
			navigationView = FindViewById<NavigationView> (Resource.Id.nv_menu);
			navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) => {
				switch (e.MenuItem.ItemId) {
				case Resource.Id.nav_home:
					StartActivity (typeof(SwipeRefreshActivity));
					break;
				case Resource.Id.nav_friends:
					StartActivity (typeof(CollapsingToolbarLayoutActivity));
					break;
				case Resource.Id.coordinator_layout:
					StartActivity (typeof(CoordinatorLayoutActivity));
					break;
				case Resource.Id.coordinator_behavior:
					StartActivity (typeof(CoordinatoBehaviorActivity));
					break;
				default:
					break;
				}
			
				drawerLayout.CloseDrawers ();
			};

		}

		[Export ("floatingclick")]
		public void FloatingClick (View view)
		{
			//add extras menus
		}


		public override bool OnCreateOptionsMenu (Android.Views.IMenu menu)
		{
            
			this.MenuInflater.Inflate (Resource.Menu.main_menu, menu);
            
            /*toolbar.MenuItemClick += (object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e) =>
            {

            };*/
            var searchItem = menu.FindItem(Resource.Id.action_search).ActionView;
            //var test = MenuItemCompat.GetActionView(searchItem);
            SearchManager searchmanager = (SearchManager)GetSystemService(SearchService);
          /*  var searchview = searchItem.JavaCast<Android.Widget.SearchView>();
            
            searchview.SetSearchableInfo(searchmanager.GetSearchableInfo(this.ComponentName));
            searchview.SetIconifiedByDefault(true);*/
            return true;
		}

		public override bool OnOptionsItemSelected (Android.Views.IMenuItem item)
		{
			switch (item.ItemId) {
			case Android.Resource.Id.Home:
				drawerLayout.OpenDrawer (GravityCompat.Start);
				break;
                case Resource.Id.action_search:

                    break;
			default:
				break;
			}
			return base.OnOptionsItemSelected (item);
		}

        public class SearchViewExpandListener
    : Java.Lang.Object, MenuItemCompat.IOnActionExpandListener
        {
            private readonly IFilterable _adapter;

            public SearchViewExpandListener(IFilterable adapter)
            {
                _adapter = adapter;
            }

            public bool OnMenuItemActionCollapse(IMenuItem item)
            {
                _adapter.Filter.InvokeFilter("");
                return true;
            }

            public bool OnMenuItemActionExpand(IMenuItem item)
            {
                return true;
            }
        }
    }
}


