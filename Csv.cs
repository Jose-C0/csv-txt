using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace csv_txt
{
    public class Csv
    {
        public void metodoCSV(string path)
        {
            Console.WriteLine("\t\t CSV \n");

            //********************** CASO 1: ESCRIBIR CSV Sobreescribiendo ********************** 
            Console.WriteLine(" CASO 1: ESCRIBIR CSV Sobreescribiendo...\n ");
            
            StreamWriter csvOut =
               new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));

            List<Product> listEnVs = new List<Product>();

            listEnVs.AddRange(
                new Product[]
                {
                    new Product { Nombre = "Pistola", Precio = 2323.41, Cantidad = 3,  Categoriaa = "Componentes diversos" },
                    new Product { Nombre = "Lubricante", Precio = 22222.65, Cantidad = 73, Categoriaa = "Componentes diversos" },
                    new Product { Nombre = "Amortiguadores", Precio = 205, Cantidad = 22, Categoriaa = "Componentes diversos" },
                    new Product { Nombre = "Boquillas", Precio = 100040, Cantidad = 10, Categoriaa = "Componentes diversos" },
                    new Product { Nombre = "Casquillos", Precio = 32322.65, Cantidad = 4, Categoriaa = "Componentes diversos" },
                    new Product { Nombre = "Escalera Mediana", Precio = 99.99, Cantidad = 200, Categoriaa = "Escalera" },
                    new Product { Nombre = "Escalera Grande", Precio = 80.24, Cantidad = 2, Categoriaa = "Escalera" },
                    new Product { Nombre = "Esmaltes", Precio = 544.60, Cantidad = 100, Categoriaa = "Pinturas" },
                    new Product { Nombre = "Pintura Azul", Precio = 33.22, Cantidad = 30, Categoriaa = "Pinturas" },
                    new Product { Nombre = "Pintura Roja", Precio = 55.99 , Cantidad = 53, Categoriaa = "Pinturas" },
                    new Product { Nombre = "Pintura Negra", Precio = 100.99, Cantidad = 999999, Categoriaa = "Pinturas" }
                });


            foreach (Product x in listEnVs)
            {                                            
                csvOut.Write(x.Nombre + ",");                        
                csvOut.Write(x.Precio + ",");                                                                                                                                                                   
                csvOut.Write(x.Cantidad + ",");
                csvOut.WriteLine(x.Categoriaa );
            }


            csvOut.Close();


            //********************** CASO 2: LEER CSV ********************** 
            Console.WriteLine("  ---------- CASO 2: LEER CSV ---------- \n");


            using (StreamReader csvIn =
                new StreamReader(
                    new FileStream(path, FileMode.Open, FileAccess.Read)))
            {
                List<Product> productsList = new List<Product>();

                while (csvIn.Peek() != -1)
                {
                    string row = csvIn.ReadLine();
                    string[] columns = row.Split(',');


                    Product x = new Product()
                    {
                        Nombre = columns[0],
                        Precio = Convert.ToDouble(columns[1]),
                        Cantidad = Convert.ToInt32(columns[2]),
                        Categoriaa = columns[3]

                    };

                    productsList.Add(x);

                }

                productsList.ForEach(x => Console.WriteLine($"{x.Nombre}, {x.Cantidad}, {x.Precio}, {x.Categoriaa}"));


            }



            Console.WriteLine("");
            // ********************** CASO 3: ESCRIBIR CSV CON APPEND ********************** 
            Console.WriteLine("\n CASO 3: ESCRIBIENDO CSV CON APPEND.....\n");
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
                    new Product { Nombre = "Pintura Roja", Precio = 55.99, Cantidad = 53, Categoriaa = "Pinturas" },
                    new Product { Nombre = "Pintura Negra", Precio = 100.99, Cantidad = 999999, Categoriaa = "Pinturas" }
                });

            csvOut2.WriteLine();

            foreach (Product x in listEnVs)
            {
                csvOut2.Write(x.Nombre + ",");
                csvOut2.Write(x.Precio + ",");
                csvOut2.Write(x.Cantidad + ",");
                csvOut2.WriteLine(x.Categoriaa);
            }

            csvOut2.Close();
        }

    }
}

