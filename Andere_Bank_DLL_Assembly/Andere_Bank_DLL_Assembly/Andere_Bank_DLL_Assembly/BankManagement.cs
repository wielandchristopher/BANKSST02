using System;
using System.Runtime.InteropServices;

namespace Andere_Bank_DLL_Assembly
{
    class BankManagement : IBankManagement {

        //Implementierung aller benötigten DLL Funktionen 
        /**********************************************************************************************************************************************/

        /* Customer */
        [DllImport("C:\\Users\\christopher.wieland\\Documents\\GitHub\\BankSST02\\DLL andere Gruppe\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr xmlcontroler_createuser(String firstName, String lastname, String plzOrt, String strasse, String hausNr);

        [DllImport("C:\\Users\\christopher.wieland\\Documents\\GitHub\\BankSST02\\DLL andere Gruppe\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int xmlcontroler_updateCustomer(int cusID, String firstName, String lastname, String plzOrt, String strasse, int hausNr);

        [DllImport("C:\\Users\\christopher.wieland\\Documents\\GitHub\\BankSST02\\DLL andere Gruppe\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool xmlcontroler_deleteCustomerByUUID(String cusUUID);

        /* Account */
        [DllImport("C:\\Users\\christopher.wieland\\Documents\\GitHub\\BankSST02\\DLL andere Gruppe\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int xmlcontroler_createAccount(int tmpType, float tmpValue);

        [DllImport("C:\\Users\\christopher.wieland\\Documents\\GitHub\\BankSST02\\DLL andere Gruppe\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int xmlcontroler_closeAccount(int tmpAccID);

        [DllImport("C:\\Users\\christopher.wieland\\Documents\\GitHub\\BankSST02\\DLL andere Gruppe\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool xmlcontroler_attachAccount(int tmpAccID, int tmpCusID);


        /**********************************************************************************************************************************************/

        /******************************************/
        /*                                        */
        /*           Customermanagement           */
        /*                                        */
        /******************************************/

        //Erstellt einen Benutzer
        public int createCustomer(string _Vorname, string _Nachname, string _Geburtsdatum, string _adresse, string _Wohnort, string _Telefon) {

            //Übergebene Adresse wird aufgeteilt in Straße und Hausnummer
            string[] separators = { ",", ".", "!", "?", ";", ":", " " };
            string[] adr = _adresse.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string _strasse = adr[0];
            string _hausNr = adr[1];
            //wird auf null gesetzt, da die fremde DLL keine Telefonnummern und Geburtsdaten speichert
            _Telefon = null;
            _Geburtsdatum = null;

            xmlcontroler_createuser(_Vorname, _Nachname, _Wohnort, _strasse, _hausNr);
            return 0;
        }
        //Löscht Benutzer
        public void deleteCustomer(int _id)
        {
            String custID = _id.ToString();
            xmlcontroler_deleteCustomerByUUID(custID);
        }
        //Holt den Benutzer
        public int getCustomer(string _firstName, string _lastName, string _birthDate)
        {
            throw new NotImplementedException();
        }
        //Ändert Kundendaten
        public void changeCustomer(int _id, string _Vorname, string _Nachname, string _address, string _Wohnort, string _Telefon)
        {
            //Übergebene Adresse wird aufgeteilt in Straße und Hausnummer
            string[] separators = { ",", ".", "!", "?", ";", ":", " " };
            string[] adr = _address.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string _strasse = adr[0];
            string _hausNr = adr[1];
            int hausnummer = Int32.Parse(_hausNr);
            //wird auf null gesetzt, da die fremde DLL keine Telefonnummern speichert
            _Telefon = null;

            xmlcontroler_updateCustomer(_id, _Vorname, _Nachname, _Wohnort, _strasse, hausnummer);
        }

 
        /******************************************/
        /*                                        */
        /*           Accountmanagement            */
        /*                                        */
        /******************************************/

        public int createSavingsAccount(int _id)
        {
            int KontoID = 0;
            KontoID = xmlcontroler_createAccount(0, 0);
            xmlcontroler_attachAccount(KontoID, _id);
            return 0;
        }

        public int createCreditAccount(int _id)
        {
            int KontoID = 0;
            KontoID = xmlcontroler_createAccount(1, 0);
            xmlcontroler_attachAccount(KontoID, _id);
            return 0;
        }

        //passt nu vorne und hintn ned
        public void deleteSavingsAccount(int _sNumber, int _id)
        {
            int tmpAccID = 0;
            _sNumber = 0;
            _id = 0;
            xmlcontroler_closeAccount(tmpAccID);
        }
        //passt nu vorne und hintn ned
        public void deleteCreditAccount(int _cNumber, int _id)
        {
            int tmpAccID = 0;
            _cNumber = 0;
            _id = 0;
            xmlcontroler_closeAccount(tmpAccID);
        }

        public void depositCreditAcc(int _cNumber, string _usage, double _amount)
        {
            throw new NotImplementedException();
        }

        public void depositSavingsAcc(int _sNumber, string _usage, double _amount)
        {
            throw new NotImplementedException();
        }

        public void withdrawCreditAcc(int _cNumber, double _amount)
        {
            throw new NotImplementedException();
        }

        public void transfer(int _cNumber, int _toAccNumber, string _usage, double _amount)
        {
            throw new NotImplementedException();
        }

        public void addSavingsAccountDisposer(int _sNumber, int _id)
        {
            throw new NotImplementedException();
        }

        public void addCreditAccountDisposer(int _cNumber, int _id)
        {
            throw new NotImplementedException();
        }
    }
}
