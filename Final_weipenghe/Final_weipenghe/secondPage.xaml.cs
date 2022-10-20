using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Final_weipenghe.model;

namespace Final_weipenghe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class secondPage : ContentPage
    {
        public secondPage()
        {
            InitializeComponent();
            GetCityname();
        }
        private async void GetCityname()
        {
            string url = "https://date.nager.at/api/v2/publicholidays/2020/US";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var albums = JsonConvert.DeserializeObject<List<City>>(response);

                countiesName.ItemsSource = albums;

            }


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void cityName(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)sender;
            var selectedItm = (City)listView.SelectedItem;
        }
    }
}