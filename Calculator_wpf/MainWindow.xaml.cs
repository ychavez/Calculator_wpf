using Calculator_wpf.Models;
using System.Linq;
using System.Windows;

namespace Calculator_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double numero, resultado;
        Operador operadorSeleccionado;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedValue = 0;

            if (sender == botonCero)
                selectedValue = 0;
            if (sender == botonUno)
                selectedValue = 1;
            if (sender == botonDos)
                selectedValue = 2;
            if (sender == botonTres)
                selectedValue = 3;
            if (sender == botonCuatro)
                selectedValue = 4;
            if (sender == botonCinco)
                selectedValue = 5;
            if (sender == botonSeis)
                selectedValue = 6;
            if (sender == botonSiete)
                selectedValue = 7;
            if (sender == botonOcho)
                selectedValue = 8;
            if (sender == botonNueve)
                selectedValue = 9;

            lblResultado.Content = lblResultado.Content.ToString() == "0" ? $"{selectedValue}" :
                 $"{lblResultado.Content}{selectedValue}";


        }

        private void puntoBoton_Click(object sender, RoutedEventArgs e)
        {
            var db = new MiTiendaContext();

            var orders = db.Orders.ToList();
            if (!lblResultado!.Content!.ToString()!.Contains("."))
            {
                lblResultado.Content = $"{lblResultado.Content}.";
            }
        }

        private void OperacionBoton_Click(object sender, RoutedEventArgs e)
        {
           
            if (double.TryParse(lblResultado.Content.ToString(), out numero))
            {
                lblResultado.Content = "0";
            }

            if (sender == botonSumar)
                operadorSeleccionado = Operador.Suma;
            if (sender == botonRestar)
                operadorSeleccionado = Operador.Resta;
            if (sender == botonMultiplicar)
                operadorSeleccionado = Operador.Multiplicacion;
            if (sender == botonDividir)
                operadorSeleccionado = Operador.Division;



        }

        private void PorcentajeBoton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResultado.Content.ToString(),out numero))
            {
                numero = numero / 100;
                lblResultado.Content = numero.ToString();
            }
        }

        private void ACBoton_Click(object sender, RoutedEventArgs e)
        {
            lblResultado.Content = "0";
        }

        private void MasMenosBoton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResultado.Content.ToString(), out numero))
            {
                numero = numero * -1;
                lblResultado.Content = numero.ToString();
            }
        }

        private void IgualBoton_Click(object sender, RoutedEventArgs e)
        {
            double nuevoValor;

            if (double.TryParse(lblResultado.Content.ToString(), out nuevoValor))
            {
                switch (operadorSeleccionado)
                {
                    case Operador.Suma:
                        resultado = Matematicas.Sumar(numero, nuevoValor);
                        break;
                    case Operador.Resta:
                        resultado = Matematicas.Restar(numero, nuevoValor);
                        break;
                    case Operador.Multiplicacion:
                        resultado = Matematicas.Multiplicar(numero, nuevoValor);
                        break;
                    case Operador.Division:
                        resultado = Matematicas.Dividir(numero, nuevoValor);
                        break;
                    default:
                        break;
                }

                lblResultado.Content = resultado.ToString();
            }
        }
    }

    public enum Operador
    {
        Suma,
        Resta,
        Multiplicacion,
        Division
    }

    public class Matematicas 
    {
        public static double Sumar(double n1, double n2)  => n1 + n2;

        public static double Restar(double n1, double n2) => n1 - n2;

        public static double Multiplicar(double n1, double n2) => n1 * n2;

        public static double Dividir(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("No se puede dividir entre 0","Operacion incorrecta"
                    ,MessageBoxButton.OK,MessageBoxImage.Error);
                return 0;
            }

            return n1 / n2;
        
        }
    }
}

