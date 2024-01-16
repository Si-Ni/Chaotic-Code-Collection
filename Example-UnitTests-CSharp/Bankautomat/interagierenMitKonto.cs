using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bankautomat.Program;

namespace Bankautomat
{
    public class interagierenMitKonto
    {
        public static void Kontooptionen()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Was möchtest du tun?");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("1: Geld abheben");
            Console.WriteLine("2: Geld einzahlen");
            Console.WriteLine("3: Kontostand anzeigen lassen");
            Console.WriteLine("4: Zugriffsrechte für das Konto überprüfen");
            Console.WriteLine("5: Beenden");
            Console.WriteLine("------------------------------------------------------------");

            KontooptionAuswaehlen();
        }
        static void KontooptionAuswaehlen() {
            var pressedKey = Console.ReadKey();
            Console.WriteLine("");
            if(pressedKey.KeyChar == 49) {
                GeldAbheben();
            } else if(pressedKey.KeyChar == 50) {
                GeldEinzahlen();
            } else if(pressedKey.KeyChar == 51) {
                KontostandAnzeigen();
            } else if(pressedKey.KeyChar == 52) {
                KontoZugriffsrechte();
            } else if(pressedKey.KeyChar == 53) {
                System.Environment.Exit(1);
            } else {
                Console.Clear();
                Console.WriteLine("Ungültige Eingabe");
                Kontooptionen();
            }
        }

        public static void GeldAbheben() {
            Console.WriteLine("Gib den Geldbetrag ein, welchen du abheben möchtest");
            try {
                double Geldbetrag = Geldeingabe("GeldAbheben");
                if(Geldbetrag > 0)
                    Geldbetrag *= -1;
                konto.ChangeKontostand(Geldbetrag);
                Console.Clear();
                Kontooptionen();
            }
            catch(Exception) {
                FehlerAusgebenInvalidInput();
                GeldAbheben();
            }
        }

        public static void GeldEinzahlen() {
            Console.WriteLine("Gib den Geldbetrag ein, welchen du einzahlen möchtest");
            try {
                double Geldbetrag = Geldeingabe("GeldEinzahlen");
                if(Geldbetrag < 0)
                    throw new Exception();
                konto.ChangeKontostand(Geldbetrag);
                Console.Clear();
                Kontooptionen();
            }
            catch(Exception) {
                FehlerAusgebenInvalidInput();
                GeldEinzahlen();
            }
        }

        static void KontostandAnzeigen() {
            double kontostand = Math.Round(konto.getKontostand(), 2);
            Console.WriteLine($"Dein aktueller Kontostand beträgt: {kontostand}");
            Console.ReadKey();
            Kontooptionen();
        }

        static void KontoZugriffsrechte() {
            if(konto.KannZugegriffenWerdenVon(benutzer)) {
                Console.WriteLine("Du bist der Eigentümer und hast somit alle Rechte über das Konto");
            } else {
                Console.WriteLine("Du bist nicht dazu berechtigt auf das Konto zuzugreifen");
            }
            Console.ReadKey();
            Kontooptionen();
        }
    }
}
