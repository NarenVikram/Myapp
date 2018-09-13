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
    [Activity(Label = "Admin")]
    public class Admin : Activity
    {
        EditText proname;
        EditText proquantity;
        EditText prodescription;
        EditText catagory;

        Button btn;

        Realm add;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddProducts);
            // Create your application here
            proname = FindViewById<EditText>(Resource.Id.pname1);
            proquantity = FindViewById < EditText>(Resource.Id.pquantity1);
            prodescription = FindViewById<EditText>(Resource.Id.desc1);
            catagory = FindViewById<EditText>(Resource.Id.catagory1);
            btn = FindViewById<Button>(Resource.Id.pbtn);

            var config = new RealmConfiguration() { SchemaVersion = 1 };
            add = Realm.GetInstance(config);
            var Alert = (new AlertDialog.Builder(this)).Create();


            btn.Click+=delegate {
                var pname = proname.Text;
                var pquantity = proquantity.Text;
                var pdesc = prodescription.Text;
                var pcat = catagory.Text;

                var data = new products
                {
                    Name = pname,
                    Quantity = pquantity,
                    Desc = pdesc,
                    Category = pcat
                };
                if (pname != "" || pquantity != "" || pdesc != ""||pcat!="")
                {
                    add.Write(() =>
                    {
                        add.Add(data);
                    });

                    Intent back = new Intent(this, typeof(MainActivity));
                    StartActivity(back);
                 }
                 else
                {
                    Alert.SetTitle("Alert Dialog");
                    Alert.SetMessage("Please Fill..!");
                    Alert.SetButton("OK", (c, ev) =>
                    {
                        // Ok button click task
                    });
                    Alert.Show();
                }
            };


        }


    }
}
