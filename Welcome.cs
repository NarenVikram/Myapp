
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
using Realms;


namespace FinalProject
{
    [Activity(Label = "Welcome")]
    public class Welcome : Activity
    {
        
        Realm Obj;
        string Name;
        List<products> productsData = new List<products>();

       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var config = new RealmConfiguration() { SchemaVersion = 1 };

            Obj = Realm.GetInstance(config);
            //Obj = Realm.GetInstance();
            var UserData = Obj.All<products>();

            /*foreach(var temp in UserData){
                System.Console.WriteLine("value is :"+temp.Name);
                productsData.Add(temp);
            }*/


             Name = Intent.GetStringExtra("nameValue");
            // Create your application here
            RequestWindowFeature(WindowFeatures.ActionBar);

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            AddTab("ItemList", Resource.Drawable.Profile_icon, new Items(this, " Products",Name));
            AddUserTab("userProfile", Resource.Drawable.Profile_icon, new UserDetails(this, Name));

            SetContentView(Resource.Layout.MainTab);




        }

        private void AddUserTab(string TabText,int iconResourceId, Fragment fragment)
        {
            var userTab = this.ActionBar.NewTab();

            userTab.SetCustomView(Resource.Layout.Tab);
            userTab.CustomView.FindViewById<ImageView>(Resource.Id.tabImage).SetImageResource(iconResourceId);
            userTab.CustomView.FindViewById<TextView>(Resource.Id.tabText).Text = TabText;

            userTab.TabSelected+=delegate (object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Replace(Resource.Id.fragmentid, fragment);
            

            };
            this.ActionBar.AddTab(userTab);   
        }

        private void AddTab(string TabText, int iconResourceId, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();

            //tab.SetText(Resource.String.audioId);

            tab.SetCustomView(Resource.Layout.Tab);
            tab.CustomView.FindViewById<ImageView>(Resource.Id.tabImage).SetImageResource(iconResourceId);
            tab.CustomView.FindViewById<TextView>(Resource.Id.tabText).Text = TabText;


            // must set event handler for replacing tabs tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e) {

                e.FragmentTransaction.Replace(Resource.Id.fragmentid, fragment);
            };

            this.ActionBar.AddTab(tab);
        }
    }
}
