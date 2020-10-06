using System;
using System.Collections.Generic;

namespace haromszogek

{
    internal class Haromszog
    {
        private double aOldal;
        private double bOldal;
        private double cOldal;



        public double Terulet { get; private set; }
        public double Kerulet { get; private set; }
        public bool Szerkesztheto { get; private set; }

        public List<string> AdatokSzoveg()
        {
            List<string> adatok = new List<string>();
            adatok.Add($"a: {aOldal} - b: {bOldal} - c: {cOldal}");
            
            if (Szerkesztheto)
            {
                adatok.Add($"Kerület: {Kerulet:N2} - Terület: {Terulet:N2}");
            }
            else
            {
                adatok.Add("Nem szerkeszthető!");
            }
            return adatok;
        }

        private void Szerk()
        {
            if (aOldal + bOldal > cOldal && aOldal + cOldal > bOldal && bOldal + cOldal > aOldal)
            {
                Szerkesztheto = true;
                Terulet = TeruletSzamitas();
                Kerulet = KeruletSzamitas();
            }
            else
            {
                Szerkesztheto = false;
                Terulet = 0;
                Kerulet = 0;
            }
        }

        private double TeruletSzamitas()
        {
            double s = (aOldal + bOldal + cOldal) / 2;
            Terulet = System.Math.Sqrt(s * (s - aOldal) * (s - bOldal) * (s - cOldal));
            return Terulet;
        }

        private double KeruletSzamitas()
        {
            Kerulet = aOldal + bOldal + cOldal;
            return Kerulet;
        }

        public Haromszog(string sor)
        {
            string[] adatok = sor.Split(';');
            aOldal = Convert.ToDouble(adatok[0]);
            bOldal = Convert.ToDouble(adatok[1]);
            cOldal = Convert.ToDouble(adatok[2]);
            Szerk();
        }

        public Haromszog(double aOldal, double bOldal, double cOldal)
        {
            this.aOldal = aOldal;
            this.bOldal = bOldal;
            this.cOldal = cOldal;
            Szerk();

        }
    }
}