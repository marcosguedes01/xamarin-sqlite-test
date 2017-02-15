using SQLite.Net.Interop;
using SQLLiteTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

/*
 * Fonte: https://blogs.msdn.microsoft.com/esmsdn/2015/02/13/usando-sqlite-en-desarrollos-multiplataforma/
 */

[assembly: Dependency(typeof(SQLLiteTest.Windows.Config))]

namespace SQLLiteTest.Windows
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
                    //var plat = new SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8();
                    //_plataforma = new SQLitePlatformWP8();
                }

                return _plataforma;
            }
        }
    }
}
