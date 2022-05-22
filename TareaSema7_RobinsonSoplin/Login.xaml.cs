using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TareaSema7_RobinsonSoplin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaSema7_RobinsonSoplin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public Login()
        {
            InitializeComponent();
            _connection = DependencyService.Get<Database>().GetConnection();

        }


        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario,string contraseña) {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario =? and Contraseña =? ", usuario, contraseña);
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resusltado = Select_Where(db,txtUsuario.Text,txtContraseña.Text);
                if (resusltado.Count() > 0){
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario incorrecto", "cerrar");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}