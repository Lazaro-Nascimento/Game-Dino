using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dino_Dino;
using jogo_Dino;
using mapa_Dino;

namespace TelaInicial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Jogo jogo = new Jogo();

            if (Jogo.Jogar() == 0)
            {
                Console.WriteLine("Game Over!");
                Console.Clear();
            }
            Console.ReadLine();
        }
    }
}