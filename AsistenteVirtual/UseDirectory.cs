using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace AsistenteVirtual
{
    public class UseDirectory
    {

        public List<String> findfile(String filename, String identity)
        {
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
                string[] DeskFiles = Directory.GetFiles(@"c:\Users\"+username[1]+"\\Desktop", filenamecontains+ ".*", SearchOption.AllDirectories);
                string[] DowloadFiles = Directory.GetFiles(@"c:\Users\" + username[1] + "\\Downloads", filenamecontains + ".*", SearchOption.AllDirectories);
                List<String> Files= new List<string>();
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
                MessageBox.Show("Hubo un problema al buscar el archivo", "", MessageBoxButton.OK);
                throw;
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

                MessageBox.Show("Hubo un problema al abrir el archivo", "", MessageBoxButton.OK);
                throw;
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
                    Files=this.findfile(name,identity);
                    break;
                case 1:
                    openFile(@"c:\Users\" + username[1] + "\\Desktop");
                    break;
                case 2:
                    openFile(@"c:\Users\" + username[1] + "\\Downloads");
                    break;
                default:
					MessageBox.Show("Si no sabe como usar el asistente solo pulse el boton azul de arriba", "¿Problemas?", MessageBoxButton.OK);
					break;
			}
            return Files;
		}
	}
}
