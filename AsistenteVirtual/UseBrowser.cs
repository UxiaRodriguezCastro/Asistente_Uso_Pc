using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsistenteVirtual
{
    public class UseBrowser
    {

        public void openGoogle(String url)
        {
			try
			{
				Process.Start (@url);
			}
			catch (Exception e)
			{
				//Console.WriteLine(e.ToString());
				MessageBox.Show("Hubo un problema con su busqueda", "ERROR", MessageBoxButton.OK);
				throw;
			}
        }

		public List<String> doWithGoogle()
		{
			List<String> googleaccions = new List<string>() { 
			"Buscar algo en internet",
			"Buscar y ver un video",
			"Leer el periodico de hoy",
			"Pedir cita médica (SERGAS)",
			"Pedir cita para renovación del DNI",
			"Pedir cita para renovación del Carnet de conducir",
			"Pedir cita en la Agencia Tributaria"};

			return googleaccions;
		}

		public void selectedoption(int option) {

			switch (option)
			{
				case 0:
					openGoogle("https://www.google.es");
					break;
				case 1:
					openGoogle("https://www.youtube.com/");
					break;
				case 2:
					openGoogle("https://www.google.com/search?q=leer+periodico+de+hoy");
					break;
				case 3:
					openGoogle("https://www.sergas.es/Asistencia-sanitaria/Cita-previa-atenci%C3%B3n-primaria");
					break;
				case 4:
					openGoogle("https://www.citapreviadnie.es/citaPreviaDniExp/");
					break;
				case 5:
					openGoogle("https://sede.dgt.gob.es/es/permisos-de-conducir/obtencion-renovacion-duplicados-permiso/renovacion-permiso-licencia/index.shtml#");
					break;
				case 6:
					openGoogle("https://www2.agenciatributaria.gob.es/wlpl/TOCP-MUTE/Identificacion");
					break;
				default:
					MessageBox.Show("Si no sabe como usar el asistente solo pulse el boton azul de arriba", "¿Problemas?", MessageBoxButton.OK);
					break;
			}
		}
    }
}
