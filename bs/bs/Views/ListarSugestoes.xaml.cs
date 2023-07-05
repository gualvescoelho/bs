using bs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bs.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarSugestoes : ContentPage
    {
        public ListarSugestoes()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                sugestaoList.ItemsSource = await App.MyDatabase.ReadSugestaos();
            }
            catch (Exception ex)
            {

            }
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Sugestao> a = new List<Sugestao>();
            sugestaoList.ItemsSource = a;
            sugestaoList.ItemsSource = await App.MyDatabase.SearchSugestao(e.NewTextValue);
        }
    }
}