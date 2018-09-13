
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Realms;

namespace FinalProject
{
    public class UserDetails : Fragment
    {
        Activity LocalContext;
        string user;
        TextView name;
        TextView age;
        TextView email;
        TextView password;
        Realm obj;

        public UserDetails(Activity context, string value){
            this.LocalContext = context;
            this.user = value;
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.userDetails, container, false);

            name = view.FindViewById<TextView>(Resource.Id.UserName);
            password = view.FindViewById<TextView>(Resource.Id.UserPass);
            age = view.FindViewById<TextView>(Resource.Id.UserAge);
            email = view.FindViewById<TextView>(Resource.Id.UserEmail);

            var config = new RealmConfiguration() { SchemaVersion = 1 };

            obj = Realm.GetInstance(config);
            var userdata = obj.All<Users>();

            foreach(var temp in userdata){
                if(user==temp.Name){
                    name.Text += temp.Name;
                    password.Text += temp.Password;
                    age.Text += temp.Age;
                    email.Text += temp.UserName;
                }
            }


            return view;


        }
    }
}
