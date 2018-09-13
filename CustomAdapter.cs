
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
    [Activity(Label = "CustomAdapter")]
    public class CustomAdapter : BaseAdapter<products>
    {
       
            List<products> myUserListArray;
            Activity context;

        public CustomAdapter(Activity context, List<products> modelList)
                : base()
            {
                this.context = context;
                this.myUserListArray = modelList;
            }
            public override long GetItemId(int position)
            {
                return position;
            }
        public override products this[int position]
            {
                get { return myUserListArray[position]; }
            }
            public override int Count
            {
                get { return myUserListArray.Count; }
            }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //Get the UserModel Object using position
            var MyProducts = myUserListArray[position];

            View view = convertView;
            if (view == null)
            { // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.customLayout, null);
            }

            view.FindViewById<TextView>(Resource.Id.nametxt).Text = MyProducts.Name;
            view.FindViewById<TextView>(Resource.Id.quantity).Text = MyProducts.Quantity;
            view.FindViewById<TextView>(Resource.Id.text).Text = MyProducts.Desc;


            return view;
        }
       
    }
}
