using System;
using System.Collections.Generic;
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
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public Registro()
        {
            InitializeComponent();
            _connection = DependencyService.Get<Database>().GetConnection();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contraseña = txtContraseña.Text };
                _connection.InsertAsync(datosRegistro);
                Navigation.PushAsync(new Login());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "ok");
            }
        }

        private void btnAgregar_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}