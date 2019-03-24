using CinemaSeatController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;    //Wird verwendet um das schreiben in Textdateien zu ermöglichen.

namespace Kino_Pruefungsvorbereitung
{
    public class Program
    {

        
        public static string csvUhrzeit;    //Uhrzeit, wird in der "SeatControllerUI.cs" verwendet. "Public static" wird verwendet, damit andere Klassen auf die Variable zugreifen können.
        public static int csvSaal;          //Uhrzeit, wird in der "SeatControllerUI.cs" verwendet. "Public static" wird verwendet, damit andere Klassen auf die Variable zugreifen können.
        public static string csvPlatz;      //Uhrzeit, wird in der "SeatControllerUI.cs" verwendet. "Public static" wird verwendet, damit andere Klassen auf die Variable zugreifen können.



        static void Main(string[] args)
        {
            SeatControllerUI seatControllerUI;      //

            //Deklaration und Initialisierung
            int anzahlSaele = 5;                    //Variable für die Anzahl der Kinosäle
            int eingabeSaal = 0;                    //Variable, in welcher die Eingabe für die Auswahl des Saales gespeichert wird.

            string vorstellung1 = "17:00";          //Um "zahlen" im späteren Code zu vermeiden, eine Variable, die später als Vergleich für die Eingabe der Uhrzeit dient.
            string vorstellung2 = "20:00";          //Um "zahlen" im späteren Code zu vermeiden, eine Variable, die später als Vergleich für die Eingabe der Uhrzeit dient.
            char switchcase;                        //Variable die für die Auswahl zwischen "Reservierung ansehen" und "Reservierung vornehmen" verwendet wird.
            string eingabeUhrzeit = null;           //In diesem String wird die Eingabe der Uhrzeit gespeichert.
           


            //Instanzbildung
            int[] sal1 = { 10, 15 }; //Array mit Reihen und Plätzen für Saal 1.
            int[] sal2 = { 20, 10 }; //Array mit Reihen und Plätzen für Saal 2.
            int[] sal3 = { 15, 20 }; //Array mit Reihen und Plätzen für Saal 3.
            int[] sal4 = { 15, 20 }; //Array mit Reihen und Plätzen für Saal 4.
            int[] sal5 = { 20, 20 }; //Array mit Reihen und Plätzen für Saal 5.

            //Ändern der Farbe der Console auf:
            //Schwarzen Text und
            //einen weißen Hintergrund.


            //Eingabe "Auswahl"
            Console.WriteLine("Willkomen im 'Complex'!");       //Begrüßungsnachricht
            Console.Write("Wollen Sie einen Reservierung vornehmen, dann drücken Sie 'R'. \nWollen Sie eine bereits vorgenommene Reservierung ansehen? Dann drücken Sie 'S'."); //Nachricht für Auswahl, ob der Anwender seine Reservierung ansehen möchte, oder eine solche vornehmen möchte.
            switchcase = Convert.ToChar(Console.ReadLine());    //Die Eingabe wird gespeichert.

            //Verarbeitung
            Console.WriteLine();                                //Absatz
            switchcase = Char.ToUpper(switchcase);              //Sollte die Eingabe einen kleinen Buchstaben enthalten, wird dieser hier zu einem Großbuchstaben.
            switch (switchcase)                                 //Überprüfen des Wertes der Variable "switchcase".      
            {
                case 'R':                                                                                                           //Sollte die Variable den Wert "R" besitzen, wird folgendes gemacht: 
                    {
                        eingabeUhrzeitgoto:                                                                                         //"goto" der Uhrzeit, sollte die Uhrzeit nicht den Werten vorgegebenen Werten entsprechen, wird hierhin gesprungen.
                        Console.Write("Um wie viel Uhr wollen Sie den Film schauen?\n17:00 für 17 Uhr bzw. 20:00: ");               //Nachricht uzr Auswahl der Uhrzeit
                        eingabeUhrzeit = Convert.ToString(Console.ReadLine());                                                      //Eingabe wird in einem String gespeichert
                        Console.WriteLine();                                                                                        //Absatz
                        
                        if (eingabeUhrzeit.Equals(vorstellung1))                                                                    //Sollte die Eingabe dem ganz oben festgelegten Wert entsprechen (wird mit "String.Equals überprüft
                        {
                            Console.WriteLine("Sie haben erfolgreich die Vorstellung um {0} Uhr reserviert. ",vorstellung1);        //Nachricht, dass erfolgreich reserviert wurde
                            Sitzplatz.normalPrice = 10;                                                                             //Der Preis wird auf 10€ gesetzt
                            Sitzplatz.premiumPrice = 8;                                                                             //Der Preis für die ersten 5 Reihen wird auf 8€ gesetzt
                            Program.csvUhrzeit = (vorstellung1);                                                                    //Wert wird in einer Variable gespeichert welche später von einer anderen Klasse verwendet wird.
                        } else if (eingabeUhrzeit.Equals(vorstellung2))                                                                 //Sollte dem nicht so sein, so wird geschaut ob der eingegebene Wert der zweiten Variable entspricht.
                        {
                            Console.WriteLine("Sie haben erfolgreich die Vorstellung um {0} Uhr reserviert. ", vorstellung2);       //sollte dem so sein, kommt eine Nachricht, das reserviert wurde.
                            Sitzplatz.normalPrice = 15;                                                                             //Preis für normale Plätze wird auf 15€ gesetzt
                            Sitzplatz.premiumPrice = 12;                                                                            //Preis für die ersten 5 Reihen wird auf 12€ gesetzt
                            csvUhrzeit = vorstellung2;                                                                              //ganz oben festgelegte Variable bekommt den Wert der Uhrzeit
                        }
                        else if(eingabeUhrzeit == null)                                                                             //Überprüfen ob der eingegebene Wert "0" entspricht.
                        {
                            Console.WriteLine("Bitte gebe alle Daten korrekt ein!");                                                  //Aufforderung die Daten korrekt einzugeben
                            goto eingabeUhrzeitgoto;                                                                                  //Es wird zu dem oben festegelegten Punkt "eingabeUhrzeitgoto" gesprungen
                        } else                                                                                                        //Sollte der eingegebene Wert etwas anderem entsprechen:
                        {
                            Console.WriteLine("Fehler, Uhrzeit nicht gefunden!");                                                     //Ausgeben einer Nachricht.
                            goto eingabeUhrzeitgoto;                                                                                  //Springen zu dem oben genannten Punkt.
                        }
                        Console.WriteLine();                                                                                          //Absatz

                        kinoSaaleingabe:                                                                                              //Stichwort für goto. Tritt ein wenn der Saal ungünstig.

                        //Hier beginnt die Eingabe zur Auswahl des Kinosaals:
                        Console.Write("In welchen Kinosal wollen Sie gehen? ");                             //Nachricht zur Auswahl des Saals
                        eingabeSaal = Convert.ToInt32(Console.ReadLine());                                  //Speichern der Eingabe

                        //Verarbeitung
                        if(eingabeSaal>anzahlSaele)                                                         //Es wird überprüft, ob die Eingabe in dem möglichen Bereich liegt(kleiner/gleich 5 und größer/gleich 1)
                        {
                            Console.WriteLine("Fehler! Der Saal existiert nicht.");
                            goto kinoSaaleingabe;                                                           //Sollte die eingegebene Zahl nicht in dem Bereich liegen, so wird erneut nach einer Eingabe gefragt.
                        }else if (eingabeSaal < 1)                                                          //Es wird überprüft, ob die Eingabe in dem möglichen Bereich liegt(kleiner/gleich 5 und größer/gleich 1)
                        {
                            Console.WriteLine("Fehler! Der Saal existiert nicht!");                         //Ausgabe, dass der "angeforderte" Saal nicht existiert.
                            goto kinoSaaleingabe;                                                           //Sollte die eingegebene Zahl nicht in dem Bereich liegen, so wird erneut nach einer Eingabe gefragt.
                        }
                        else
                        {                                                                                   //Hier endet diese Eingabe. Je nach eingabe öffnet sich ein Fenster, zur Auswahl eines Sitzplatzes.
                            Console.WriteLine("Sie haben erfolgreich Sal {0} ausgewählt!",eingabeSaal);      //Ausgabe, dass die Eingabe erfolgreich war.
                            csvSaal = eingabeSaal;
                            Console.Clear();

                            switch (eingabeSaal)                                                            //Switch-Case zur Abfrage der Eingabe.
                            {
                                case 1:                                                                     //Sollte Saal 1 ausgewählt worden sein, wird
                                    seatControllerUI = new SeatControllerUI(sal1, eingabeUhrzeit);          //ein grafisches Fenster erstellt, in der Größe des oben festgelegten Arrays.
                                    
                                    break;
                                case 2:                                                                     //Sollte Saal 2 ausgewählt worden sein, wird
                                    seatControllerUI = new SeatControllerUI(sal2, eingabeUhrzeit);          //ein grafisches Fenster erstellt, in der Größe des oben festgelegten Arrays.
                                    
                                    break;
                                case 3:                                                                     //Sollte Saal 3 ausgewählt worden sein, wird
                                    seatControllerUI = new SeatControllerUI(sal3, eingabeUhrzeit);          //ein grafisches Fenster erstellt, in der Größe des oben festgelegten Arrays.
                                    
                                    break;
                                case 4:                                                                     //Sollte Saal 4 ausgewählt worden sein, wird
                                    seatControllerUI = new SeatControllerUI(sal4, eingabeUhrzeit);          //ein grafisches Fenster erstellt, in der Größe des oben festgelegten Arrays.
                                   
                                    break;
                                case 5:                                                                     //Sollte Saal 5 ausgewählt worden sein, wird
                                    seatControllerUI = new SeatControllerUI(sal5, eingabeUhrzeit);          //ein grafisches Fenster erstellt, in der Größe des oben festgelegten Arrays.
                                    
                                    break;
                                default:                                                                    //Dies wird ausgeführt, sollte die Ausgabe etwas anderem entsprechen, eigentlich irrelevant, allerdings scheint es nicht zu funktionieren wenn "default" weggelassen wird.
                                    seatControllerUI = new SeatControllerUI(sal1, "17:00");                 //ein grafisches Fenster erstellt, in der Größe des oben festgelegten Arrays.
                                    
                                    break;
                            }
                            Application.EnableVisualStyles();                                               //Benötigt zum verwenden von Windows-Forms-Schlüsselwörtern.
                            Application.Run(seatControllerUI);                                              //Verwenden der Klasse "seatControllerUI"
                            
                        }

                    }
                        
                    break;                                                      //Ende des ersten "cases".

                case 'S':                                                       //Sollte der eingegebene Wert "S" entsprechen, wird folgendes gemacht:
                    string dateiPfad = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "Kino Ticket.csv");
                    StreamReader sr = new StreamReader(dateiPfad);        //Erstellen eines "StreamReaders", benötigt um aus einer Textdatei zu lesen.
                    string fileOutput = sr.ReadToEnd();                         //es wird ein string erstellt, in welchem der alles aus der oben genannten Textdatei gespeichert wird.
                    MessageBox.Show(fileOutput);                                //Ausgeben des Strings. Verwenden von MessageBox. Dies öffnet ein Fenster welches die Nachricht anzeigt. 

            
                    break;                  

            }
            

        }//Main
    }//class Program
}//namespace
