using System;

using Android.App;
using Android.App.Admin;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace EyeNurse.Droid
{
    [Activity(Label = "EyeNurse", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity MainActivityInstance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //LoadApplication(new App());

            MainActivityInstance = this;

            ComponentName adminComponent = new ComponentName(this, Java.Lang.Class.FromType(typeof(AndroidDeviceAdmin)));
            Intent adminIntent = new Intent(DevicePolicyManager.ActionAddDeviceAdmin);
            adminIntent.PutExtra(DevicePolicyManager.ExtraDeviceAdmin, adminComponent);
            adminIntent.PutExtra(DevicePolicyManager.ExtraAddExplanation, "Give Screen Lock Permission");
            StartActivity(adminIntent);
        }

        protected override void OnStart()
        {
            base.OnStart();
            this.LoadApp();
        }

        public void LoadApp()
        {
            LoadApplication(new App());
        }

        public void LockScreen()
        {
            DevicePolicyManager dpm = GetSystemService(Context.DevicePolicyService) as DevicePolicyManager;
            dpm.LockNow();
        }
    }
}