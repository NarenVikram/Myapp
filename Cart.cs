
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
    [Activity(Label = "Cart")]
    public class Cart : Activity
    {

        Spinner spinView;
        ListView cartItems;
        TextView text;
        Realm realmObj;
        string[] spinnerValue = {"Cart","Shop","Logout"};
        string value;
        string action;
        string userName;


        List<cartProducts> Items = new List<cartProducts>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            string pname = Intent.GetStringExtra("productName");
            System.Console.WriteLine("pname is :" + pname);

            SetContentView(Resource.Layout.cartLayout);
            spinView = FindViewById<Spinner>(Resource.Id.spin);
            cartItems = FindViewById<ListView>(Resource.Id.cartList);
            text = FindViewById<TextView>(Resource.Id.cartTxt);

            userName = Intent.GetStringExtra("nameValue");

            var config = new RealmConfiguration() { SchemaVersion = 1 };

            realmObj = Realm.GetInstance(config);

            var productdata = realmObj.All<products>();


            var cartData = realmObj.All<cartProducts>();
            foreach(var temp in productdata){
                var list = new cartProducts();
                if (pname == temp.Name)
                {
                    

                    list.cartIName = temp.Name;
                    list.cartIQuantity = "1";
                    Items.Add(list);
                }
            }

            ArrayAdapter spinAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, spinnerValue);
            spinView.Adapter = spinAdapter;

            spinView.ItemSelected += spinnerSelection;


            var cartList=new cartAdapter(this, Items);

            cartItems.SetAdapter(cartList);


        }

       
        private void spinnerSelection(object sender, AdapterView.ItemSelectedEventArgs e)
         {
             var index = e.Position;
             value = spinnerValue[index];
             action = value;

             if(action=="Shop"){
                 Intent goShop = new Intent(this, typeof(Welcome));
                goShop.PutExtra("nameValue", userName);
                 StartActivity(goShop);

             }
            else if (action=="Logout"){
                 Intent Logout = new Intent(this, typeof(MainActivity));
                 StartActivity(Logout);
             }
            else{
                
            }
         }
    }
}
