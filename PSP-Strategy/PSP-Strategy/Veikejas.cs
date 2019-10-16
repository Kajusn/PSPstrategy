using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    public class Veikejas
    {
        public bool gyvas;
        public int lygis;
        public double gyvybes;
        public double sarvai;
        public float maxZala;
        public string puolimoStrategija;
        public string kilme;
        public string klase;

        private IGyvybiuSkaiciavimas gyvybiuAlgoritmas;
        private IPuolimoStrategija puolimoAlgoritmas;
        public Veikejas(int lygis, double sarvai, int maxZala, string kilme, string klase)
        {
            this.lygis = lygis;
            this.sarvai = sarvai;
            this.maxZala = maxZala;
            this.kilme = kilme;
            this.gyvas = true;
            this.klase = klase;
        }
        public Veikejas()
        {
            this.lygis = 1;
            this.sarvai = 0;
            this.maxZala = 5;
            this.kilme = "Trofis";
            this.gyvas = true;
            this.klase = "Gyventojas";
        }

        public int gyvybesApsk()
        {
            return 0;
        }

        public void pulti()
        {
            /*
             * Puolimo strategija gaunama is puolimo strategijos Strategy interfeiso
            */
        }
    }
}
