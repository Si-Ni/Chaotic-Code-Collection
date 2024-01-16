using System;
using System.IO;

namespace Bankautomat
{
    public class Program
    {
        public static Benutzer benutzer = new Benutzer();
        public static Konto konto;
        static void Main(string[] args)
        {
            setInputVorname();
            setInputNachname();
            KontoInputLesenUndFortfahren();

            interagierenMitKonto.Kontooptionen();
        }

        public static void setInputVorname()
        {
            try
            {
                Console.WriteLine("Erstellen eines neuen Kontos...");
                Console.WriteLine("Gib deinen Vornamen ein:");
                Console.WriteLine("------------------------------------------------------------");
                String input = "";
                input = Console.ReadLine();
                if (input.Equals("") || input.Equals(null) || input.Equals(" "))
                {
                    throw new FormatException();
                }
                benutzer.setVorname(input);

                TryToClearConsole();
            }
            catch (FormatException)
            {
                VorFortfahrenAufKeyPressWarten();
                setInputVorname();
            }
        }

        static void VorFortfahrenAufKeyPressWarten()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
            Console.ResetColor();
        }

        static void TryToClearConsole()
        {
            //Try Catch hier Notwendig (sonst wird Fehler ausgelöst, da Tests kein Konsolenfenster öffnen)
            try
            {
                Console.Clear();
            }
            catch (Exception)
            {
                Console.WriteLine("Open console window");
            }
        }

        public static void setInputNachname()
        {
            try {
                Console.WriteLine("Erstellen eines neuen Kontos...");
                Console.WriteLine("Gib deinen Nachnamen ein:");
                Console.WriteLine("------------------------------------------------------------");
                String input = "";
                input = Console.ReadLine();
                if(input.Equals("") || input.Equals(null) || input.Equals(" ")) {
                    throw new FormatException();
                }

                benutzer.setNachname(input);

                TryToClearConsole();
            }
            catch (FormatException)
            {
                VorFortfahrenAufKeyPressWarten();
                setInputNachname();
            }
        }

        public static void KontoInputLesenUndFortfahren()
        {
            Console.WriteLine("Erstellen eines neuen Kontos...");
            Console.WriteLine("Gib deinen aktuellen Kontostand ein:");
            Console.WriteLine("------------------------------------------------------------");
            KontoErstellen();

            TryToClearConsole();
        }

        static void KontoErstellen()
        {
            try {
                double inputDouble = Geldeingabe("KontoErstellen");
                konto = new Konto(inputDouble, benutzer);
            }
            catch(Exception) {
                FehlerAusgebenInvalidInput();
                KontoErstellen();
            }
        }

        public static double Geldeingabe(string aufzurufendeMethode) {
            bool fehler = false;
            String input = "";
            input = Console.ReadLine();
            int countDecimalDigits = input[(input.IndexOf(",") + 1)..].Length;
            if(countDecimalDigits > 2 && input.IndexOf(",") != -1) {
                FehlerAusgebenMehrAls2Nachkommastellen();
                fehler = true;
            }else if(input.IndexOf(".") != -1) {
                FehlerPunktVerwendet();
                fehler = true;
            }
            if(fehler) {
                if(aufzurufendeMethode == "KontoErstellen") {
                    KontoErstellen();
                } else if(aufzurufendeMethode == "GeldAbheben") {
                    interagierenMitKonto.GeldAbheben();
                } else if(aufzurufendeMethode == "GeldEinzahlen") {
                    interagierenMitKonto.GeldEinzahlen();
                }
            }
            return Convert.ToDouble(input);
        }

        static void FehlerPunktVerwendet() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bitte ein Komma (,) anstatt eines Punktes (.) verwenden");
            Console.ResetColor();
        }

        static void FehlerAusgebenMehrAls2Nachkommastellen()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nur 2 Nachkommastellen möglich - erneut versuchen");
            Console.ResetColor();
        }

        public static void FehlerAusgebenInvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ungültige Eingabe - versuche es erneut");
            Console.ResetColor();
        }
    }
}

