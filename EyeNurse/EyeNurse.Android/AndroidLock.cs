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

using EyeNurse.Droid;

[assembly : Xamarin.Forms.Dependency(typeof(AndroidLock))]
namespace EyeNurse.Droid
{
    public class AndroidLock : IScreenLock
    {
        public void Lock()
        {
            if (MainActivity.MainActivityInstance != null)
            {
                MainActivity.MainActivityInstance.LockScreen();
            }
        }
    }
}