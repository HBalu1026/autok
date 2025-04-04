using System;
using System.Reflection;
using System.Security.Claims;

namespace autok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autok = Auto.BeolvasFajlbol("autok.csv");

            //5.feadat
            Console.WriteLine($"5.feladat: {autok.Count}");

            //6.feladat
            double atlagEladas = autok.Average(x => x.EladottDarabszám);
            Console.WriteLine($"6.feladat: {atlagEladas:F1}");

            //7.feladat
            Console.WriteLine("7.feladat:");
            int aktualisEv = DateTime.Now.Year;
            foreach (var auto in autok.Where(a => a.GyártásiÉv >= aktualisEv - 5))
            {
                Console.WriteLine($"- {auto.Márka} {auto.Modell}: {auto.GyártásiÉv}");
            }

            //8.feladat
            Console.WriteLine("8.feladat:");
            var markaEladasok = autok
                .GroupBy(x => x.Márka)
                .Select(x => new { Marka = x.Key, OsszesEladas = x.Sum(a => a.EladottDarabszám) })
                .OrderByDescending(x => x.OsszesEladas);

            foreach (var marka in markaEladasok)
            {
                Console.WriteLine($"- {marka.Marka}: {marka.OsszesEladas} darab");
            }
        }
    }
}