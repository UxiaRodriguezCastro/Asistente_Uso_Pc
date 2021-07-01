using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace AsistenteVirtual
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UseBrowser UseGoogle= new UseBrowser();
        UseWord UseWord = new UseWord();
        UseDirectory UseDirectory = new UseDirectory();
        List<String> Files = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            
            CB_Programas.ItemsSource = this.getProgramsList();
   

        }

        private void BT_Buscar_Click(object sender, RoutedEventArgs e)
        {
            bool erase = true;
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
                    case 2:
                        Files=UseDirectory.selectedoption(CB_elegir.SelectedIndex,TB_Plus.Text);
                        if (Files.Count>0 && CB_elegir.SelectedIndex==0)
                        {
                            erase = false;
                            MessageBox.Show("Se han encontrado archivos con el nombre introducido o similar.\nSeleccione el que quiere abrir en el desplegable que aparacerá ahora", "Archivos encontrados", MessageBoxButton.OK, MessageBoxImage.Information);
                            if (CB_elegir.SelectedIndex==0)
                            {
                                TB_Plus.Visibility = Visibility.Hidden;
                                CB_Plus.Visibility = Visibility.Visible;
                                foreach (String item in Files)
                                {
                                    string[] doc = item.Split('\\');
                                   
                                    CB_Plus.Items.Add(doc[4]);
                                  
                                }
                            }
                        }
                        else if(Files.Count==0 && CB_elegir.SelectedIndex == 0)
                        {
                            erase = false;
                            MessageBox.Show("No se han encontrado archivos con ese nombre.\nIntentelo de nuevo", "Archivos no encontrados", MessageBoxButton.OK,MessageBoxImage.Warning);
                        }
                        break;
                    default:
                        MessageBox.Show("Si no sabe como usar el asistente solo pulse el boton azul de arriba","¿Problemas?",MessageBoxButton.OK,MessageBoxImage.Information);
                        break;
                }
            }
            else
            {
                MessageBox.Show( "Si no sabe como usar el asistente solo pulse el boton azul de arriba", "¿Problemas?", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            if (CB_elegir.SelectedIndex>=0&& erase==true)
            {
                cleanselection();
            }
        }

        private void CB_Programas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            altcleanselection();
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
                    case 2:
                        CB_elegir.ItemsSource = UseDirectory.doWithDirectories();
                        break;
                    default:
                        break;
                }
            }
        }

        private void BT_Question_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Este programa ha sido creado para hacerle mas sencillo el uso de su ordenador.\n\n INSTRUCCIONES DE USO:\n\n1) SELECCIONE EL PROGRAMA QUE USTED QUIERA USAR\n2) SELECCIONE QUE QUIERE HACER\n3) DELE AL BOTON DE LA LUPA\n\nOPCIONAL:\nHabrá veces que se le pedirá escribir información de una forma concreta, solo cubrala EXACTAMENTE como se le indique en el ejemplo", "¿Como uso el asistente?", MessageBoxButton.OK);

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
            else if (CB_Programas.SelectedIndex == 2 && CB_elegir.SelectedIndex == 0)
            {
                TB_Plus.Visibility = Visibility.Visible;
            }
        }

        private void CB_Plus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_Plus.SelectedIndex>=0)
            {
                if (CB_Programas.SelectedIndex == 2 && CB_elegir.SelectedIndex == 0)
                {
                    try
                    {
                        bool result = UseDirectory.openFile(Files[CB_Plus.SelectedIndex]);
                        if (result == true)
                        {
                            cleanselection();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Hubo un problema al abrir el archivo", "¡Oh hubo un problema!", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                  
                }
            }
        }

        #region PROGRAMS


        public List<String> getProgramsList() {
                
            List<String> programs= new List<String>();
            String Program1 = "USAR UN NAVEGADOR";
            String Program2 = "USAR UN EDITOR DE TEXTO";
            String Program3 = "USAR UN BUSCADOR DE ARCHIVOS";
            programs.Add(Program1);
            programs.Add(Program2);
            programs.Add(Program3);
            return programs;
           }


        #endregion


        public void cleanselection()
        {
            CB_elegir.ItemsSource = null;
            CB_Programas.SelectedIndex = -1;
            CB_Plus.ItemsSource = null;
            TB_Plus.Text = null;
            Files.Clear();
            TB_Plus.Visibility = Visibility.Hidden;
            CB_Plus.Visibility = Visibility.Hidden;
        }


        public void altcleanselection()
        {
            CB_elegir.ItemsSource = null;
            CB_Plus.ItemsSource = null;
            TB_Plus.Text = null;
            Files.Clear();
            TB_Plus.Visibility = Visibility.Hidden;
            CB_Plus.Visibility = Visibility.Hidden;
        }

       
    }
}
