
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

namespace FinalProject
{
    [Activity(Label = "cartAdapter")]
    public class cartAdapter : BaseAdapter<cartProducts>
    {
        List<cartProducts> cartItems;
        Activity context;
        public cartAdapter(Activity con,List<cartProducts> products):base(){
            this.cartItems = products;
            this.context = con;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override cartProducts this[int position] {
            get { return cartItems[position]; }
        }

    public override int Count 
        {
            get { return cartItems.Count; }
        }

       

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var myProducts = cartItems[position];
            View view = convertView;
            if(view==null){
                view = context.LayoutInflater.Inflate(Resource.Layout.cart, null);
            }
            view.FindViewById<TextView>(Resource.Id.name).Text = myProducts.cartIName;
            view.FindViewById<TextView>(Resource.Id.quant).Text = myProducts.cartIQuantity;

            return view;


        }
    }
}
