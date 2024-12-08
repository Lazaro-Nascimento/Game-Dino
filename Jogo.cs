using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mapa_Dino;
using dino_Dino;
using dino_obstac;

using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace jogo_Dino
{
    public class Jogo
    {
        private static int _posJ;
        private static int timeDifficult;
        public static int Jogar()
        {
            _posJ = 0;
            timeDifficult = 100;
            Obstac obstac = new Obstac();
            Mapa mapa = new Mapa(3, 20);

            mapa.CriarCenario();

            Dino.Correr(mapa);
            Obstac.SortObstac();

            while (mapa.GameOver(2, _posJ) != 1)
            {
                Thread getTecla = new Thread(InputJump);
                Thread movEnemy = new Thread(FuncMovEnemy);
                
                getTecla.Start(mapa);
                movEnemy.Start(mapa);

                mapa.mostrarCenario();
                Thread.Sleep(timeDifficult); //velocidade de quadros p/segundo, modificar proporcionalmente à quantidade de pontos obtidos!
                Console.Clear();
            }
            return 0;
        }
        public static void InputJump(object obj)
        {
            Mapa mapa = (Mapa)obj;
            Thread threadPular = new Thread(Dino.Pular);

            ConsoleKeyInfo tecla = Console.ReadKey();
            switch (tecla.Key) {
                case ConsoleKey.UpArrow:
                    threadPular.Start(mapa);
                    break;

                case ConsoleKey.W:
                    threadPular.Start(mapa);
                    break;

                case ConsoleKey.Spacebar:
                    threadPular.Start(mapa);
                    break;
            }
        }
        public static void FuncMovEnemy(object obj)
        {
            if (_posJ <= 19)
            {
                Mapa m = (Mapa)obj;

                m.AparecerObjeto(2, _posJ, Obstac.CurrentObstac());
                m.GameOver(2, _posJ);
                Thread.Sleep(timeDifficult);
                m.DesaparecerObjeto(2, _posJ);

                _posJ += 1;
            }
            else {
                Obstac.SortObstac();
                _posJ = 0;
                timeDifficult -= 1;
            }
        }
    }
        
}