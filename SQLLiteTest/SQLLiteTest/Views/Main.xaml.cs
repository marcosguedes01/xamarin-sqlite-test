using SQLLiteTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SQLLiteTest.Views
{
    public partial class NovoContao : ContentPage
    {
        public NovoContao()
        {
            InitializeComponent();

            using (var dados = new AcessoDados())
            {
                // Não fazer isto para aplicativos que serão publicados
                this.Lista.ItemsSource = dados.Listar();
            }
        }

        protected void SalvarClicked(object sender, EventArgs e)
        {
            var contato = new Contato
            {
                Nome = this.Nome.Text,
                Email = this.Email.Text,
                Telefone = this.Telefone.Text
            };

            using (var dados = new AcessoDados())
            {
                dados.Insert(contato);
                this.Lista.ItemsSource = dados.Listar();
            }
        }
    }
}
