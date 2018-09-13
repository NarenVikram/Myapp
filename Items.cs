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
using Android.Util;
using Realms;
using Android.Database;

namespace FinalProject
{
    [Activity(Label = "Items")]

    public class Items : Fragment
    {
        Realm realmObj;
        string myBodyText;
        string text;
        ListView myList;
        string[] cat = { "Mobile", "Laptop" };
        string category;
        Activity contextLocal;

        string value;

        string userName;
        List<products> Userlist= new List<products>();


        public Items(Activity context, string value,string name)
        {
            myBodyText = value;
            contextLocal = context;
            userName = name;

        }

       

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Item, container, false);
            var sampleTextView = view.FindViewById<TextView>(Resource.Id.myTxt);
            var spinner = view.FindViewById<Spinner>(Resource.Id.spin);
            myList = view.FindViewById<ListView>(Resource.Id.listId);

           /* var config = new RealmConfiguration() { SchemaVersion = 1 };

            realmObj = Realm.GetInstance(config);

            var data = realmObj.All<products>();

            foreach (var temp in data){
                  Userlist.Add(temp);

            }*/
            //ArrayAdapter myAdapter = new ArrayAdapter(contextLocal, Android.Resource.Layout.SimpleListItem1, Userlist);
            ArrayAdapter spinAdapter = new ArrayAdapter(contextLocal, Android.Resource.Layout.SimpleListItem1, cat);
            spinner.Adapter = spinAdapter;

           

            spinner.ItemSelected += spinnerSeletion;


            System.Console.WriteLine("vale is " + category);


           // myList.ItemClick += itemSelected;

          //  var adapter = new CustomAdapter(contextLocal, Userlist);
           // myList.SetAdapter(adapter);

            sampleTextView.Text = "Shop " + myBodyText;

            myList.ItemClick += itemSelectedMethod ;

            var config = new RealmConfiguration() { SchemaVersion = 1 };


            realmObj = Realm.GetInstance(config);
            realmObj.Refresh();
            var data = realmObj.All<products>();

            foreach (var temp in data)
            {
                if (temp.Category == "Mobile")
                {
                    var info = new products();
                    info.Name = temp.Name;
                    info.Desc = temp.Desc;
                    info.Quantity = temp.Quantity;
                    Userlist.Add(info);
                }
            }

            var adapter = new CustomAdapter(contextLocal, Userlist);
            myList.SetAdapter(adapter);


            return view;
        }



        public void spinnerSeletion(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;
            value = cat[index];
            category = value;



           // if (category != "Mobile"){
                var data = realmObj.All<products>();
                Userlist = new List<products>();
                foreach (var temp in data)
                    {
                        if (temp.Category == category)
                        {
                            var info = new products();
                            info.Name = temp.Name;
                            info.Desc = temp.Desc;
                            info.Quantity = temp.Quantity;
                            Userlist.Add(info);
                        }
                } 

                var adapter = new CustomAdapter(contextLocal, Userlist);
                myList.SetAdapter(adapter);
           // }



           


        }

        private void itemSelectedMethod(object sender, AdapterView.ItemClickEventArgs e)
        {
            products productsObj = Userlist[e.Position];
           // text = myList.SelectedItem.ToString();

            
            Intent itemDesc = new Intent(contextLocal, typeof(productDetails));
            itemDesc.PutExtra("nameValue", userName);
            itemDesc.PutExtra("myData", productsObj.Name);
            StartActivity(itemDesc);
        }
    }
}
//