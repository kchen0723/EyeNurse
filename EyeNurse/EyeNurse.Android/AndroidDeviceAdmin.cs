using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.App.Admin;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EyeNurse.Droid
{
    [BroadcastReceiver(Permission = "android.permission.BIND_DEVICE_ADMIN")]
    [MetaData("android.app.device_admin", Resource ="@xml/device_admin")]
    [IntentFilter(new[] { "android.app.action.DEVICE_ADMIN_ENABLED", Intent.ActionMain})]
    public class AndroidDeviceAdmin : DeviceAdminReceiver
    {
        public override void OnEnabled(Context context, Intent intent)
        {
            base.OnEnabled(context, intent);
            Toast.MakeText(context, "Lock sreen permission has been granted", ToastLength.Short).Show();

            if (MainActivity.MainActivityInstance != null)
            {
                MainActivity.MainActivityInstance.LoadApp();
            }
        }
    }
}