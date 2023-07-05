using bs.Models;
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
    public class CadastrarDepartamentoViewModel : BaseNotification
    {
        public Departamento _departamento;

        public string Nome { get; set; }

        private string _title;
        public string Title {
            get { return _title; }
            set
            {
                _title = value;
                Notificar();
            } 
        }

        public CadastrarDepartamentoViewModel()
        {
            Title = "Cadastrar Departamento";
        }

        public CadastrarDepartamentoViewModel(Departamento departamento)
        {
            Title = "Editar Departamento";
            _departamento = departamento;
            Nome = _departamento.Nome;
        }

        public Command DefinindoNome
        {
            get
            {
                return new Command(async() =>
                {
                    if (!String. IsNullOrWhiteSpace(Nome))
                    {
                        if (_departamento != null)
                            EditDepartamento();
                        else
                            addNewDepartamento();

                        await Application.Current.MainPage.DisplayAlert("Sucesso", "Departamento salvo com sucesso!", "OK");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Erro", "Verificar Nome", "OK");
                    }

                    Nome = "";
                });
            }
        }

        private async void addNewDepartamento()
        {
            await App.MyDatabase.CreateDepartamento(new Departamento
            {
                Nome = Nome,
            });

        }

        private async void EditDepartamento()
        {
            _departamento.Nome = Nome;
            await App.MyDatabase.UpdateDepartamento(_departamento);
        }
    }
}
