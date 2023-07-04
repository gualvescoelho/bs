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
    public partial class ListarDepartamentos : ContentPage
    {
        public ListarDepartamentos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                departamentoList.ItemsSource = await App.MyDatabase.ReadDepartamentos();
            }catch (Exception ex)
            {

            }
        }

        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as Departamento;
            await Navigation.PushAsync(new CadastrarDepartamento(emp));
        }

        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as Departamento;
            var result = await DisplayAlert("Deletar", $"Deletar: {emp.Nome} ?", "Yes", "No");
            if(result)
            {
                await App.MyDatabase.DeleteDepartamento(emp);
                departamentoList.ItemsSource = await App.MyDatabase.ReadDepartamentos();
            }
        }

        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            departamentoList.ItemsSource = await App.MyDatabase.SearchDepartamento(e.NewTextValue);
        }
    }
}