using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    public class Veikejas
    {
        private enum Klase { Karvedys = 1, Kovotojas, Magas, Alchemikas };
        private enum Kilme { Troja = 1, Maneja, Trofis };
        private enum PuolimoTipai { Agresyvus = 1, Saugus};
        private IPuolimoStrategija PuolimoTipas { get; set; }
        private IGyvybiuSkaiciavimas GyvybiuTipas { get; set; }
        public double sarvai { get; set; }
        public int lygis;
        public bool gyvas;
        public double gyvybes;
        public double maxZala;
        public string kilme;
        public string klase;
        public string strategija;

        public Veikejas(int kilme, int klase, int lygis, int sarvai, int maxZala)
        {
            this.GyvybiuTipas = new GyvybiuSkaiciavimasPaprastas();
            this.KeistiLygi(lygis);
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
            this.GyvybiuTipas = new GyvybiuSkaiciavimasPaprastas();
            this.KeistiLygi(5);
            this.sarvai = lygis*10;
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
            this.GyvybiuTipas = new GyvybiuSkaiciavimasPaprastas();
            this.KeistiLygi(1);
            this.sarvai = 0;
            this.maxZala = 5;
            this.kilme = "Trofis";
            this.gyvas = true;
            this.klase = "Kovotojas";
        }

        public void KeistiLygi(int naujasLygis)
        {
            this.lygis = naujasLygis;
            this.gyvybes = this.lygis * 100;
            this.gyvybes = GyvybiuSkaiciavimas();
            if (this.PuolimoTipas != null)
                this.maxZala = this.PuolimoTipas.zalosKeitimas(this.lygis, this.klase);
        }
        private double GyvybiuSkaiciavimas()
        {
            return this.GyvybiuTipas.veikejoGyvybes(this.gyvybes, this.sarvai, this.lygis);
        }
        public void PasirinktiPuolimoTipa(int tipas)
        {
            switch (tipas)
            {
                case (int)PuolimoTipai.Agresyvus:
                    this.PuolimoTipas = new AgresyvusPuolimas();
                    this.strategija = "Agresyvus";
                    break;
                case (int)PuolimoTipai.Saugus:
                    this.PuolimoTipas = new SaugusPuolimas();
                    this.strategija = "Saugus";
                    break;
            }

            this.sarvai = this.PuolimoTipas.puolimoApsauga(this.sarvai, this.klase);
            this.maxZala = this.PuolimoTipas.zalosKeitimas(this.lygis, this.klase);
        }
        public bool Pulti(Veikejas taikinys)
        {
            if (!taikinys.gyvas) return false;
            if (taikinys.sarvai > 0)
            {
                if (this.maxZala >= taikinys.sarvai)
                {
                    taikinys.sarvai = 0;
                    return true;
                }
                else taikinys.sarvai -= this.maxZala;
                return true;
            }
            else if (taikinys.gyvybes > this.maxZala)
            {
                taikinys.gyvybes -= this.maxZala;
                return true;
            }
            else if (taikinys.gyvybes <= this.maxZala)
            {
                taikinys.gyvybes = 0;
                taikinys.gyvas = false;
                return true;
            }
            return false;
        }
    }
}
