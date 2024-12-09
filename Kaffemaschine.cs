using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschine
{
	internal class Kaffeemaschine
	{
		// Deklaration der Felder die für unsere Kaffemaschinen-Objekte gebraucht werden
		//Da kein Zugriffsmodifikator savor steht gelten die felder als privat.
		//Was im Zuge der Datenkapselung auch so sein sollte.
		int wasserstand; 
		int bohnenmenge;
		

		//Die folgenden Felder sind statische Felder. Das bedeutetsie sind für alle Objekte dieser Klasse gleich.
		//Kein Objekt hat dafür einen individuellen Wert.
		static int maxWasserstand = 100;
		static int maxBohnenmenge = 100;

		//Die Eigenschaften unserer Klasse
		//Diese haben wir aus unseren Feldern erstellt.
		public int Wasserstand { get => wasserstand; set => wasserstand = value; }
		public int Bohnenmenge { get => bohnenmenge; set => bohnenmenge = value; }
		public static int MaxWasserstand { get => maxWasserstand; }
		public static int MaxBohnenmenge { get => maxBohnenmenge; }

		public Kaffeemaschine(int wasserstand, int bohnenmenge)
		{
			this.wasserstand = wasserstand;
			this.bohnenmenge = bohnenmenge;
		}

		//Zwei Methoden die jeweils Wasser bzw Bohnen auf das Maximum auffüllen.

		public void WasserAuffuellen()
		{
			int auffuelmenge = maxWasserstand - wasserstand;
			wasserstand = maxWasserstand;
            Console.WriteLine($"Ihr neuer Wasserstand ist {wasserstand} Einheiten. \nEs wurden dafür {auffuelmenge} Einheiten Wasser gebraucht.");
			Console.ReadKey();
		}

		public void BohnenAuffuellen()
		{
			int auffuelmenge = maxBohnenmenge - bohnenmenge;
			bohnenmenge = maxBohnenmenge;
			Console.WriteLine($"Ihre neuee Bohnenmenge ist {bohnenmenge} Einheiten. \nEs wurden dafür {auffuelmenge} Einheiten Bohnen gebraucht.");
			Console.ReadKey();
		}

		private bool Wasserstandspruefung()
		{
			if (wasserstand >= 20) return true;
			else return false;
		}

		private bool Bohnenmengenpruefung()
		{
			if (bohnenmenge >= 2) return true;
			else return false;
		}

		//Es folgt die Methode um einen Kaffee zu machen 

		public void KafeeZapfen()
		{
			if (Wasserstandspruefung() && Bohnenmengenpruefung())
			{
				wasserstand -= 20;
				bohnenmenge -= 2;
				Console.WriteLine("Hier bitte Ihr Kaffee");
			}
			else if (!Wasserstandspruefung() && Bohnenmengenpruefung()) Console.WriteLine("Bitte Wasser auffüllen.");
			else if (!Bohnenmengenpruefung() && Wasserstandspruefung()) Console.WriteLine("Bitte Bohnen auffüllen");
			else Console.WriteLine("Bitte Wasser und bohnen auffüllen");
			Console.ReadKey();
		}

		public void KaffeeMenu()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine($"Senseo Kaffeemaschine 1.0\n\nWasserstand: {wasserstand} Einheiten\tBohnenmenge: {bohnenmenge} Einheiten\n\n");
                Console.WriteLine("Bitte machen Sie eine Eingabe:\n\t1 - Kaffee machen\n\t2 - Wasser auffüllen\n\t3 - Bohnen auffüllen");
				Console.Write("Eingabe: ");
				string eingabe = Console.ReadLine();

				if (eingabe == "1") KafeeZapfen();
				else if (eingabe == "2") WasserAuffuellen();
				else if (eingabe == "3") BohnenAuffuellen();
				else
				{
					Console.WriteLine("Falsche eingabe");
					Console.ReadKey();

				}
			}

		}
	}
}
