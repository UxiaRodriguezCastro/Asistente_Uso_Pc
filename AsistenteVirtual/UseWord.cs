using System;
using System.Collections.Generic;
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
                MessageBox.Show("Error al comprobar el número de filas y columnas, puede que haya introducido algo que no es un número.\n\nSe creará una tabla de 5 filas y 5 columnas", "¡Oh hubo un problema!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            try
            {
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
            catch (Exception)
            {


                MessageBox.Show("El programa no está disponible en su ordenador o ha habido un problema", "Lo siento...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
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
                        MessageBox.Show("El programa no está disponible en su ordenador o ha habido un problema", "Lo siento...", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                    }
                    
                    break;
                case 1:

                        string[] words = tb.Split(' ');
                        if (words.Length==4)
                        {
                            this.createNewDocumentWithTable(words[1], words[3]);
                        }
                        else
                        {
                            MessageBox.Show("Error al comprobar el número de filas y columnas.\nSe creará una tabla de 5 filas y 5 columnas", "¡Oh hubo un problema!", MessageBoxButton.OK, MessageBoxImage.Error);
                            this.createNewDocumentWithTable("5", "5");
                        }
                    
                   
                    break;
                default:
                    MessageBox.Show("Si no sabe como usar el asistente solo pulse el boton azul de arriba", "¿Problemas?", MessageBoxButton.OK);
                    break;
            }
        }
    }
}
