using AnalizadorLexico.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalizadorLexico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Se coloca el enfoque en la caja de texto para facilitar el ingreso de la oración
            txtOracion.Focus();
            //Se quitan las columnas que pudieran estar en la tabla
            tblResultado.Columns.Clear();
            //Se genera una columna para contener texto
            //Con encabezado Tipo, ancho 125 (Ya que la tabla tiene un ancho de 250) y para tener la información del atributo "tipo" en el objeto de cada fila
            DataGridTextColumn tipo = new DataGridTextColumn
            {
                Header = "Tipo",
                Width = 125,
                Binding = new Binding("tipo")
            };
            //Se agrega la columna en la tabla
            tblResultado.Columns.Add(tipo);
            //Se repite el proceso anterior
            DataGridTextColumn lexema = new DataGridTextColumn
            {
                Header = "Lexema",
                Width = 125,
                Binding = new Binding("lexema")
            };
            tblResultado.Columns.Add(lexema);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Se crea un analizador
            Analizador_Lexico analizador = new Analizador_Lexico();
            //Se eliminan las filas existentes en la tabla
            tblResultado.Items.Clear();
            //Se analiza el texto en la caja de texto y se almacenan los resultados
            string[,] resultado = analizador.analizar(txtOracion.Text);
            //Se agrega cada resultado a la tabla
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                tblResultado.Items.Add(new Token() { tipo = resultado[i, 0], lexema = resultado[i, 1] });
            }
        }
    }
}
