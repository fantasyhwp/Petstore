using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Final_weipenghe.model;
using Xamarin.Forms.Xaml;


namespace Final_weipenghe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetCity();
        }
        private async void GetCity()
        {
            string url = "https://date.nager.at/api/v2/publicholidays/2020/US";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var albums = JsonConvert.DeserializeObject<List<City>>(response);
                carouselview.ItemsSource = albums;
                
                
            }
            

        }

        private void ListView_ItemClick(object sender, EventArgs e)
        {
            var listView = (ListView)sender;
            var selectedItm = (City)listView.SelectedItem;
            if (selectedItm.countries == null)
            {
                Navigation.PushAsync(new secondPage());
                DisplayAlert("Failed", "Info is not added", "OK");
            }
          
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            
        }

        private void carouselview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)sender;
            var selectedItm = (City)listView.SelectedItem;
            if (selectedItm.countries == null)
            {
                Navigation.PushAsync(new secondPage());
                DisplayAlert("Failed", "Info is not added", "OK");
            }
        }
    }
}