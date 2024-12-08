using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespaces utilizados
using mapa_Dino;

namespace dino_obstac
{
    public class Obstac
    {
        private static char obstac;
        private static char[] obstaculos = {
            'p', 'c', 'b','v'
        };

        public static void SortObstac() {
            Random rnd = new Random();
            obstac = obstaculos[rnd.Next(0, 3)];
        }

        public static char CurrentObstac() {
            return obstac;
        }
    }
}
