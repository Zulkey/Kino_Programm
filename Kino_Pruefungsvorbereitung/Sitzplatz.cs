using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSeatController
{

    public class Sitzplatz
    {

       // Bermerkung: Normale Sitze wurden mit durch denkfehler zu Premiumsitzen, sind aber immer noch normale in dem "UI"

        public static int normalPrice;
        public static int premiumPrice;

        private bool premium;
        private bool verfuebar;
        private int reihe;
        private int number;

        // Konstrukteur der Klasse, wir übergeben hier ob der Sitzplatz ein "Premium" sitzt ist (Erste 5 Reihen)
        public Sitzplatz(bool premium, int reihe, int number)
        {
            this.premium = premium; // this wird hier benutzt um den privaten Wert zu ändern.
            this.verfuebar = true; // In diesem fall könnten wir das "this" auch weg lassen, da wir den "verfuebar" Wert nicht über eine andere Klasse erhalten, wegen den c# Konventionen machen wir dies aber nicht.
            this.reihe = reihe;
            this.number = number;
        }
        // Hier bekommen wir den reihe wert, da dieser private ist
        public int getReihe()
        {
            return reihe; 
        }

        // Hier bekommen wir die Platznummer

        public int getNumber()
        {
            return number;
        }

        // Hier bekommen wir den premium wert, da dieser private ist
        public bool istPremium()
        {
            return premium;
        }

        // Hier bekommen wir den verfuegbar wert, da dieser private ist

        public bool istVerfuegbar()
        {
            return verfuebar;
        }

        // Hier setzten wir den Premium wert auf true oder false, falls wir dies überhaubt machen müssen
        public void setPremium(bool premium)
        {
            this.premium = premium;
        }

        // Hier setzten wir den verfuebar wert auf true oder false

        public void setVerfuegbar(bool verfuebar)
        {
            this.verfuebar = verfuebar;
        }
    }
}