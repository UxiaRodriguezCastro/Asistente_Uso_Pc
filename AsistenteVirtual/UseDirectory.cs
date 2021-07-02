using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace AsistenteVirtual
{
    public class UseDirectory
    {

        public List<String> findfile(String filename, String identity,string desk,string downloads)
        {
            List<String> Files = new List<string>();
            try
            {
                String[] username= new String[50];
                try
                {
                     username = identity.Split('\\');
                }
                catch (Exception)
                {

                    username[1]=identity;
                }
                String filenamecontains = "*" + filename + "*";
               
                string[] DeskFiles = Directory.GetFiles(@""+desk,filenamecontains + ".*", SearchOption.AllDirectories);
                string[] DowloadFiles = Directory.GetFiles(@""+downloads, filenamecontains + ".*", SearchOption.AllDirectories);
                
                if (DeskFiles.Length>0)
                {
                    foreach (string file in DeskFiles)
                    {
                        Files.Add(file);
                    }
                }
                if (DowloadFiles.Length > 0)
                {
                    foreach (string file in DowloadFiles)
                    {
                        Files.Add(file);
                    }
                }
                return Files;
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un problema al buscar el archivo", "¡Oh hubo un problema!", MessageBoxButton.OK);
                return Files;
            }
           
        }


        public bool openFile(String archivo)
        {
            bool result = false;
            Process p = new Process();
            try
            {
                p.StartInfo.FileName = archivo;
                p.Start();
                result = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Hubo un problema al abrir el archivo", "¡Oh hubo un problema!", MessageBoxButton.OK,MessageBoxImage.Error);
                
            }
            return result;
        }

        public List<String> doWithDirectories()
        {
            List<String> wordactions = new List<string>() {
            "Encontrar un archivo que se llama...",
            "Ver todos los archivos que están en el Escritorio del ordenador",
            "Ver todos los archivos que están en las Descargas del ordenador"};

            return wordactions;
        }


		public List<String> selectedoption(int option, string name)
		{
            List<String> Files= new List<string>();
            string identity = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            String[] username = new String[50];
            try
            {
                username = identity.Split('\\');
            }
            catch (Exception)
            {

                username[1] = identity;
            }
            switch (option)
			{
				case 0:
                    Files=this.findfile(name,identity,deskPath,downloadsPath);
                    break;
                case 1:
                    openFile(deskPath);
                    break;
                case 2:
                    openFile(downloadsPath);
                    break;
                default:
					MessageBox.Show("Si no sabe como usar el asistente solo pulse el boton azul de arriba", "¿Problemas?", MessageBoxButton.OK);
					break;
			}
            return Files;
		}
	}
}
