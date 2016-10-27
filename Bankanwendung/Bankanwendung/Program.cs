using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Eigene_Bank_DLL_Assembly;

namespace Bankanwendung
{
    class Program
    {
        // String str = "$(SolutionDir)\\..\\..\\..\\Bank\\Bank\\Debug\\Bank.dll";
     
/*
        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NeuerKunde(String _Vorname, String _Nachname, String _Geburtsdatum, String _adresse, String _Wohnort, String _Telefon);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundenvornamenänderung(IntPtr Kunde, String Vorname);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr readUser(int id);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NeuesKreditkonto(IntPtr Kunde);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void doEinzahlen(IntPtr zielkonto, String verwendungszweck, double betrag);
*/
        static void Main(string[] args)
        {
            Console.WriteLine("Hello TEAM");
            //string str = System.IO.Directory.get() + "..\\..\\..\\Bank\\Bank\\Debug\\Bank.dll";
            //    string str = System.AppDomain.CurrentDomain.BaseDirectory;

            // IntPtr test = NeuerKunde("Martin","Nachname","01.05.1990","iwas","sbg","0667174852");
            /* IntPtr readuser = readUser(9);
             Kundenvornamenänderung(readuser, "TestName");
             IntPtr readuser2 = readUser(9);
             IntPtr konto = NeuesKreditkonto(readuser2); */

            // Assembly Test
            /* IntPtr neuerKunde = CustomerManagement.NeuerKunde("TestVorname", "TestNachname", "01.05.1990", "Test Adresse", "Salzburg", "0667174852");
             IntPtr neuerKunde02 = CustomerManagement.readUser(17);
             IntPtr konto = AccountManagement.NeuesKreditkonto(neuerKunde02);

             IntPtr neuerKunde03 = CustomerManagement.readUser(17);
             AccountManagement.doEinzahlen(konto, "Testverwendungszweck assembly", 100); */

            // Assembly + Interface Test
            CustomerManagement cm1 = new CustomerManagement();
            //    int user1 = cm1.createCustomer("Roland", "Graf", "01.05.1950", "Am FHWeg 1", "Puch", "0667174852");
            //   int user2 = cm1.createCustomer("Person2", "Nachname", "01.05.1980", "Am hier 1", "Hallein", "0667178852");
            int user1 = 76;
            int user2 = 77;
            /*   cm1.changeFirstName(user1, "Christopher");
               cm1.changeLastName(user1, "Wieland");
               cm1.changeLocation(user1, "Salzburg");
               cm1.changeTelephonNr(user1, "0669878899");
               cm1.changeAddress(user1, "daheimweg 2"); */

            //   int kreditNummer = cm1.createCreditAccount(user1);
            //   int kreditnummer2 = cm1.createCreditAccount(user2);
            int kreditNummer = 10000036;
            int kreditnummer2 = 10000037;

         //   cm1.withdrawCreditAcc(kreditNummer, 100);
         //   cm1.depositCreditAcc(kreditNummer, "Testeinzahlung", 200);
            cm1.transfer(kreditNummer, kreditnummer2, "Testüberweisung", 50);

            Console.WriteLine("2. Test");
        }
    }

}
