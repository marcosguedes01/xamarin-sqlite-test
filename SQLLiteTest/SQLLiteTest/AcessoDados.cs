using SQLite.Net;
using SQLLiteTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLLiteTest
{
    public class AcessoDados : IDisposable
    {
        private SQLiteConnection _connexao;

        public AcessoDados()
        {
            var config = DependencyService.Get<Interfaces.IConfig>();
            _connexao = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "bancodados.db3"));

            _connexao.CreateTable<Contato>();
        }

        public void Insert(Contato contato)
        {
            _connexao.Insert(contato);
        }

        public void Update(Contato contato)
        {
            _connexao.Update(contato);
        }

        public void Delete(Contato contato)
        {
            _connexao.Delete(contato);
        }

        public Contato ObterPorId(int id)
        {
            return _connexao.Table<Contato>().FirstOrDefault(c => c.Id == id);
        }

        public List<Contato> Listar()
        {
            return _connexao.Table<Contato>().OrderBy(c => c.Nome).ToList();
        }

        public void Dispose()
        {
            _connexao.Dispose();
        }
    }
}
