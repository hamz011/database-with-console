using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Database_withConsoel
{
    class Program
    {

        static void Main(string[] args)
        {
            int choose; int aaa = 0;bool answer =false;
            Database database = new Database();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Console uygulaması ile veritabanı işlemelerine hoş geldiniz!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Veritabanı Bilgileri\nVeritabanı adı: " + database.dbName);
            do
            {
                /*
                 * 
                 * 
                        
                database.test();
                Console.WriteLine("Tablo son hali!");

                                                                
                 
                 */
                Console.WriteLine("Yapmak istediğin işlem nedir?\nKayıtları Listeleme --> 1\nYeni kayıt ekleme --> 2\nKayıt silme --> 3\nKayıt güncelleme --> 4\n");
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Lütfen bekleyiniz ....");
                        database.test(); Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Yeni işlem yapmak istiyor musunuz? e/h ");
                        Console.ForegroundColor = ConsoleColor.White;
                        if (Console.Read().ToString().ToLower() == "e")
                            answer = true;
                        else answer = false; break;
                    case 2:
                        string nameA = "", surnameA = ""; int idA = aaa;
                        database.test();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Yukarıda bulunmayan ID li kayıt ekleyin!Lütfen!!"); Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Yeni kayıt ID'si: ");
                        string idajhdg = Console.Read().ToString();
                        if (idajhdg.Length > 0 && idajhdg != string.Empty)
                        {
                            idA = int.Parse(idajhdg);
                        }
                        else { idA = aaa; aaa++; }
                        Console.Write("Yeni kayıt Adı: ");
                        string hgaıjlhgh = Console.Read().ToString();
                        if (hgaıjlhgh.Length > 0 && hgaıjlhgh != string.Empty)
                            nameA = hgaıjlhgh;
                        else
                        {
                            Console.WriteLine("Hatalı giriş!");
                            nameA = "errorHAHAHA";
                        }
                        Console.Write("Yeni kayıt Soyadı: ");
                        string hgaıjlhg= Console.Read().ToString();
                        if (hgaıjlhg.Length > 0 && hgaıjlhg != string.Empty)
                            surnameA = hgaıjlhg;
                        else
                        {
                            Console.WriteLine("Hatalı giriş!");
                            surnameA = "surErrorHAHAHHAHAH";
                        }
                        database.Add(idA, nameA, surnameA);

                        database.test();
                        Console.WriteLine("Tablo son hali!");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Yeni işlem yapmak istiyor musunuz? e/h" );
                        Console.ForegroundColor = ConsoleColor.White;
                        if (Console.ReadLine().ToLower() == "e")
                            answer = true;
                        else answer = false;

                        break;

                    case 3:
                        database.test();
                        int idD = 0;
                        Console.WriteLine("Silinecek kaydın ID'sini giriniz: ");
                        if (Console.ReadLine().Length > 0 && Console.ReadLine() != string.Empty)
                        {
                            idD = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Hatalı giriş!");
                            idD = aaa;
                        }
                        database.Delete(idD);
                        database.test();
                        Console.WriteLine("Tablo son hali!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Yeni işlem yapmak istiyor musunuz? e/h" );
                        Console.ForegroundColor = ConsoleColor.White;
                        if (Console.Read().ToString().ToLower() == "e")
                            answer = true;
                        else answer = false; break;
                    case 4:
                        database.test();
                        string nameU = "", surnameU = ""; int idU = aaa;
                        Console.Write("Güncellenecek kaydın ID'si: ");
                        string idd= Console.Read().ToString();
                        if (idd.Length > 0 && idd != string.Empty)
                        {
                            idU = int.Parse(idd);
                        }
                        else { idA = aaa; aaa++; }
                        Console.Write("Kayıtın yeni Adı: ");
                        string add = Console.Read().ToString();
                        if (add.Length > 0 && add != string.Empty)
                            nameU = add;
                        else
                        {
                            Console.WriteLine("Hatalı giriş!");
                            nameU = "errorHAHAHA";
                        }
                        Console.Write("Kayıtın yeni Soyadı: ");
                        string soy = Console.Read().ToString();
                        if (soy.Length > 0 && soy!= string.Empty)
                            surnameU = soy;
                        else
                        {
                            Console.WriteLine("Hatalı giriş!");
                            surnameU = "surErrorHAHAHHAHAH";
                        }
                        database.Update(idU, nameU, surnameU);
                        database.test();
                        Console.WriteLine("Tablo son hali!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Yeni işlem yapmak istiyor musunuz? e/h ");
                        Console.ForegroundColor = ConsoleColor.White;
                        if (Console.Read().ToString().ToLower() == "e")
                            answer = true;
                        else answer = false;
                        break;
                    default:
                        database.test();
                        Console.WriteLine("Tablo son hali!");
                        Console.WriteLine("Hatalı giriş!");
                        break;
                }
                Console.WriteLine("Bir şeye bas!");
                Console.ReadLine();

            }
            while (answer);
        }

    }
}
