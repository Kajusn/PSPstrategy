using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    public class Veikejas
    {
        private enum Klase { Karvedys = 1, Kovotojas, Magas, Alchemikas };
        private enum Kilme { Troja = 1, Maneja, Trofis };
        public int lygis { get; set; }
        public double sarvai { get; set; }
        public bool gyvas;
        public double gyvybes;
        public float maxZala;
        public IPuolimoStrategija PuolimoTipas { get; set; }
        public IGyvybiuSkaiciavimas GyvybiuTipas { get; set; }
        public string kilme;
        public string klase;

        public Veikejas(int kilme, int klase, int lygis, int sarvai, int maxZala)
        {
            this.gyvybes = 300;
            this.lygis = lygis;
            this.sarvai = sarvai;
            this.maxZala = maxZala;
            switch (klase)
            {
                case (int)Klase.Karvedys:
                    this.klase = "Karvedys";
                    break;
                case (int)Klase.Kovotojas:
                    this.klase = "Kovotojas";
                    break;
                case (int)Klase.Magas:
                    this.klase = "Magas";
                    break;
                case (int)Klase.Alchemikas:
                    this.klase = "Alchemikas";
                    break;
                default:
                    this.klase = "Kovotojas";
                    break;
            }
            switch (kilme)
            {
                case (int)Klase.Karvedys:
                    this.kilme = "Troja";
                    break;
                case (int)Klase.Kovotojas:
                    this.kilme = "Maneja";
                    break;
                case (int)Klase.Magas:
                    this.kilme = "Trofis";
                    break;
                default:
                    this.kilme = "Trofis";
                    break;
            }
            this.gyvas = true;
        }
        public Veikejas(int kilme, int klase)
        {
            this.lygis = 1;
            this.sarvai = 0;
            this.maxZala = 5;
            switch (klase)
            {
                case (int)Klase.Karvedys:
                    this.klase = "Karvedys";
                    break;
                case (int)Klase.Kovotojas:
                    this.klase = "Kovotojas";
                    break;
                case (int)Klase.Magas:
                    this.klase = "Magas";
                    break;
                case (int)Klase.Alchemikas:
                    this.klase = "Alchemikas";
                    break;
                default:
                    this.klase = "Kovotojas";
                    break;
            }
            switch (kilme)
            {
                case (int)Klase.Karvedys:
                    this.kilme = "Troja";
                    break;
                case (int)Klase.Kovotojas:
                    this.kilme = "Maneja";
                    break;
                case (int)Klase.Magas:
                    this.kilme = "Trofis";
                    break;
                default:
                    this.kilme = "Trofis";
                    break;
            }
            this.gyvas = true;
        }
        public Veikejas()
        {
            this.lygis = 1;
            this.sarvai = 0;
            this.maxZala = 5;
            this.kilme = "Trofis";
            this.gyvas = true;
            this.klase = "Kovotojas";
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
