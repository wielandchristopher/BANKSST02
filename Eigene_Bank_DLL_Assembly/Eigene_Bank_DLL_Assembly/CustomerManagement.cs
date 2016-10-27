using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Eigene_Bank_DLL_Assembly
{
    public class CustomerManagement : ICustomerManagement
    {
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
        public static extern int addSparKontoverfüger(IntPtr sk, IntPtr cust);

        [DllImport("C:\\Users\\Kaschi\\Documents\\GitHub\\BankSST01\\Bank\\Bank\\Debug\\Bank.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int addKreditKontoverfüger(IntPtr kk, IntPtr cust);


        /**********************************************************************************************************************************
         *  Interface Methoden bezüglich des Customers
         *  ============================================
         *  
         *  int createCustomer(String _Vorname, String _Nachname, String _Geburtsdatum, String _adresse, String _Wohnort, String _Telefon);
         *  void changeFirstName(int _id, String _firstName);
         *  void changeLastName(int _id, String _lastName);
         *  void changeAddress(int _id, String _address);
         *  void changeLocation(int _id, String _location);
         *  void changeTelephonNr(int _id, String _number);
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

        public void changeFirstName(int _id, string _firstName)
        {
            IntPtr kunde = readUser(_id);
            Kundenvornamenänderung(kunde, _firstName);
        }

        public void changeLastName(int _id, String _lastName)
        {
            IntPtr kunde = readUser(_id);
            Kundennachnamenänderung(kunde, _lastName);
        }

        public void changeAddress(int _id, String _address)
        {
            IntPtr kunde = readUser(_id);
            Kundenadressänderung(kunde, _address);
        }

        public void changeLocation(int _id, String _location)
        {
            IntPtr kunde = readUser(_id);
            Kundenwohnortsänderung(kunde, _location);
        }

        public void changeTelephonNr(int _id, String _number)
        {
            IntPtr kunde = readUser(_id);
            Kundentelefonänderung(kunde, _number);
        }

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
            IntPtr ueberweisung = NeueUeberweisung(quellAcc, zielAcc, _amount, _usage);
        }

        public void addSavingsAccountDisposer(int _sNumber, int _id)
        {
            IntPtr savingAcc = readSparKonto(_sNumber);
            IntPtr customer = readUser(_id);
            addSparKontoverfüger(savingAcc, customer);
        }

        public void addCreditAccountDisposer(int _cNumber, int _id)
        {
            IntPtr creditAcc = readKreditKonto(_cNumber);
            IntPtr customer = readUser(_id);
            addKreditKontoverfüger(creditAcc, customer);
        }
    }
}
