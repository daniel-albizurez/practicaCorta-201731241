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
            txtOracion.Focus();
            tblResultado.Columns.Clear();
            DataGridTextColumn tipo = new DataGridTextColumn
            {
                Header = "Tipo",
                Width = 125,
                Binding = new Binding("tipo")
            };
            tblResultado.Columns.Add(tipo);
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
            Analizador_Lexico analizador = new Analizador_Lexico();
            tblResultado.Items.Clear();
            string[,] resultado = analizador.analizar(txtOracion.Text);
            
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                tblResultado.Items.Add(new Token() { tipo = resultado[i, 0], lexema = resultado[i, 1] });
            }
        }
    }
}
