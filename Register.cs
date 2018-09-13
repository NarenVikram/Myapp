
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

    [Activity(Label = "Register")]
    public class Register : Activity
    {
        Realm realmObj;
        EditText name;
        EditText uname;
        EditText pass;
        EditText age;
        Button btn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Regg);
            // Create your application here
            name = FindViewById<EditText>(Resource.Id.name);
            uname = FindViewById<EditText>(Resource.Id.username);
            pass = FindViewById<EditText>(Resource.Id.pass);
            age = FindViewById<EditText>(Resource.Id.age);
            btn = FindViewById<Button>(Resource.Id.regbtn);

            var config = new RealmConfiguration() { SchemaVersion = 1 };

             realmObj = Realm.GetInstance(config);

            var Alert = (new AlertDialog.Builder(this)).Create();

            btn.Click += delegate
            {

                var namevalue = name.Text;
                var unamevalue = uname.Text;
                var passvalue = pass.Text;
                var agevalue = age.Text;

                var user1 = new Users
                  {
                      Name = namevalue,
                      UserName = unamevalue,
                      Password = passvalue,
                      Age = agevalue

                  };  
                if(namevalue!=""||unamevalue!=""||passvalue!=""||agevalue!=""){
                    realmObj.Write(() =>
                    {
                        realmObj.Add(user1);
                    });
                    Intent login = new Intent(this, typeof(MainActivity));
                    StartActivity(login);
                }
                else{
                    Alert.SetTitle("Alert Dialog");
                    Alert.SetMessage("Invalid Details..!");
                    Alert.SetButton("OK", handllerNotingButton);
                    Alert.Show();

                }


                // Update and persist objects with a thread - safe transaction

              /* realmObj.Write(() =>
                {
                    realmObj.RemoveAll<Users>();
                });*/

                var obj = realmObj.All<Users>();

                var count = 0;
                foreach(var temp in obj){
                    count++;
                    System.Console.WriteLine("the value are :" + temp.UserName+temp.Password+temp.Name +temp.Age+"And count is "+count);
                }
            };
        }

        private void handllerNotingButton(object sender, DialogClickEventArgs e)
        {
            Intent regscreen = new Intent(this, typeof(Register));
            StartActivity(regscreen);

        }
    }
}