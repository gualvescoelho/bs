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
        public CadastrarDepartamento()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ServiceDepartamento service = new ServiceDepartamento();
            Departamento departamento = new Departamento();

            departamento.Nome = txtNome.Text;

            service.CreateOrInsert(departamento);
        }
    }
}