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
    public partial class Elemento : ContentPage
    {
        public int idSeleccionado;
        private SQLiteAsyncConnection _connection;
        IEnumerable<Estudiante> Rupdate;
        IEnumerable<Estudiante> Rdelete;


        public Elemento(int id,string nombre,string usuario,string contraseña)
        {
            InitializeComponent();
            idSeleccionado = id;
            _connection = DependencyService.Get<Database>().GetConnection();
            txtNombre.Text = nombre;
            txtUsuario.Text = usuario;
            txtContraseña.Text = contraseña;
        }


        public static IEnumerable<Estudiante> Delete (SQLiteConnection db , int id){
            return db.Query<Estudiante>("Delete from Estudiante where id=?" ,id);
        }


        public static IEnumerable <Estudiante> Update (SQLiteConnection db,string nombre,string usuario,string contraseña,int id){
            return db.Query<Estudiante>("Update Estudiante set Nombre = ?, Usuario =?, Contraseña =?, where id =?", nombre, usuario, contraseña, id);

        }


        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                Rupdate = Update(db, txtNombre.Text, txtUsuario.Text, txtContraseña.Text,idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception )
            {

                throw;
            }

        }
            
        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                Rdelete = Delete(db, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}