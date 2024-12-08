using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dino_obstac;

namespace mapa_Dino
{
    public class Mapa
    {
        protected char[,] cenario = new char[3, 20];
        private readonly int LARGURA;
        private readonly int ALTURA;
        public Mapa(int alt, int larg)
        {
            LARGURA = larg;
            ALTURA = alt;
        }

        public void CriarCenario()
        {
            for (int i = 0; i < ALTURA; i++)
            {
                for (int j = 0; j < LARGURA; j++)
                    cenario[i, j] = 'n';
            }
        }
        public void mostrarCenario()
        {
            for (int i = 0; i < ALTURA; i++)
            {
                for (int j = 0; j < LARGURA; j++)
                {
                    switch (cenario[i, j])
                    {
                        case 'd':
                            Console.Write("\U0001F996");
                            break;

                        case 'b':
                            Console.Write("\U0001FAA8");
                            break;

                        case 'p':
                            Console.Write("\U0001F573");
                            break;
                        
                        case 'v':
                            Console.Write("\U0001F30B");
                            break;
                        
                        case 'c':
                            Console.Write("\U0001F335");
                            break;

                        default:
                            Console.BackgroundColor = ConsoleColor.Blue;
                            
                            Console.Write(" ");
                            break;
                    }
                }

                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public void AparecerObjeto(int i, int j, char objeto) {
            cenario[i, j] = objeto;
        }
        public void DesaparecerObjeto(int i, int j)
        {
            cenario[i, j] = 'n';
        }

        public int GameOver(int i, int j) {
            if (ColisaoObstaculoCaindo(i, j) == 1) { 
                return 1;
            }
            if (ColisaoObstaculoDeFrente(i,j) == 1) {
                return 1;
            }

            return 0;
        }
        private int ColisaoObstaculoDeFrente(int i, int j) {
            if (j <= 19)
            {
                if (cenario[i, j] == 'd')
                {
                    return 1;
                }

            }
            return 0;
        }
        private int ColisaoObstaculoCaindo(int i, int j)
        {
            if (j <= 19)
            {
                if (cenario[i, j] == Obstac.CurrentObstac())
                {
                    return 1;
                }

            }
            return 0;
        }
    }
}
