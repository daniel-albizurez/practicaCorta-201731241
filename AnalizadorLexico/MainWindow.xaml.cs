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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Analizador_Lexico analizador = new Analizador_Lexico();
            tblResultado.Items.Clear();
            tblResultado.Columns.Clear();
            string[,] resultado = analizador.analizar(txtOracion.Text);
            DataGridTextColumn tipo = new DataGridTextColumn();
            tipo.Header = "Tipo";
            tipo.Width = 125;
            tipo.Binding = new Binding("tipo");
            tblResultado.Columns.Add(tipo);
            DataGridTextColumn lexema = new DataGridTextColumn();
            lexema.Header = "Lexema";
            lexema.Width = 125;
            lexema.Binding = new Binding("lexema");
            tblResultado.Columns.Add(lexema);
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                Lexema token = new Lexema();
                token.tipo = resultado[i, 0];
                token.lexema = resultado[i, 1];
                tblResultado.Items.Add(token);
            }
        }
    }
}
