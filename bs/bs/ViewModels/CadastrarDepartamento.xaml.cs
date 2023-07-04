using bs.Models;
using bs.Services;
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
    public partial class CadastrarDepartamento : ContentPage
    {
        bool Edit = false;
        public CadastrarDepartamento()
        {
            Edit = false;
            InitializeComponent();
        }

        Departamento _departamento;
        public CadastrarDepartamento(Departamento departamento)
        {
            InitializeComponent();
            Title = "Editar Departamento";
            _departamento = departamento;
            txtNome.Text = _departamento.Nome;
            txtNome.Focus();

            Edit = true;
        }

        private async void addNewDepartamento()
        {
            await App.MyDatabase.CreateDepartamento(new Departamento
            {
                Nome = txtNome.Text,
            });
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
                await DisplayAlert("Erro", "Revisar nome informado", "OK");
            else if(_departamento!=null)
            {
                EditDepartamento();
            }else
                addNewDepartamento();
        }

        private async void EditDepartamento()
        {
            _departamento.Nome = txtNome.Text;
            await App.MyDatabase.UpdateDepartamento(_departamento);
        }
    }
}