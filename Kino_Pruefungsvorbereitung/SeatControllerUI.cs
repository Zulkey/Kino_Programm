using CinemaSeatController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace Kino_Pruefungsvorbereitung
{
    public partial class SeatControllerUI : Form
    {
        private int[] angaben;              // Private bedeutet das man von dieser Klasse auf die Variable zugreifen kann, würde man jetzt noch einen "getter" dafür schreiben (public int[] getAngaben(){ return [this.]angaben }) könnte man diese auch in anderen klassen benutzten solange man die instance dieser klasse hat. Man könnte das ganze auch einfach ohne "private" machen, wir wollen aber hier doch die richtigen conventions verwenden.
        private String uhrzeit;             // ^
        


        private int price = 0;


        private IList<Sitzplatz> sitzplaetze;                   //Sitzplätze in "Liste" statt Array weil es für mich persönlich, einfacher war das Ziel zu erreichen.
  

        public SeatControllerUI(int[] angaben, String uhrzeit) //Inhalt des Fensters. (Sitze, Preis etc)

        {

            //Initialisierung, Deklaration und Instanzbildung
            sitzplaetze = new List<Sitzplatz>();                // init der liste

            int seats = angaben[0] * angaben[1];                // berechnung der gesamten sitze
            int seatsPerRow = angaben[1];                       // wie viele sitze in einer Reihe sind, bekommt Wert aus "Saal"etc Variable aus "program.cs" class
            int currentRow = 1;                                 // momentane reihe 
            price = 0;                                      
            int currentSeatsInRow = 0;                          // momentane sitze in momentaniger reihe 

            for (int i = 1; i <= seats; i++)                    //for schleide fürs erstellen der Sitze
            {

                bool premium = false;                           //Bool hat nur "true und false" als Wert. In diesem Fall hat "premium" standartmäßig den Wert "false"                     

                if (currentSeatsInRow == seatsPerRow)           //Wenn "CurrentSeatsInRow" dem Wert von "seatsPerRow" entspricht wird:
                {
                    currentRow++;                               //"eine Reihe weiter gegangen"
                    currentSeatsInRow = 0;                      //und der Wert für "currentSeatsInRow" wird auf 0 gesetzt, fängt also von neu an.
                }

                if (currentRow <= 5)                            //Falls der Wert von "currenRow" unter 5 ist, also die Reihe, die momentan erstellt wird geringer oder gleich 5 ist, wird:
                {
                    premium = true;                             //das Feld als "premium" markiert, sprich, es wird später als "günstiger" angepriesen und in einer anderen Farbe dargestellt.
                }
                Sitzplatz seat = new Sitzplatz(premium, currentRow,i);             
                sitzplaetze.Add(seat);
                //Console.WriteLine("New Seat created! Premium: " + premium + ", Row: " + seat.getReihe() + ", Number: " + i);      //Nachricht, welche ausgibt, das ein Sitz erstellt wurde.
                currentSeatsInRow++;
            }

            this.uhrzeit = uhrzeit;                             //verwenden der privaten Variable "uhrzeit"
            this.angaben = angaben;                             //verwenden der privaten Variable, sogar Arrays, "angaben"
            InitializeComponent();                              //Wird automatisch von "windows forms" erstellt.

            this.FormBorderStyle = FormBorderStyle.FixedSingle; //Fixieren der Größe des grafischen Fensters.
            this.MaximizeBox = false;                           //^, "MaximizeBox" entscheidet ob das ein Vollbild-Fenster ist.
            resizeForm();                                       //wird später verwendet um die Größe des Fensters festzulegen.
            addSitzplaetze();                                   //Hier wird später die Position der Sitzplätze festgelegt
            setPriceLocation();                                 //Position des Gesamtpreises
            setPrintLocation();                                 //Position des Knopfes welcher alles in die Textddatei schreibt.
        }

        public void resizeForm()                                //Hier drin wird die Größe des Fensters bestimmt.
        {
            int[] size = new int[2];                            //Array für die Größe des Fensters, 
            size = calculateFormSize();                         //Das Array "size" bekommt die selben Werte zugewiesen wie das Array "calculateFormSize".
            this.Width = size[0];                               //Die Breite des Fensters bekommt den Wert des Arrays an Stelle "0", dies entspricht dem ersten Wert des Arrays.
            this.Height = size[1];                              //Die Höhe des Fensters bekommt den Wert des Arrays an Stelle "1", dies entspricht dem zweiten Wert des Arrays.
            this.Update();                                      //Update/Erneuern des ganzen.
        }

        public void setPrintLocation()                          //
        {
            int x = this.Width;
            int y = this.Height;
            y -= 100;
            x -= 125;

            printButton.Location = new Point(x, y);

            printButton.Click += new EventHandler(printButtonClickEvent);
            
        }

        protected void printButtonClickEvent(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"D:\test1.txt");


            

            // Man könnte den folgenden Part auch ohne Arrays machen, wird aber aus Lernzwecken mit Arrays gemacht.

            int b = 0;
            for(int i = 0; i < sitzplaetze.Count(); i++) {

                Sitzplatz sitzplatz = sitzplaetze.ElementAt(i);

                if (!sitzplatz.istVerfuegbar())
                    b++;       
            }

            if(b == 0)
            {
                MessageBox.Show("Du hast keine Plätze ausgewählt!"); // "Errormessage" wenn keine Sitzplätze ausgewählt wurden
                return;
            }

            Sitzplatz[] sitzplatzArray = new Sitzplatz[b];

            b = 0;
            for(int i = 0; i< sitzplaetze.Count(); i++)
            {
                Sitzplatz sitzplatz = sitzplaetze.ElementAt(i);
                if (!sitzplatz.istVerfuegbar())
                {

                    sitzplatzArray[b] = sitzplatz;
                    b++;
                }
            }


            // Hier wird ein StringBuilder benutzt um die Plätze in einem String aufzulisten.

            StringBuilder stringBuilder = new StringBuilder();


            bool c = false;

            foreach(Sitzplatz sitzplatz in sitzplatzArray)
            {
                if(c == false) {
                stringBuilder.Append(sitzplatz.getNumber());
                c = true;
                }
                else
                {
                    stringBuilder.Append(",").Append(" " + sitzplatz.getNumber());
                }
            }

            Program.csvPlatz = stringBuilder.ToString();

            string output=("Uhrzeit: "+ Program.csvUhrzeit);
            string output1 = ("Saal: " + Program.csvSaal);
            string output2 = ("Plätze: " + Program.csvPlatz);
            string output3 = ("Kosten: " + price + " Euro.");
            sw.WriteLine("Reservierung!");
            sw.WriteLine(output);
            sw.WriteLine("{0}.         {1}.",output1,output2);
            sw.WriteLine(output3);
            sw.Close();


        }

        public void setPriceLocation()
        {
            int x = this.Width;
            int y = this.Height;
            y -= 100;
            x -= (this.Width - 70);

          
            premiumPriceLabel.Text = "Premium Preis: " + Sitzplatz.normalPrice + "€";
            priceLabel.Text = "Preis: " + Sitzplatz.premiumPrice + "€";

            costLabel.Size =new Size(100,40);
            costLabel.Location = new Point(x, y);
            costLabel.Name = "Preis";
            costLabel.Font = new Font("Calibri", 20, FontStyle.Underline);
            costLabel.Text = "Gesamtpreis: 0 €";
            costLabel.Update();
            this.Update();
        }

        public void changePriceLabel()
        { 
            costLabel.Text = "Gesamtpreis: " + price + " €";
            costLabel.Update();
            this.Update();
        }

        public void addSitzplaetze()
        {


            int x = 20;             //"Startposition" der Knöpfe/Buttons, veränderbar
            int y = 50;             //^


            int buttonsInRow = 0;   // Wie viele Knöpfe momentan in der momentanen Reihe sind



            for (int i = 0; i < sitzplaetze.Count; i++)
            {
                Sitzplatz sitzplatz = sitzplaetze.ElementAt(i);


                int number = i + 1;


                Button button = new Button();   // erstellen des "Knopfes"
                button.Width = 35;              // Größes des Knopfes
                button.Height = 35;             // ^
                this.Controls.Add(button);      // Knopf zur Form hinzufügen
                button.Text = number + "";      // Text des Buttons ändern.
                button.Location = new Point(x, y); // Button auf die richtige Position in der Form setzten.

                button.Click += new EventHandler(seatButtonClickEvent); // Event hinzufügen das beim Klicken auf dem Button ausgeführt wird.
                button.BackColor = sitzplatz.istVerfuegbar() ? (sitzplatz.istPremium() ? Color.DarkGreen : Color.Green) : Color.Red; // Button farbe
                button.Show(); // anzeigen des buttons

                buttonsInRow++; 


                if (angaben[1] / 2 == buttonsInRow)
                {
                    x += 95;
                }
                else if (angaben[1] == buttonsInRow)
                {
                    x = 20;
                    y += 45;
                    buttonsInRow = 0;
                }
                else
                {
                    x += 45;
                }
            }
            Console.WriteLine("Added seats!");
            this.Update();
        }

        protected void seatButtonClickEvent(object sender, EventArgs e)
        {
            //Instanzbildung
            int[] sitzNummer = new int[sitzplaetze.Count];

            Button button = sender as Button;
            
            Console.WriteLine("Button clicked -> " + button.Text);

            Sitzplatz seat = sitzplaetze.ElementAt((int.Parse(button.Text) - 1));
           
       
            
                
            
           
            seat.setVerfuegbar(!seat.istVerfuegbar());
            button.BackColor = seat.istVerfuegbar() ? (seat.istPremium() ? Color.DarkGreen : Color.Green) : Color.DimGray; // IF else in einer Zeile. man könnte auch if(abfrage){ dann }else{sonst} benutzten


            if (!seat.istVerfuegbar()) // Ausrufezeichen ist if(boolean == false) ohne Ausrufenzeichen wäre es if(boolean == true)
            { 

                price += seat.istPremium() ? Sitzplatz.premiumPrice : Sitzplatz.normalPrice; // IF else in einer Zeile. man könnte auch if(abfrage){ dann }else{sonst} benutzten - Wenn der Sitz kein "Premiumsitzt" ist wird der normale Preis gezahlt, wenn doch wird der Premium Preis bezahlt

            }
            else
            {
                price -= seat.istPremium() ? Sitzplatz.premiumPrice : Sitzplatz.normalPrice; // IF else in einer Zeile. man könnte auch if(abfrage){ dann }else{sonst} benutzten
            }

            if(price < 0)
            {
             //   price = 0;
            }
            changePriceLabel();

            // set price

            this.Update();

        }

        private int[] calculateFormSize()
        {
            int[] size = new int[2];


            int seatWidt = 35; //   seat widt
            int seatGap = 10;  // seat gap
            int seatHeight = 35; // seat height



            // Form size
            // we´re starting with the widt

            int corridorWidt = 50; // size of the corridor widt between the seats


            int widt = 40 /* size @ edges */ + (seatWidt * angaben[1]) + (seatGap * angaben[1]) + corridorWidt + 20;
            int height = 100 /* size @ edges */ + (seatHeight * angaben[0]) + (seatGap * angaben[0]) + 90;

            Console.WriteLine("widt: " + widt);
            Console.WriteLine("height: " + height);

            size[0] = widt;
            size[1] = height;
            return size;
        }

    }
}
