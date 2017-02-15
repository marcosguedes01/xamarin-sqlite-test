using System;
using System.IO;
using SQLite.Net.Interop;
using SQLLiteTest.Interfaces;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLLiteTest.Droid.Config))]

namespace SQLLiteTest.Droid
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
                    //var diretorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    //_diretorioDB = Path.Combine(diretorio, "..", "Library");

                    _diretorioDB = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
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
                    _plataforma = new SQLitePlatformAndroid();
                }

                return _plataforma;
            }
        }
    }
}