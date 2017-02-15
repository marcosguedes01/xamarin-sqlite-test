using SQLite.Net.Interop;
using SQLite.Net.Platform.WinRT;
using SQLLiteTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLLiteTest.WinPhone.Config))]

namespace SQLLiteTest.WinPhone
{
    public class Config : IConfig
    {
        private string _diretorioDB;
        public string DiretorioDB
        {
            get
            {
                if (String.IsNullOrEmpty(_diretorioDB))
                {
                    _diretorioDB = ApplicationData.Current.LocalFolder.Path;
                }

                return _diretorioDB;
            }
        }

        private ISQLitePlatform _plataforma;
        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLitePlatformWinRT();
                }

                return _plataforma;
            }
        }
    }
}
