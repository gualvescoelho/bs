using bs.Models;
using bs.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bs.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarSugestao : ContentPage
    {
        List<Departamento> departamentoList = new List<Departamento>();
        public CadastrarSugestao()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                loadDepartamentos();
            }
            catch (Exception ex)
            {

            }
        }

        async void loadDepartamentos()
        {
            if (await App.MyDatabase.isDepartamentos())
            {
                departamentoList = await App.MyDatabase.ReadDepartamentos();

                departamentoPicker.ItemsSource = departamentoList;
            }
            else
            {
                var create = await DisplayAlert("Aviso", "Antes de cadastrar uma Sugestão cadastre um departamento", "Cadastrar", "Ignorar");

                if (create)
                    await Navigation.PushAsync(new CadastrarDepartamento());
            }
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            addNewSugestao();
        }

        private async void addNewSugestao()
        {
            var departamento = departamentoPicker.SelectedItem as Departamento;

            if (checkEntrys())
            {
                await App.MyDatabase.CreateSugestao(new Sugestao
                {
                    NomeColaborador = txtNome.Text,
                    Descricao = txtSugestao.Text,
                    DepartamentoId = departamento.ID,
                    Justificativa = txtJustificativa.Text
                });

                var edit = await DisplayAlert("Salvo", $"Sugestão do colaborador: {txtNome.Text}", "Ver Listagem", "OK");

                if (edit)
                    await Navigation.PushAsync(new ListarSugestoes());

                cleanEntrys();
            }
            else
            {
                await DisplayAlert("Erro", "Verificar dados", "OK");
            }
        }

        private bool checkEntrys()
        {
            if (!String.IsNullOrWhiteSpace(txtJustificativa.Text)
                || !String.IsNullOrWhiteSpace(txtNome.Text)
                || !String.IsNullOrWhiteSpace(txtSugestao.Text))
            {
                return true;
            }

            return false;
        }

        private void cleanEntrys()
        {
            txtJustificativa.Text = "";
            txtNome.Text = "";
            txtSugestao.Text = "";
            departamentoPicker.SelectedItem = "";
        }
    }
}