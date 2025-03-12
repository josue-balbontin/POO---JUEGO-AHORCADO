using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahorcados
{
    class Palabras
    {

        private List<string> palabras = new List<string>
        {
            "programacion",
            "desarrollo",
            "computadora",
            "tecnologia",
            "algoritmo",
            "metodologia",
            "aplicacion",
            "integracion",
            "sintaxis",
            "compilador",
            "entorno",
            "abstraccion"
        };
        public void agregarpalabra(string palabra)
        {
            palabras.Add(palabra);
            Console.WriteLine("La palabra a sido agregada");
        }
        public void eliminarpalabra(string palabra)
        {
            for (int i = 0; i < palabras.Count; i++)
            {
                if (palabras[i] == palabra)
                {
                    palabras.RemoveAt(i);
                    Console.WriteLine("La palabra a sido eliminada");
                    return;
                }
                
            }
            Console.WriteLine("No se a encontrado la palabra");

        }
        public void mostrarpalabras()
        {   
            foreach (string a  in palabras)
            {
                Console.Write(a+" ");

            }
        }
        public string palabrarandom()
        { Random random = new Random();
            int indice = random.Next(0, palabras.Count);
            return palabras[indice];
        }





    }
}
