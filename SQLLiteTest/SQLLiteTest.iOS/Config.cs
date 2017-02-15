using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Forms;
using SQLLiteTest.Interfaces;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;

[assembly: Dependency(typeof(SQLLiteTest.iOS.Config))]

namespace SQLLiteTest.iOS
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
                    var diretorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    _diretorioDB = Path.Combine(diretorio, "..", "Library");
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
                    _plataforma = new SQLitePlatformIOS();
                }

                return _plataforma;
            }
        }
    }
}
