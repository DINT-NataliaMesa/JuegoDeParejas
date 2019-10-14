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
using System.Collections;


namespace JuegoDeParejas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        public int ObtenerDificultad()
        {
            if ((bool)BajaRadioButton.IsChecked)
            {
                return 3;

            }
            else if ((bool)MediaRadioButton.IsChecked)
            {
                return 4;
            }
            else
            {
                return 5;
            }

        }


        public void CrearNImagenes(int filas, ArrayList caracteres)
        {
            for (int i = 0; i < filas; i++)
            {
                CuadriculaGrid.RowDefinitions.Add(new RowDefinition());
            }

            int contador = 0;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < CuadriculaGrid.ColumnDefinitions.Count; j++)
                {
                    Border borderBoton = new Border();
                    Viewbox viewbox = new Viewbox();

                    borderBoton.Child = viewbox;

                    TextBlock textBlock = new TextBlock();

                    viewbox.Child = textBlock;

                    Grid.SetRow(borderBoton, i);
                    Grid.SetColumn(borderBoton, j);
                    textBlock.FontFamily = new FontFamily("Webdings");
                    textBlock.Text = caracteres[contador++].ToString();


                    CuadriculaGrid.Children.Add(borderBoton);


                }
            }

        }


        public ArrayList LlenarArray()
        {

            int dificultad = ObtenerDificultad();

            ArrayList caracteres = null;

            switch (dificultad)
            {
                case 3:
                    caracteres = ArrayDeCaracteres(dificultad * 4);
                    break;
                case 4:
                    caracteres = ArrayDeCaracteres(dificultad * 4);
                    break;
                case 5:
                    caracteres = ArrayDeCaracteres(dificultad * 4);
                    break;
                default:
                    break;
            }

            return caracteres;
        }

        public ArrayList ArrayDeCaracteres(int multiplicador)
        {
            ArrayList arrayList = new ArrayList();

            for (int i = 97; i < 97+(multiplicador/2); i++)
            {
                arrayList.Add((char)i);
                arrayList.Add((char)i);
            }
            return arrayList;
        }

        

        private void IniciarButton_Click(object sender, RoutedEventArgs e)
        {
            ArrayList arrayDeCaracteres = LlenarArray();
            CuadriculaGrid.RowDefinitions.Clear();
            int filas = ObtenerDificultad();
            CrearNImagenes(filas, arrayDeCaracteres);
        }
    }
}
