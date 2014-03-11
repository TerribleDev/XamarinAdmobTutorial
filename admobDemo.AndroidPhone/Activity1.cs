// Author: Tommy James Parnell
// notes: Tutorial to show how admob works in xamarin
// email: tparnell8@gmail.com, parnell.tommy@hotmail.com

using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Ads;
using admobDemo;
using admobDemo.AndroidPhone.ad;
namespace admobDemo.AndroidPhone
{
    [Activity(Label = "admobDemo.AndroidPhone", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;
        AdView _bannerad;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            //----------------------------------------------banner add stuff
            _bannerad = AdWrapper.ConstructStandardBanner(this, AdSize.SmartBanner, "your ad id here");
             var listener = new admobDemo.adlistener();
             listener.AdLoaded += () => { };
             _bannerad.AdListener = listener;
             _bannerad.CustomBuild();
            var layout = FindViewById<LinearLayout>(Resource.Id.mainlayout);
            layout.AddView(_bannerad);
            //-------------------------------------------------------------


            //-------------------------------------------------InterstitialAd stuff
            var FinalAd = AdWrapper.ConstructFullPageAdd(this, "your ad id here");
            var intlistener = new admobDemo.adlistener();
            listener.AdLoaded += () => { if (FinalAd.IsLoaded)FinalAd.Show(); };
            FinalAd.AdListener = listener;
            FinalAd.CustomBuild();
            //-------------------------------------------------------------

        }

        protected override void OnResume()
        {
            if (_bannerad != null) _bannerad.Resume();
            base.OnResume();
        }
        protected override void OnPause()
        {
            if(_bannerad != null)_bannerad.Pause();
            base.OnPause();
        }
    }
}

