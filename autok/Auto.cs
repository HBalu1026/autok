using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autok
{
    internal class Auto
    {
        int sorszám, gyártásiÉv, eladottDarabszám, átlagosEladásiÁr;
        string márka, modell, szín;

        public Auto(string auto)
        {
            string[] tomb = auto.Split(';');

            this.sorszám = int.Parse(tomb[0]);
            this.márka = tomb[1];
            this.modell = tomb[2];
            this.gyártásiÉv = int.Parse(tomb[3]);
            this.szín = tomb[4];
            this.eladottDarabszám = int.Parse(tomb[5]);
            this.átlagosEladásiÁr = int.Parse(tomb[6]);
        }

        public int Sorszám { get => sorszám; }
        public int GyártásiÉv { get => gyártásiÉv; }
        public int EladottDarabszám { get => eladottDarabszám; }
        public int ÁtlagosEladásiÁr { get => átlagosEladásiÁr; }
        public string Márka { get => márka; }
        public string Modell { get => modell; }
        public string Szín { get => szín; }

        public static List<Auto> BeolvasFajlbol(string fajlNev)
        {
            List<Auto> autok = new List<Auto>();
            string[] sorok = File.ReadAllLines(fajlNev);

            for (int i = 1; i < sorok.Length; i++)
            {
                autok.Add(new Auto(sorok[i]));
            }
            return autok;
        }
    }
}
