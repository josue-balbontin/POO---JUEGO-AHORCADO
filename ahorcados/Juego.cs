using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ahorcados
{
    class Juego
    {
       private  Ahorcado juego ;

        public void empezar()
        {   string  continuar="SI";
            while (continuar == "SI") {
                Console.Clear();
            juego = new Ahorcado(obtenereentrada());
            Console.WriteLine("BIENVENIDO AL JUEGO AHORCADOS");
            while (juego.obtenerintentos() > 0 && juego.Ganar()==false)
            {
                Console.WriteLine("                                   intentos:" + juego.obtenerintentos());
                Console.WriteLine();
                juego.mostrarpalabra();
                Console.WriteLine("Ingrese la letra a adivinar");
                string  entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada) || entrada.Length>1)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada no valida intente de nuevo");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    continue;
                }
                char letra = char.ToLower(entrada[0]);
                bool acierto = juego.adivinar(letra);
                Console.Clear();
                if(acierto==true)  Console.WriteLine("Palabra adivinada correctamente");
                else Console.WriteLine("Palabra no adivinada");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.Clear();
            if (juego.Ganar() == true)
            {
                Console.WriteLine("Felicidades adivino la palabra :");
                juego.mostrarpalabra();
            }
            else
            {
                Console.WriteLine("No logro adivinar la palabra:");
                juego.mostrarpalabrasecreta();
            }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Escriba SI, si quiere volver a jugar, si quiere salir escriba cualquier cosa");
                continuar = Console.ReadLine();
            }


        }

        private int obtenereentrada()
        {
            Console.WriteLine("Ingrese el numero de errores ingrese el 0 si quiere predeterminado");
           string  entrada= Console.ReadLine();
            uint salida;
            while (!uint.TryParse(entrada, out salida) )
            {
                Console.WriteLine("Entrada inválida : ingrese un numero entero");
                entrada = Console.ReadLine();
            }
            Console.Clear();
            return (int)salida;
        }

        private class Ahorcado
        {   
            private int intentos;
            private string palabrasecreta;
            private List<char> palabraofuscada = new List<char>();

            public Ahorcado(int intentos=0)
            {
                Random random = new Random();
                Palabras palabras=new Palabras();
                palabrasecreta = palabras.palabrarandom();
                foreach (char a in palabrasecreta)
                {
                    if (random.Next(0, 3)==2)
                    {
                        palabraofuscada.Add(a);
                    }
                    else palabraofuscada.Add('_');
                }
                if (intentos==0 ) this.intentos = palabrasecreta.Length;
                else this.intentos=intentos;

            }
            public bool adivinar(char letra)
            {
                bool comprobador = false;
                for (int i = 0; i < palabrasecreta.Length; i++)
                {
                    if (palabrasecreta[i] == letra)
                    {
                        palabraofuscada[i] = letra;
                        comprobador = true;
                    }
                    
                }
                if (comprobador == false) intentos--;
                return comprobador;

            }
            public int obtenerintentos()
            {
                return intentos; 
            }
            public void mostrarpalabra()
            {   foreach (char a in palabraofuscada)
                {
                    Console.Write(a);
                }
                Console.WriteLine();
            }

            public bool Ganar()
            {   foreach (char a in palabraofuscada)
                {
                    if (a == '_')
                    {
                        return false;
                    }
                    
                }
                return true;

            }
            public void mostrarpalabrasecreta()
            {
                Console.WriteLine(palabrasecreta);
            }
        }

    }
}
