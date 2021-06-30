using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AsistenteVirtual
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UseBrowser UseGoogle= new UseBrowser();
        UseWord UseWord = new UseWord();

        public MainWindow()
        {
            InitializeComponent();
            
            CB_Programas.ItemsSource = this.getProgramsList();
   

        }

        private void BT_Buscar_Click(object sender, RoutedEventArgs e)
        {
            if (CB_Programas.SelectedIndex >= 0)
            {
                switch (CB_Programas.SelectedIndex)
                {

                    case 0:
                        UseGoogle.selectedoption(CB_elegir.SelectedIndex);
                        break;
                    case 1:
                        UseWord.selectedoption(CB_elegir.SelectedIndex, TB_Plus.Text);
                        break;
                    default:
                        MessageBox.Show("Si no sabe como usar el asistente solo pulse el boton azul de arriba","¿Problemas?",MessageBoxButton.OK);
                        break;
                }
            }
            else
            {
                MessageBox.Show( "Si no sabe como usar el asistente solo pulse el boton azul de arriba", "¿Problemas?", MessageBoxButton.OK);
            }


            if (CB_elegir.SelectedIndex>=0)
            {
                CB_elegir.ItemsSource = null;
                CB_Programas.SelectedIndex = -1;
                TB_Plus.Text = null;
                TB_Plus.Visibility = Visibility.Hidden;
            }
        }

        private void CB_Programas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TB_Plus.Text = null;
            TB_Plus.Visibility = Visibility.Hidden;
            if (CB_Programas.SelectedIndex >= 0)
            {
                switch (CB_Programas.SelectedIndex)
                {

                    case 0:
                        CB_elegir.ItemsSource = UseGoogle.doWithGoogle();
                        break;
                    case 1:
                        CB_elegir.ItemsSource = UseWord.doWithWord();
                        break;
                    default:
                        break;
                }
            }
        }

        private void BT_Question_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Este programa ha sido creado para hacerle mas sencillo el uso de su ordenador.\n\n INSTRUCCIONES DE USO:\n\n1) SELECCIONE EL PROGRAMA QUE USTED QUIERA USAR\n2) SELECCIONE QUE QUIERE HACER\n3) DELE AL BOTON DE LA LUPA\n\nOPCIONAL:\nHabrá veces que se le pedirá escribir informción, solo cubrala EXACTAMENTE como se le indique en el ejemplo", "¿Como uso el asistente?", MessageBoxButton.OK);

        }

        private void CB_elegir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TB_Plus.Text = null;
            TB_Plus.Visibility = Visibility.Hidden;
            if (CB_Programas.SelectedIndex == 1 && CB_elegir.SelectedIndex == 1)
            {
                TB_Plus.Visibility = Visibility.Visible;
                TB_Plus.Text = "FILAS: 5 COLUMNAS: 5";
            }
        }

        #region PROGRAMS


        public List<String> getProgramsList() {
                
            List<String> programs= new List<String>();
            String Program1 = "USAR UN NAVEGADOR";
            String Program2 = "USAR UN EDITOR DE TEXTO";
            programs.Add(Program1);
            programs.Add(Program2);
            return programs;
           }


        #endregion


    }
}
