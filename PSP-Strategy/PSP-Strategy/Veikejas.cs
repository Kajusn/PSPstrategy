using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    public class Veikejas
    {
        public int lygis;
        public int gyvybes;
        public double sarvai;
        public float maxZala;
        public string puolimoStrategija;
        public string kilme;
        public Veikejas(int lygis, double sarvai, int maxZala, string kilme)
        {
            this.lygis = lygis;
            this.sarvai = sarvai;
            this.maxZala = maxZala;
            this.kilme = kilme;
        }
        public Veikejas()
        {
            this.lygis = 1;
            this.sarvai = 0;
            this.maxZala = 5;
            this.kilme = "Trofis";
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
