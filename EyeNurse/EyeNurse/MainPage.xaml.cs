using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EyeNurse
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Screen Locker", "Screen wll be locked", "Cancel");
            DependencyService.Register<IScreenLock>();
            DependencyService.Get<IScreenLock>().Lock();
        }
    }
}
