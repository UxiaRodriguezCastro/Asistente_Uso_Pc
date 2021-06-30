using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsistenteVirtual
{
    class UseWord
    {

        object oMissing = System.Reflection.Missing.Value;
        object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

        public void createNewDocument()
        {
            Microsoft.Office.Interop.Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);
        }

        public void createNewDocumentWithTable(String filas, String columnas)
        {
            int Filas = 5;
            int Columnas = 5;
            try
            {
                Filas = int.Parse(filas);
                Columnas = int.Parse(columnas);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al comprobar el número de filas y columnas", "",MessageBoxButton.OK);
                throw;
            }
            Microsoft.Office.Interop.Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);
            Microsoft.Office.Interop.Word.Table oTable;
            Microsoft.Office.Interop.Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, Filas, Columnas, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            oTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            oTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        }


        public List<String> doWithWord()
        {
            List<String> wordactions = new List<string>() {
            "Crear un nuevo documento vacío",
            "Crear un nuevo documento con una tabla"};

            return wordactions;
        }

        public void selectedoption(int option, string tb)
        {

            switch (option)
            {
                case 0:
                    try
                    {
                        this.createNewDocument();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El programa no está disponible en su ordenador", "Lo siento...", MessageBoxButton.OK);
                        throw;
                    }
                    
                    break;
                case 1:
                    try
                    {
                        string[] words = tb.Split(' ');
                        this.createNewDocumentWithTable(words[1], words[3]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El programa no está disponible en su ordenador", "Lo siento...", MessageBoxButton.OK);
                        throw;
                    }
                    break;
                default:
                    MessageBox.Show("Si no sabe como usar el asistente solo pulse el boton azul de arriba", "¿Problemas?", MessageBoxButton.OK);
                    break;
            }
        }
    }
}
