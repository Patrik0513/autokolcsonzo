/*
 * Created by SharpDevelop.
 * User: Tanulo
 * Date: 2021. 09. 21.
 * Time: 9:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Autokolcsonzo
{
	class Program
	{
		public static void Main(string[] args)
		{
			double egyenleg = 500000.0;
			double uzemanyagAr = 437.0; // Ft/liter

			KolcsonozhetoAuto[] flotta = new KolcsonozhetoAuto[10];
			KolcsonozhetoAuto elsoAuto = new KolcsonozhetoAuto("ABC-123", "Suzuki", 2020, 4, 40, 5.7, 'A');
			KolcsonozhetoAuto kettoAuto = new KolcsonozhetoAuto("BCD-234", "BMW", 2018, 2, 30, 3.7, 'A');
			KolcsonozhetoAuto haromAuto = new KolcsonozhetoAuto("CDE", "Toyota", 2021, 5, 36, 4.1, 'A');

			flotta[0] = elsoAuto;
			flotta[1] = kettoAuto;
			flotta[2] = haromAuto;

			flotta[3] = ramdomUjAuto(1);
			flotta[4] = ramdomUjAuto(2);

			for (int i = 0; i < 5; i++)
			{
				Console.Write(flotta[i].getRendszam() + ";");
                Console.Write(flotta[i].getGyarto());
                Console.Write(flotta[i].getGyartasEve()+ ";");
				Console.Write(flotta[i].getUtasSzam()+ ";");
				Console.Write(flotta[i].getuzemanyagMennyiseg()+ ";");
				Console.Write(flotta[i].getFogyasztas()+ ";");
				Console.Write(flotta[i].getMegtettKm()+ ";");
				Console.Write(flotta[i].getBerelheto()+";");
				Console.Write(flotta[i].getKategoria()+ ";");
			}
			flotta[5] = randomHasznaltAuto(3);
			flotta[6] = randomHasznaltAuto(4);

			Console.ReadKey();
		}

		public static KolcsonozhetoAuto ramdomUjAuto(int seed)
		{
			Random gen = new Random(seed);

			string[] gyartok = {
			"Maserati", "Jeep", "Ferrari", "Suzuki", "Volvo", "Lada"
			};

			char[] abc = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
			string abcS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			string rszam = "";

			for (int i = 0; i < 3; i++)
			{
				rszam += abcS[gen.Next(0, abcS.Length)];
			}

			rszam += "-";

			for (int i = 0; i < 3; i++)
			{
				rszam += gen.Next(0, 10).ToString();
			}

			string marka = gyartok[gen.Next(0, gyartok.Length)];
			int ev = gen.Next(1995, 2022);
			int utasok = gen.Next(2, 10);
			int tartaly = gen.Next(20, 71);
			double lpkm = 5.5 + (11 * gen.NextDouble());
			char kat = abc[gen.Next(0, 3)];

			KolcsonozhetoAuto auto = new KolcsonozhetoAuto();
			return auto;
		}


		public static KolcsonozhetoAuto randomHasznaltAuto(int seed)
        {
			KolcsonozhetoAuto auto = ramdomUjAuto(seed);

			if (auto.getGyartasEve()==2021)
            {
				auto.setGyartasiIdo(auto.getGyartasEve() - 4);
            }

			auto.setMegtettKm(362000);

			return auto;
        }

	}
}