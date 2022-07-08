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
            //********************** CASO 1: METODO PARA CREAR UN DIRECTORIO ********************** 
            Stream archivo;
            string dir = @"C:\Ruta\DirectorioCSV";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            dir.Clone();

            //********************** CASO 2: Crear archivo    ********************** 
            string path = dir + @"\Products.csv";

            if (!File.Exists(path)) //Para crear el archivo donde se almacena la información   de los pacientes filtrado por grupo sanguineo
            {
                archivo = File.Create(path);
                archivo.Close();
            }




            var objTxt = new Txt();
            objTxt.metodoTXT();

            var objCSV = new Csv();
            objCSV.metodoCSV(path);

            Console.ReadKey();


















        }
    }
}
