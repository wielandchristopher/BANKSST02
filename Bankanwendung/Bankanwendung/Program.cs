using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Bankanwendung
{
    class Program
    {
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

        static void Main(string[] args)
        {
            Console.WriteLine("Hello TEAM");
            
            // IntPtr test = NeuerKunde("Martin","Nachname","01.05.1990","iwas","sbg","0667174852");
            IntPtr readuser = readUser(9);
            Kundenvornamenänderung(readuser, "TestName");
            IntPtr readuser2 = readUser(9);
            IntPtr konto = NeuesKreditkonto(readuser2);

            Console.WriteLine("2. Test");
        }

      
    }


}
