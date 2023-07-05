using bs.Models;
using bs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using bs.ViewModels;

namespace bs.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarDepartamento : ContentPage
    {
        public CadastrarDepartamento()
        {
            InitializeComponent();
            this.BindingContext = new CadastrarDepartamentoViewModel();
        }

        public CadastrarDepartamento(Departamento departamento)
        {
            InitializeComponent();
            this.BindingContext = new CadastrarDepartamentoViewModel(departamento);
        }

    }
}