using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankautomat
{
    public class Konto
    {
        private Double kontostand;
        private Benutzer owner;

        public Konto(Double kontostandEingabe, Benutzer benutzer)
        {
            this.kontostand = kontostandEingabe;
            this.owner = benutzer;
        }
        public void ChangeKontostand(Double change)
        {
            this.kontostand += change;
        }
        public Double getKontostand()
        {
            return kontostand;
        }
        public bool KannZugegriffenWerdenVon(Benutzer benutzer)
        {
            return (owner == benutzer);
        }
    }

    public class Benutzer
    {
        private String Vorname = "";
        private String Nachname = "";

        public void setVorname(String vorname)
        {
            this.Vorname = vorname;
        }
        public String getVorname()
        {
            return Vorname;
        }
        public void setNachname(String nachname)
        {
            this.Nachname = nachname;
        }
        public String getNachname()
        {
            return Nachname;
        }
    }
}
