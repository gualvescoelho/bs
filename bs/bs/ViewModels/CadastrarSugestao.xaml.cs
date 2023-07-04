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
            loadDepartamentos();
            InitializeComponent();
        }

        async void loadDepartamentos()
        {
            departamentoList = await App.MyDatabase.ReadDepartamentos();

            departamentoPicker.ItemsSource = departamentoList;
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            addNewSugestao();
        }

        private async void addNewSugestao()
        {
            var departamento = departamentoPicker.SelectedItem as Departamento;
            await App.MyDatabase.CreateSugestao(new Sugestao
            {
                NomeColaborador = txtNome.Text,
                Descricao = txtSugestao.Text,
                DepartamentoId = departamento.ID,
                Justificativa = txtJustificativa.Text
            });

        }
    }
}