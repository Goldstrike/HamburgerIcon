using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Graphics.Drawable;
using Android.Views;
using Android.Widget;
using HamburgerIcon.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(CustomIconRenderer))]
namespace HamburgerIcon.Droid.Renderers
{
    public class CustomIconRenderer : MasterDetailPageRenderer
    {
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {

                for (var i = 0; i < toolbar.ChildCount; i++)
                {
                    var imageButton = toolbar.GetChildAt(i) as ImageButton;
                    var drawerArrow = imageButton?.Drawable as DrawerArrowDrawable;
                    if (drawerArrow == null)
                        continue;

                    bool displayBack = false;
                    var app = Xamarin.Forms.Application.Current;

                    var detailPage = (app.MainPage as MasterDetailPage).Detail;
                    var navPageLevel = detailPage.Navigation.NavigationStack.Count;
                    if (navPageLevel > 1)
                        displayBack = true;

                    if (!displayBack)
                        ChangeIcon(imageButton, Resource.Drawable.icon);
                }
            }
        }

        private void ChangeIcon(ImageButton imageButton, int id)
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                imageButton.SetImageDrawable(Context.GetDrawable(id));
            imageButton.SetImageResource(id);
        }
    }
}