using SQLLiteTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;
using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

/*
 * Fonte: http://blog.giovannimodica.com/?category=mvvm
 *        https://msdn.microsoft.com/en-us/magazine/mt736454.aspx
 */

[assembly: Dependency(typeof(SQLLiteTest.UWP.Config))]

namespace SQLLiteTest.UWP
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
