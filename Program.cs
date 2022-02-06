using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace csv_txt
{
    class Program
    {
        static void Main(string[] args)
        {
            #region csv
            //********************** CASO 1: METODO PARA CREAR UN DIRECTORIO ********************** 
            Stream archivo;
            string dir = @"C:\Ruta\DirectorioCSV";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            //********************** CASO 2: Crear archivo    ********************** 
             string path = dir + @"\Products.csv";

            if (!File.Exists(path)) //Para crear el archivo donde se almacena la información   de los pacientes filtrado por grupo sanguineo
            {
                archivo = File.Create(path);
                archivo.Close();
            }
 



 

            //********************** CASO 4: ESCRIBIR CSV Sobreescribiendo ********************** 
            StreamWriter csvOut =
                new StreamWriter(
                    new FileStream(path, FileMode.Append, FileAccess.Write));

            List<Product> listEnVs = new List<Product>();

            listEnVs.AddRange(
                new Product[]
                {
                    new Product { Nombre = "Pistola", Precio = 2323.41, Cantidad = 3,  Categoriaa = "Componentes diversos " },
                    new Product { Nombre = "Lubricante", Precio = 22222.65, Cantidad = 73, Categoriaa = "Componentes diversos " },
                    //new Product { Nombre = "Amortiguadores", Precio = 1330000, Cantidad = 22, Categoriaa = "Componentes diversos " },
                    //new Product { Nombre = "Boquillas", Precio = 100040, Cantidad = 10, Categoriaa = "Componentes diversos " },
                    //new Product { Nombre = "Casquillos", Precio = 32322.65, Cantidad = 4, Categoriaa = "Componentes diversos " },
                    //new Product { Nombre = "Escalera Mediana", Precio = 99.99, Cantidad = 200, Categoriaa = "Escalera" },
                    //new Product { Nombre = "Escalera Grande", Precio = 80.24, Cantidad = 2, Categoriaa = "Escalera" },
                    //new Product { Nombre = "Esmaltes", Precio = 544.60, Cantidad = 100, Categoriaa = "Pinturas" },
                    //new Product { Nombre = "Pintura Azul", Precio = 33.22, Cantidad = 30, Categoriaa = "Pinturas" },
                    //new Product { Nombre = "Pintura Roja", Precio = 55.99 , Cantidad = 53, Categoriaa = "Pinturas" },
                    //new Product { Nombre = "Pintura Negra", Precio = 100.99, Cantidad = 999999, Categoriaa = "Pinturas" }
                });



            foreach (Product x in listEnVs)
            {
                csvOut.Write(x.Nombre + ",");
                csvOut.Write(x.Cantidad + ",");
                csvOut.Write(x.Precio + ",");
                csvOut.WriteLine(x.Categoriaa);
            }

            csvOut.Close();

            //********************** CASO 3: LEER CSV ********************** 
            StreamReader csvIn =
                new StreamReader(
                    new FileStream(path, FileMode.Open, FileAccess.Read));

            List<Product> products = new List<Product>();
            while (csvIn.Peek() != -1)
            {
                string row = csvIn.ReadToEnd();
                string[] columns = row.Split(',');


                //Product product = new Product();
                //product.Nombre = columns[0];
                //product.Cantidad = Convert.ToInt32(columns[1]);
                //product.Precio = Convert.ToDouble(columns[2]);
                //product.Categoriaa = columns[3];

                Product product = new Product()
                {
                    Nombre = columns[0],
                    Cantidad = Convert.ToInt32(columns[1]),
                    Precio = Convert.ToDouble(columns[2]),
                    Categoriaa = columns[3]

                };

                products.Add(product);

            }
            csvIn.Close();

            products.ForEach(x => Console.WriteLine($"{x.Nombre}, {x.Cantidad}, {x.Precio}, {x.Categoriaa}"));



            //********************** CASO 5: ESCRIBIR CSV CON APPEND ********************** 
            StreamWriter csvOut2 =
                new StreamWriter(
                    new FileStream(path, FileMode.Append, FileAccess.Write));



           listEnVs = new List<Product>(); 

            listEnVs.AddRange(
                new Product[]
                {
                    new Product { Nombre = "Pistola", Precio = 2323.41, Cantidad = 3,  Categoriaa = "Componentes diversos " },
                    new Product { Nombre = "Lubricante", Precio = 22222.65, Cantidad = 73, Categoriaa = "Componentes diversos " },
                    new Product { Nombre = "Amortiguadores", Precio = 1330000, Cantidad = 22, Categoriaa = "Componentes diversos " },
                    new Product { Nombre = "Boquillas", Precio = 100040, Cantidad = 10, Categoriaa = "Componentes diversos " },
                    new Product { Nombre = "Casquillos", Precio = 32322.65, Cantidad = 4, Categoriaa = "Componentes diversos " },
                    new Product { Nombre = "Escalera Mediana", Precio = 99.99, Cantidad = 200, Categoriaa = "Escalera" },
                    new Product { Nombre = "Escalera Grande", Precio = 80.24, Cantidad = 2, Categoriaa = "Escalera" },
                    new Product { Nombre = "Esmaltes", Precio = 544.60, Cantidad = 100, Categoriaa = "Pinturas" },
                    new Product { Nombre = "Pintura Azul", Precio = 33.22, Cantidad = 30, Categoriaa = "Pinturas" },
                    new Product { Nombre = "Pintura Roja", Precio = 55.99 , Cantidad = 53, Categoriaa = "Pinturas" },
                    new Product { Nombre = "Pintura Negra", Precio = 100.99, Cantidad = 999999, Categoriaa = "Pinturas" }
                });

            csvOut2.WriteLine();

            foreach (Product x in listEnVs)
            {
                csvOut2.Write(x.Nombre + ",");
                csvOut2.Write(x.Cantidad + ",");
                csvOut2.Write(x.Precio + ",");
                csvOut2.WriteLine(x.Categoriaa);
            }

            csvOut2.Close();




            #endregion




            //#region txt
            //// ********** CASO 1:  Escritura en un fichero de texto ******************

            //// StreamWriter es la clase que representa a un fichero de texto en el que
            //// podemos escribir información.
            //StreamWriter fichero;

            // fichero = File.CreateText("prueba.txt"); //El fichero de texto lo creamos con el método CreateText, pertenece a la clase File.
            // //Para escribir en el fichero, empleamos Write y WriteLine, al igual que hacemos en la consola.
            // fichero.WriteLine("Primera linea"); 
            // fichero.Write("Otra linea");
            // fichero.WriteLine("Continiacion");

            // fichero.Close(); // OJO: Debemos cerrar el fichero con Close, o podría quedar algún dato sin guardar.




            //using (StreamReader leerFichero = new StreamReader("prueba.txt")) //Para leer de un fichero no usaremos StreamWriter, sino StreamReader
            //{
            //    string linea = leerFichero.ReadLine(); //Para leer del fichero, usaríamos ReadLine, como hacíamos en la consola.
            //    Console.WriteLine(linea);
            //    Console.WriteLine(leerFichero.ReadLine() );

            //}

            //using (StreamReader leerFichero = new StreamReader("prueba.txt"))
            //{
            //    string linea = leerFichero.ReadToEnd(); // ReadToEnd() Para leer un archivo completo
            //    Console.WriteLine(linea);
            //    Console.WriteLine(leerFichero.ReadToEnd());

            //}
            //// ********** CASO 3:  Añadir a un fichero existente  ******************

            //fichero = File.AppendText("prueba.txt"); // si el archivo existe será abiero, y la posición actual será colocada al final del archivo, de forma tal que cualquier información escrita, sea agregada al archivo sin modificar lo anterior. En el caso de que el archivo no exista, será creado un nuevo archivo.
            //fichero.WriteLine("Otra cadena de texto mas");
            //fichero.Close();
            //using (StreamReader leerFichero = new StreamReader("prueba.txt"))
            //{
            //    string linea = leerFichero.ReadLine();
            //    Console.WriteLine(linea);
            //    Console.WriteLine(leerFichero.ReadLine());

            //}

            //// También podemos usar un constructor para añadir datos a un fichero existente,
            //// pero entonces tendremos que emplear un segundo parámetro booleano, que será
            //// "true" para añadir(o "false" para sobreescribir el fichero, si ya existiera):

            //using (StreamWriter confirmarfichero = new StreamWriter("prueba.txt", false))
            //{
            //    confirmarfichero.WriteLine("LINEA QUE NO DEBERIA EXISTIR");
            //}

            //using (StreamWriter confirmarfichero2 = new StreamWriter("prueba.txt", true))
            //{
            //    confirmarfichero2.WriteLine("LINEA QUE SI EXISTE");

            //}

            //// ********** CASO 4:  Ficheros en otras carpetas  ******************

            ////Si un fichero al que queremos acceder se encuentra en otra carpeta, basta con que
            ////el nombre de fichero incluya también la ruta.

            //string nombreFichero = "d:\\ejemplos\\ejemplo1.txt";  

            //// Como esta sintaxis puede llegar a resultar incómoda, en C# existe una alternativa:
            ////podemos indicar una arroba(@) justo antes de abrir las comillas, y entonces no
            ////será necesario delimitar los caracteres de control:

            //string nombreFichero = @"d:\ejemplos\ejemplo1.txt";

            //string  ArchivoProperties = Properties.Settings.Default.NombreDelArchivo;
            //#endregion


        }
    }
}
