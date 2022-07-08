using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
 

namespace csv_txt
{
   public class Txt
   {
        public void metodoTXT()
        {
            Console.WriteLine("\t\t TXT");
            // ********** CASO 1:  Escritura en un fichero de texto ****************** 
            Console.WriteLine(" CASO 1:  Escritura en un fichero de texto... \n"); 

            // StreamWriter es la clase que representa a un fichero de texto en el que
            // podemos escribir información.
            StreamWriter fichero;

            fichero = File.CreateText("prueba.txt"); //El fichero de texto lo creamos con el método CreateText, pertenece a la clase File.
                                                     //Para escribir en el fichero, empleamos Write y WriteLine, al igual que hacemos en la consola.
            fichero.WriteLine("Primera linea");
            fichero.Write("Otra linea");
            fichero.WriteLine("Continiacion");

            fichero.Close(); // OJO: Debemos cerrar el fichero con Close, o podría quedar algún dato sin guardar.


            // ********** CASO 2:  Leer un fichero de texto usando ReadLine() ******************
            Console.WriteLine(" --------- CASO 2:  Leer un fichero de texto usando ReadLine()  --------- \n");

            using (StreamReader leerFichero = new StreamReader("prueba.txt")) //Para leer de un fichero no usaremos StreamWriter, sino StreamReader
            {
                string linea = leerFichero.ReadLine(); //Para leer del fichero, usaríamos ReadLine, como hacíamos en la consola.
                Console.WriteLine(linea);
                Console.WriteLine(leerFichero.ReadLine());
            }



            // ********** CASO 2:  Leer un fichero de texto usando ReadToEnd() ******************
            Console.WriteLine(" --------- CASO 2:  Leer un fichero de texto usando ReadToEnd()  --------- \n");

            using (StreamReader leerFichero = new StreamReader("prueba.txt"))
            {
                string linea = leerFichero.ReadToEnd(); // ReadToEnd() Para leer un archivo completo
                Console.WriteLine(linea);
                Console.WriteLine(leerFichero.ReadToEnd());

            }


            // ********** CASO 3:  Añadir texto a un fichero existente  ******************

            Console.WriteLine(" --------- CASO 3:  Añadir texto a un fichero existente AppendText()  --------- \n ");

            fichero = File.AppendText("prueba.txt"); // si el archivo existe será abiero, y la posición actual será colocada al final del archivo, de forma tal que cualquier información escrita, sea agregada al archivo sin modificar lo anterior. En el caso de que el archivo no exista, será creado un nuevo archivo.
            fichero.WriteLine("Otra cadena de texto mas");
            fichero.Close();

            using (StreamReader leerFichero = new StreamReader("prueba.txt"))
            {
                string linea = leerFichero.ReadLine();
                Console.WriteLine(linea);
                Console.WriteLine(leerFichero.ReadLine());

            }

            // También podemos usar un constructor para añadir datos a un fichero existente,
            // pero entonces tendremos que emplear un segundo parámetro booleano, que será
            // "true" para añadir(o "false" para sobreescribir el fichero, si ya existiera):

            // ********** CASO 5:  Usando un constructor para añadir datos  ******************

            Console.WriteLine(" --------- CASO 4:  Usando un constructor para añadir datos --------- \n");

            using (StreamWriter confirmarfichero = new StreamWriter("prueba.txt", false))
            {
                confirmarfichero.WriteLine("LINEA QUE NO DEBERIA EXISTIR");
            }

            using (StreamWriter confirmarfichero2 = new StreamWriter("prueba.txt", true))
            {
                confirmarfichero2.WriteLine("LINEA QUE SI EXISTE");

            }


            //Si un fichero al que queremos acceder se encuentra en otra carpeta, basta con que
            //el nombre de fichero incluya también la ruta.

            string nombreFichero = "d:\\ejemplos\\ejemplo1.txt";

            // Como esta sintaxis puede llegar a resultar incómoda, en C# existe una alternativa:
            //podemos indicar una arroba(@) justo antes de abrir las comillas, y entonces no
            //será necesario delimitar los caracteres de control:

            string nombreFichero2 = @"d:\ejemplos\ejemplo1.txt";

        }
    }
}
