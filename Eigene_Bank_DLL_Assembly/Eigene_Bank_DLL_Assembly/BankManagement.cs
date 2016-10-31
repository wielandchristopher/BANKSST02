using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Eigene_Bank_DLL_Assembly
{
    public class BankManagement : IBankManagement
    {
        string test = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "\\PathToCFG");
        // Schnittstellen Funktionen für Customer Management
        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr NeuerKunde(String _Vorname, String _Nachname, String _Geburtsdatum, String _adresse, String _Wohnort, String _Telefon);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr readUser(int id);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int searchUser(String vorname, String nachname, String geb);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundenvornamenänderung(IntPtr Kunde, String Vorname);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundennachnamenänderung(IntPtr Kunde, String _Nachname);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundenadressänderung(IntPtr Kunde, String _Adresse);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundenwohnortsänderung(IntPtr Kunde, String _Wohnort);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundentelefonänderung(IntPtr Kunde, String _Telefon);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundendatenabfrage(IntPtr Kunde);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundeentfernen(IntPtr Kunde);

        // Schnittstellen Funktionen für Account Management
        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NeuesKreditkonto(IntPtr Kunde);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void doEinzahlen(IntPtr zielkonto, String verwendungszweck, double betrag);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NeuesSparkonto(IntPtr Kunde);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Sparkontoentfernen(IntPtr Konto, IntPtr Verfüger);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kreditkontoentfernen(IntPtr Konto, IntPtr Verfüger);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void doSparen(IntPtr zielkonto, String verwendungszweck, double betrag);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void doAbheben(IntPtr zielkonto, double betrag);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NeueUeberweisung(IntPtr quellkonto, IntPtr zielkonto, double betrag, String verwendungszweck);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getKreditKontonummer(IntPtr konto);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getSparKontonummer(IntPtr konto);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr readSparKonto(int ktnr);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr readKreditKonto(int ktnr);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getKontonummer(IntPtr kunde, int whichKonto);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int addSparKontoverfüger(IntPtr sk, IntPtr cust);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int addKreditKontoverfüger(IntPtr kk, IntPtr cust);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void doUmrechnung(IntPtr waehrungsmmodul, String waehrung);
        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void doKursverwaltung(IntPtr waehrungsmodul);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NeuesWaehrungsmodul(IntPtr konto);

        /**********************************************************************************************************************************
         *  Interface Methoden bezüglich des Customers
         *  ============================================
         *  
         *  int createCustomer(String _Vorname, String _Nachname, String _Geburtsdatum, String _adresse, String _Wohnort, String _Telefon);
         *  void changeCustomer(int _id, String _Vorname, String _Nachname, String _adresse, String _Wohnort, String _Telefon)
         *  int getCustomer(String _firstName, String _lastName, String _birthDate);
         *  void deleteCustomer(int _id);
         *  
         * *********************************************************************************************************************************/

        public int createCustomer(String _Vorname, String _Nachname, String _Geburtsdatum, String _adresse, String _Wohnort, String _Telefon)
        {
            IntPtr neuerKunde = NeuerKunde(_Vorname, _Nachname,  _Geburtsdatum,  _adresse,  _Wohnort,  _Telefon);
            int id = searchUser(_Vorname, _Nachname, _Geburtsdatum);
            return id;
        }

        public void changeCustomer(int _id, String _Vorname, String _Nachname, String _adresse, String _Wohnort, String _Telefon)
        {
            IntPtr kunde = readUser(_id);
            Kundenvornamenänderung(kunde, _Vorname);
            Kundennachnamenänderung(kunde, _Nachname);
            Kundenadressänderung(kunde, _adresse);
            Kundenwohnortsänderung(kunde, _Wohnort);
            Kundentelefonänderung(kunde, _Telefon);
        }

        // returns -1 if Customer not found
        public int getCustomer(String _firstName, String _lastName, String _birthDate)
        {
            int id = searchUser(_firstName, _lastName, _birthDate);
            return id;
        }

        public void deleteCustomer(int _id)
        {
            IntPtr kunde = readUser(_id);
            Kundeentfernen(kunde);
        }

        /**********************************************************************************************************************************
        *  Interface Methoden bezüglich des Accounts
        *  ============================================
        *  
        *   int createSavingsAccount(int _id);
        *   int createCreditAccount(int _id);
        *   void deleteSavingsAccount(int _sNumber, int _id);
        *   void deleteCreditAccount(int _cNumber, int _id);
        *   void depositCreditAcc(int _cNumber, String _usage, double _amount);
        *   void depositSavingsAcc(int _sNumber, String _usage, double _amount);
        *   void withdrawCreditAcc(int _cNumber, double _amount);
        *   void transfer(int _cNumber, int _toAccNumber, String _usage, double _amount);
        *   void addSavingsAccountDisposer(int _sNumber, int _id);
        *   void addCreditAccountDisposer(int _cNumber, int _id);
        *   int getBankAccountNumber(int _id, int _whichAccount);
        *   void createBankStatement(int _accNumber);
        *   void convertMoney(int _cNumber, string _currency);
        *   void showChangeOfCourse(int _cNumber);
        *        
        * *********************************************************************************************************************************/

        // Methode returned Kontonummer
        public int createSavingsAccount(int _id)
        {
            IntPtr customer = readUser(_id);
            IntPtr savingsAccount = NeuesSparkonto(customer);
            int accountNumber = getSparKontonummer(savingsAccount);

            return accountNumber;
        }

        // Methode returned Kontonummer
        public int createCreditAccount(int _id)
        {
            IntPtr customer = readUser(_id);
            IntPtr creditAccount = NeuesKreditkonto(customer);
            int accountNumber = getKreditKontonummer(creditAccount);

            return accountNumber;
        }

        public void deleteSavingsAccount(int _sNumber, int _id)
        {
            IntPtr savingsAccount = readSparKonto(_sNumber);
            IntPtr customer = readUser(_id);
            Sparkontoentfernen(savingsAccount, customer);
        }

        public void deleteCreditAccount(int _cNumber, int _id)
        {
            IntPtr creditAccount = readKreditKonto(_cNumber);
            IntPtr customer = readUser(_id);
            Sparkontoentfernen(creditAccount, customer);
        }

        public void depositCreditAcc(int _cNumber, String _usage, double _amount)
        {
            IntPtr creditAcc = readKreditKonto(_cNumber);
            doEinzahlen(creditAcc, _usage, _amount);
        }

        public void depositSavingsAcc(int _sNumber, String _usage, double _amount)
        {
            IntPtr savingAcc = readSparKonto(_sNumber);
            doEinzahlen(savingAcc, _usage, _amount);
        }

        public void withdrawCreditAcc(int _cNumber, double _amount)
        {
            IntPtr creditAcc = readKreditKonto(_cNumber);
            doAbheben(creditAcc, _amount);
        }

        // Anschauen
        public void transfer(int _cNumber, int _toAccNumber, String _usage, double _amount)
        {
            IntPtr quellAcc = readKreditKonto(_cNumber);
            IntPtr zielAcc = readKreditKonto(_toAccNumber);
            
            if(string.Compare(zielAcc.ToString(), "0") == -1)
            {
                doAbheben(quellAcc, _amount);
                doEinzahlen(zielAcc, _usage, _amount);
            }
            else
            {
                Console.WriteLine("No transfer possible, because of inserting a savings account!");
            }
        }

        public void addSavingsAccountUser(int _sNumber, int _id)
        {
            IntPtr savingAcc = readSparKonto(_sNumber);
            IntPtr customer = readUser(_id);
            addSparKontoverfüger(savingAcc, customer);
        }

        public void addCreditAccountUser(int _cNumber, int _id)
        {
            IntPtr creditAcc = readKreditKonto(_cNumber);
            IntPtr customer = readUser(_id);
            addKreditKontoverfüger(creditAcc, customer);
        }

        public int getBankAccountNumber(int _id, int _whichAccount)
        {
            IntPtr customer = readUser(_id);
            int accNumber = getKontonummer(customer, _whichAccount);

            return accNumber;
        }

        public void createBankStatement(int _accNumber)
        {
            string fileName = _accNumber + "_Buchungen.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            Console.WriteLine("************************************************************************************");
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("************************************************************************************");
        }

        public void convertMoney(int _cNumber, string _currency)
        {
            IntPtr creditAcc = readKreditKonto(_cNumber);

            if(_currency == "USD" || _currency == "CHF" || _currency == "GBP" || _currency == "JPY")
            {
                IntPtr waehrungsmodul = NeuesWaehrungsmodul(creditAcc);
                doUmrechnung(waehrungsmodul, _currency);

                string fileName = _cNumber + "_Umrechnung.txt";
                string path = Path.Combine(Environment.CurrentDirectory, fileName);
                Console.WriteLine("************************************************************************************");
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        String line = sr.ReadToEnd();
                        Console.WriteLine(line);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read");
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("************************************************************************************");
            }
            else
            {
                Console.WriteLine("Wrong currency input!");
            }
        }

        public void showChangeOfCourse(int _cNumber)
        {
            IntPtr creditAcc = readKreditKonto(_cNumber);
            IntPtr waehrungsmodul = NeuesWaehrungsmodul(creditAcc);

            string fileName = _cNumber + "_Kursverwaltung.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            Console.WriteLine("************************************************************************************");
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("************************************************************************************");
        }
    }
}
