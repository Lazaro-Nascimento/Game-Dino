using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using mapa_Dino;

namespace dino_Dino
{
    public class Dino
    {
        private int _vida;

        public static void Pular(object obj) {
            Mapa m = (Mapa)obj;
            m.DesaparecerObjeto(2, 17);
            m.AparecerObjeto(1, 17, 'd');
            Thread.Sleep(500);
            Dino.Correr(m);
        }
        public static void Correr(Mapa m) {
            m.DesaparecerObjeto(1, 17);
            m.AparecerObjeto(2, 17, 'd');
            m.GameOver(2,17);
        }
    }
}
