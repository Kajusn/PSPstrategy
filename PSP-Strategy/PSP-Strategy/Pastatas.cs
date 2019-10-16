using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    public class Pastatas
    {
        public bool stovi;
        public int aukstis;
        public double gyvybes;
        public double apsaugos;
        public string regionas;
        public string tipas;
        public IGyvybiuSkaiciavimas GyvybiuTipas;

        public Pastatas(int aukstis, double apsaugos, string regionas, string tipas)
        {
            this.aukstis = aukstis;
            this.apsaugos = apsaugos;
            this.regionas = regionas;
            this.tipas = tipas;
            this.GyvybiuTipas = new GyvybiuSkaiciavimasPaprastas();
            this.gyvybes = GyvybiuTipas.veikejoGyvybes(100, apsaugos, aukstis);
        }
        public Pastatas()
        {
            this.aukstis = 1;
            this.apsaugos = 0;
            this.regionas = "Trofis";
            this.tipas = "Gyvenamasis";
        }
    }
}
