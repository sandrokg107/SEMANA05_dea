using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SEMANA05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=LAB1504-29\\SQLEXPRESS; Initial Catalog=Neptuno; User Id=sandro; Password=123456";

        private void Crear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Leer_Click(object sender, RoutedEventArgs e)
        {
            List<Empleado> empleados = new List<Empleado>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ListarEmpleados", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int IdEmpleado = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                string Apellidos = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                                string Nombre = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                                string Cargo = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                                string Tratamiento = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                                DateTime FechaNacimiento = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                                DateTime FechaContratacion = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                                string Direccion = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                                string Ciudad = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                                string Region = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                                string CodPostal = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                                string Pais = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                                string TelDomicilio = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                                string Extension = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                                string Notas = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                                string Jefe = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
                                decimal SueldoBasico = reader.IsDBNull(16) ? 0 : reader.GetDecimal(16);

                                empleados.Add(new Empleado
                                {
                                    IdEmpleado = IdEmpleado,
                                    Apellidos = Apellidos,
                                    Nombre = Nombre,
                                    Cargo = Cargo,
                                    Tratamiento = Tratamiento,
                                    FechaNacimiento = FechaNacimiento,
                                    FechaContratacion = FechaContratacion,
                                    Direccion = Direccion,
                                    Ciudad = Ciudad,
                                    Region = Region,
                                    CodPostal = CodPostal,
                                    Pais = Pais,
                                    TelDomicilio = TelDomicilio,
                                    Extension = Extension,
                                    Notas = Notas,
                                    Jefe = Jefe,
                                    SueldoBasico = SueldoBasico
                                });
                            }
                        }
                    }
                }

                dgEmpleados.ItemsSource = empleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar los empleados: " + ex.Message);
            }

        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string Tratamiento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string CodPostal { get; set; }
        public string Pais { get; set; }
        public string TelDomicilio { get; set; }
        public string Extension { get; set; }
        public string Notas { get; set; }
        public string Jefe { get; set; }
        public decimal SueldoBasico { get; set; }
    }

}