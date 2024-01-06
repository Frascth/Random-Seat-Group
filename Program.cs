using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace RandomSeat
{
    class Program
    {
        //Casual
        static List<string> BaseNameList = new List<string>();
        static List<int> RandomNumber = new List<int>();
        static int[] KelBeruntung;
        static int JumlahKelompok, JumlahSTKelompok, SiswaSisa;
        static byte Option = 0;
        static string MataKuliah;


        //File
        static string FilePathSeat = "Acakan Bangku/";
        static string FilePathGroup = "Acakan Kelompok/";
        static string IsSave, FileName;


		static void Main ()
		{
            Console.Clear();
            Color(true);

            NameReader();

			Console.WriteLine ("<1> Acak Bangku");
			Console.WriteLine ("<2> Acak Kelompok");
			Console.Write ("Pilih dengan ketikan angka saja : ");
			Option = System.Convert.ToByte (Console.ReadLine());
			Console.Clear ();

            if (Option == 1)
            {
                AcakBangku();
            }
            else if (Option == 2)
            {
                AcakKelompok();
            }
		}
        static void Color(bool IsGreen)
        {
            if (IsGreen)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
		static void NameReader()
		{
            StreamReader sr = new StreamReader("NameList.txt");
            string reader;

            while ((reader = sr.ReadLine()) != null)
            {
                BaseNameList.Add(reader);
            }
            
            //foreach(string s in BaseNameList)
            //{
            //    Console.WriteLine(s);
            //}
            //Console.WriteLine(BaseNameList.Count());
		}
        static void Randoming()
        {
            Random rnd = new Random ();
		    RandomNumber = Enumerable.Range (0, BaseNameList.Count()).OrderBy (x => rnd.Next ()).ToList<int> ();

            //foreach(int i in RandomNumber)
            //{
            //    Console.WriteLine(i);
            //}
        }
        static void SaveFile(bool IsKelompok)
        {
            Console.ReadLine ();
			Console.Clear ();

			Console.Write ("Simpan data ? <y/n> : ");
			IsSave = Console.ReadLine ();
			Console.Clear ();

            if (IsKelompok && (IsSave == "y" || IsSave == "Y"))
            {
                Console.WriteLine ("Tuliskan nama file : ");
			    FileName = Console.ReadLine ();
			    StreamWriter sw = new StreamWriter (FilePathGroup + FileName + ".txt");

                if (BaseNameList.Count() % JumlahKelompok == 0)
                {
                    int Urutan = 0;
                    for (int i = 0; i < JumlahKelompok; i++) 
			        {
			        	sw.WriteLine ("Anggota Kelompok " + (i + 1));
			        	for (int j = 0; j < JumlahSTKelompok; j++) 
			        	{
			        		sw.WriteLine ((j + 1) + ". " + BaseNameList[RandomNumber[Urutan]]);
                            Urutan++;
			        	}
			        	sw.WriteLine ();
			        }
			        sw.Close ();
                }
                else if (BaseNameList.Count() % JumlahKelompok != 0)
                {
                    int Urutan = 0;
				    for (int i = 0; i < JumlahKelompok; i++) 
				    {
				    	sw.WriteLine ("Anggota kelompok {0}", i + 1);
				    	for (int j = 0; j < JumlahSTKelompok; j++) 
				    	{
				    		sw.WriteLine ((j + 1) + ". " + BaseNameList[RandomNumber[Urutan]]);
				    		Urutan++;
				    	}
				    	sw.WriteLine ();
				    }

				    for (int i = 0; i < SiswaSisa; i++)
				    {
				    	sw.WriteLine ("Tambahan anggota kelompok {0} adalah {1}", KelBeruntung[i], BaseNameList[RandomNumber[Urutan]]);
				    	Urutan++;
				    }
                    sw.Close();
                }
            }
            else if (!IsKelompok && (IsSave == "y" || IsSave == "Y"))
            {
                Console.WriteLine ("Tuliskan nama file : ");
			    FileName = Console.ReadLine ();
			    StreamWriter sw = new StreamWriter (FilePathSeat + FileName + ".txt");

                for (int i = 0; i < BaseNameList.Count(); i++)
                {
                    sw.WriteLine("No.{0} {1} ", (i + 1), BaseNameList[RandomNumber[i]]);
                    if (i % 2 != 0)
                    {
                        sw.WriteLine();
                    }
                }
                sw.Close();
            }

            Color(false);

        }
        static void AcakBangku()
        {
            Console.WriteLine ("Pengacak Bangku");
            Console.Write("Jumlah siswa : {0} orang", BaseNameList.Count());
            Console.ReadLine();
			Console.Clear ();
			Console.Write ("Acak sekarang !");
			Console.ReadLine ();
			Console.Clear ();

            Randoming();

            for (int i = 0; i < BaseNameList.Count(); i++)
            {
                Console.WriteLine("No.{0} {1} ", (i + 1), BaseNameList[RandomNumber[i]]);
                if (i % 2 != 0 && i != BaseNameList.Count())
                {
                    Console.WriteLine();
                }
            }

            SaveFile(false);
        }
        static void AcakKelompok()
        {
            Console.WriteLine ("Pengacak Kelompok");
			Console.Write ("Kelompok Mata Kuliah : ");
			MataKuliah = Console.ReadLine ();
			Console.WriteLine ();
			Console.Write ("Jumlah siswa : {0}", BaseNameList.Count());
			Console.WriteLine ();
			Console.Write ("Jumlah kelompok yang akan dibentuk : ");
			JumlahKelompok = System.Convert.ToInt16 (Console.ReadLine());
			Console.Clear ();
            
            if (BaseNameList.Count() % JumlahKelompok == 0)
            {
                JumlahSTKelompok = BaseNameList.Count() / JumlahKelompok;
                Randoming();

                Console.WriteLine ("Jumlah siswa : {0} orang", BaseNameList.Count());
				Console.WriteLine ("Jumlah Kelompok : {0} orang", JumlahKelompok);
				Console.Write ("Anggota tiap kelompok : {0} orang", JumlahSTKelompok);
				Console.ReadLine ();
                Console.WriteLine();
				Console.WriteLine ("Daftar anggota kelompok mata kuliah {0}", MataKuliah);
				Console.WriteLine ();

                int Urutan = 0;
                for (int i = 0; i < JumlahKelompok; i++) 
				{
					Console.WriteLine ("Anggota Kelompok " + (i + 1));
					for (int j = 0; j < JumlahSTKelompok; j++) 
					{
						Console.WriteLine ((j + 1) + ". " + BaseNameList[RandomNumber[Urutan]]);
                        Urutan++;
					}
					Console.WriteLine ();
				}

                SaveFile(true);

            }
            else if (BaseNameList.Count() % JumlahKelompok != 0)
            {
                SiswaSisa = BaseNameList.Count() % JumlahKelompok;
				JumlahSTKelompok = BaseNameList.Count() / JumlahKelompok;
				KelBeruntung = new int[SiswaSisa];
				Random rnd = new Random ();
				KelBeruntung = Enumerable.Range (1, JumlahKelompok).OrderBy (x => rnd.Next ()).ToArray ();

                Randoming();

                Console.WriteLine ("Jumlah siswa : {0} orang", BaseNameList.Count());
				Console.WriteLine ("Jumlah Kelompok : {0} orang", JumlahKelompok);
				Console.WriteLine ("Anggota tiap kelompok : {0} orang", JumlahSTKelompok);
				Console.WriteLine ();
				Console.WriteLine ("Ada {0} kelompok yang mendapat tambahan anggota yaitu :", SiswaSisa);

                for (int i = 0; i < SiswaSisa; i++)
				{
					Console.WriteLine ("Kelompok {0}", KelBeruntung[i]);
				}
				Console.ReadLine ();

				int Urutan = 0;
				for (int i = 0; i < JumlahKelompok; i++) 
				{
					Console.WriteLine ("Anggota kelompok {0}", i + 1);
					for (int j = 0; j < JumlahSTKelompok; j++) 
					{
						Console.WriteLine ((j + 1) + ". " + BaseNameList[RandomNumber[Urutan]]);
						Urutan++;
					}
					Console.WriteLine ();
				}

				for (int i = 0; i < SiswaSisa; i++)
				{
					Console.WriteLine ("Tambahan anggota kelompok {0} adalah {1}", KelBeruntung[i], BaseNameList[RandomNumber[Urutan]]);
					Urutan++;
				}

                SaveFile(true);
            }
        }
    }
}