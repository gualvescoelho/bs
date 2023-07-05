using bs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bs.ViewModels
{
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
            sugestaoList.ItemsSource = await App.MyDatabase.SearchSugestao(e.NewTextValue);
        }
    }
}