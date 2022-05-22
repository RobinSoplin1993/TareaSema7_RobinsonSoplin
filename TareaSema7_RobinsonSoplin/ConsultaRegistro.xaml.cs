using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Estudiante> tablaEstudiantes;

        public ConsultaRegistro()
        {
            InitializeComponent();
            _connection = DependencyService.Get<Database>().GetConnection();
            get();
        }
        public async void get(){


            try
            {
                var Resultado = await _connection.Table<Estudiante>().ToListAsync();
                tablaEstudiantes = new ObservableCollection<Estudiante>(Resultado);
                ListaUsuario.ItemsSource = tablaEstudiantes;
                
            }
            catch (Exception )
            {

                throw;
            }
        }

        private void ListaUsuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            var ID = Convert.ToInt32(item);
            var nombreItem = obj.Nombre;
            string nombre = nombreItem.ToString();

            var usuarioItem = obj.Usuario;
            string usuario = usuarioItem.ToString();

            var contraseñaItem = obj.Contraseña;
            string contraseña = contraseñaItem.ToString();


            Navigation.PushAsync(new Elemento(ID, nombre, usuario,contraseña));

        }
    }
}