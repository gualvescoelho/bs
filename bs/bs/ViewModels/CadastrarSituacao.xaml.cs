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
    public partial class Cadastrarsugestao : ContentPage
    {
        public List<Departamento> Departamentos { get; set; }
        public Departamento departamentoSelected{ get; set; }
        public Cadastrarsugestao()
        {
            Departamentos = new List<Departamento>();
            CarregarDepartamentos();
            InitializeComponent();
        }

        private void CarregarDepartamentos()
        {
            ServiceDepartamento service = new ServiceDepartamento();
            Departamentos = service.listDepartamentos();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Servicesugestao service = new Servicesugestao();

            Sugestao sugestao = new Sugestao();

            sugestao.Colaborador = txtNome.Text;
            sugestao.Descricao = txtsugestao.Text;
            sugestao.Departamento = departamentoSelected;

            try
            {
                service.CreateOrInsert(sugestao);
            }catch(Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}