using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Realms;
using System;

namespace FinalProject
{
    [Activity(Label = "FinalProject", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText uname;
        EditText password;
        Button btn1;
        Button btn2;
        Realm realmObj;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            uname = FindViewById<EditText>(Resource.Id.txt1);
            password = FindViewById<EditText>(Resource.Id.txt2);
            btn1 = FindViewById<Button>(Resource.Id.btn);
            btn2 = FindViewById<Button>(Resource.Id.btn2);
           
            var config = new RealmConfiguration() { SchemaVersion = 1 };

             realmObj = Realm.GetInstance(config);

            var obj = realmObj.All<Users>();

            btn1.Click+=delegate
            {
                var name = uname.Text;
                var pass = password.Text;
                var Alert = (new AlertDialog.Builder(this)).Create();

                    foreach (var temp in obj)
                    {
                    if(name=="vikram"&&pass=="vikram"){
                        Intent AdminIntent = new Intent(this, typeof(Admin));
                        StartActivity(AdminIntent);
                    }

                    else if (name == temp.Name && pass == temp.Password)
                        {
                        
                            //display welcome screen
                            Intent welcomeScreen = new Intent(this, typeof(Welcome));
                            
                        welcomeScreen.PutExtra("nameValue",name);
                            StartActivity(welcomeScreen);
                            System.Console.WriteLine("name is:" + temp.Name);


                        }

                        else
                        {
                            //display error msg
                            Alert.SetTitle("Alert Dialog");
                            Alert.SetMessage("Invalid Details..!");
                            Alert.SetButton("OK", handllerNotingButton);
                            Alert.Show();

                        }
                    }

            };

            btn2.Click+=delegate {
                
                Intent regscreen = new Intent(this, typeof(Register));
                StartActivity(regscreen);

            
            };
        }

        private void handllerNotingButton(object sender, DialogClickEventArgs e)
        {
            Intent regscreen = new Intent(this, typeof(Register));
            StartActivity(regscreen);
        }
    }
}

