
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
    [Activity(Label = "productDetails")]

    public class productDetails : Activity

    {
        TextView name;
        TextView quant;
        TextView desc;
        Button btn;
        Realm obj;
        string pname;
        string userName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string text = Intent.GetStringExtra("myData");
            // Create your application here
            System.Console.WriteLine("my data is: " + text);

            // primark key = 

            SetContentView(Resource.Layout.spec);
            name = FindViewById<TextView>(Resource.Id.pname);
            quant = FindViewById<TextView>(Resource.Id.pquant);
            desc= FindViewById<TextView>(Resource.Id.pdesc);
            btn = FindViewById<Button>(Resource.Id.addButton);

            var config = new RealmConfiguration() { SchemaVersion = 1 };
            obj = Realm.GetInstance(config);

            userName = Intent.GetStringExtra("nameValue");

            var data = obj.All<products>();
            foreach(var temp in data){
                if(temp.Name==text){
                    name.Text += temp.Name;
                    quant.Text += temp.Quantity;
                    desc.Text += temp.Desc;
                    pname = temp.Name;
                }
            }
           // var adding = obj.All<cartProducts>();

            btn.Click+=delegate {



                Intent cartdetails = new Intent(this, typeof(Cart));
                cartdetails.PutExtra("nameValue", userName);
                cartdetails.PutExtra("productName", pname);
                StartActivity(cartdetails);

            };


        }
    }
}
