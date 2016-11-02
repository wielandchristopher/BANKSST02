using System;
using System.Runtime.InteropServices;

namespace Andere_Bank_DLL_Assembly
{
    public class BankManagement : IBankManagement {

        //Implementierung aller benötigten DLL Funktionen 
        /**********************************************************************************************************************************************/

        const string path = "C:\\Users\\christopher.wieland\\Documents\\GitHub\\BankSST02\\DLL andere Gruppe\\XMLControler.dll";
        /* Customer */
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xmlcontroler_createCustomer(string firstName, string lastname, string plzOrt, string strasse, string hausNr);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xmlcontroler_updateCustomer(int cusID, string firstName, string lastname, string plzOrt, string strasse, int hausNr);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool xmlcontroler_deleteCustomerByUUID(string cusUUID);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xmlcontroler_getCusID(string _firstname, string _lastName);

        /* Account */
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xmlcontroler_createAccount(int tmpType, float tmpValue);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xmlcontroler_closeAccount(int tmpAccID);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool xmlcontroler_attachAccount(int tmpAccID, int tmpCusID);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool xmlcontroler_dettachAccount(int tmpAccID, int tmpCusID);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool xmlcontroler_depositMoney(int tmpAccID, float tmpValue);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool xmlcontroler_withdrawMoney(int tmpAccID, float tmpValue);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool xmlcontroler_transferMoney(int tmpFromAccID, int tmpToAccID, float tmpValue);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool xmlcontroler_getBankStatement(int tmpAccID);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool currencyExchange_exchange(double amount, int from, int to);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern bool xmlcontroler_getAccsByCusID(int tmpCusID, int* outParam);

        /**********************************************************************************************************************************************/

        /******************************************/
        /*                                        */
        /*           Customermanagement           */
        /*                                        */
        /******************************************/

        //Erstellt einen Benutzer
        public int createCustomer(string _Vorname, string _Nachname, string _Geburtsdatum, string _adresse, string _Wohnort, string _Telefon) {

            //wird auf null gesetzt, da die fremde DLL keine Telefonnummern und Geburtsdaten speichert
            _Telefon = " ";
            _Geburtsdatum = " ";
            string _hausNr = " ";

            xmlcontroler_createCustomer(_Vorname, _Nachname, _Wohnort, _adresse, _hausNr);
            return 0;
        }
        //Löscht Benutzer
        public void deleteCustomer(int _id)
        {
            string custID = _id.ToString();
            xmlcontroler_deleteCustomerByUUID(custID);
        }
        //Holt den Benutzer
        public int getCustomer(string _firstName, string _lastName, string _birthDate)
        {
            return xmlcontroler_getCusID(_firstName, _lastName);
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

        //Erzeugt SparKonto
        public int createSavingsAccount(int _id)
        {
            int KontoID = 0;
            KontoID = xmlcontroler_createAccount(0, 0);
            xmlcontroler_attachAccount(KontoID, _id);
            return 0;
        }
        //Erzeugt KreditKonto
        public int createCreditAccount(int _id)
        {
            int KontoID = 0;
            KontoID = xmlcontroler_createAccount(1, 0);
            xmlcontroler_attachAccount(KontoID, _id);
            return 0;
        }
        //Löscht SparKonto
        public void deleteSavingsAccount(int _sNumber, int _id)
        {
            xmlcontroler_dettachAccount(_sNumber, _id);
            xmlcontroler_closeAccount(_sNumber);

        }
        //Löscht KreditKonto
        public void deleteCreditAccount(int _cNumber, int _id)
        {
            xmlcontroler_dettachAccount(_cNumber, _id);
            xmlcontroler_closeAccount(_cNumber);
        }
        //mehrere Verfüger?
        public void depositCreditAcc(int _cNumber, string _usage, double _amount)
        {
            //Bei anderen nicht implementiert
            _usage = "";

            float tmpValue = (float)_amount;
            if (float.IsPositiveInfinity(tmpValue))
            {
                tmpValue = float.MaxValue;
            }
            else if (float.IsNegativeInfinity(tmpValue))
            {
                tmpValue = float.MinValue;
            }
            xmlcontroler_depositMoney(_cNumber, tmpValue);
        }
        //mehrere Verfüger?
        public void depositSavingsAcc(int _sNumber, string _usage, double _amount)
        {
            //Bei anderen nicht implementiert
            _usage = "";

            float tmpValue = (float)_amount;
            if (float.IsPositiveInfinity(tmpValue))
            {
                tmpValue = float.MaxValue;
            }
            else if (float.IsNegativeInfinity(tmpValue))
            {
                tmpValue = float.MinValue;
            }
            xmlcontroler_depositMoney(_sNumber, tmpValue);
        }
        //Abheben vom KreditKonto
        public void withdrawCreditAcc(int _cNumber, double _amount)
        {
            float tmpValue = (float)_amount;
            if (float.IsPositiveInfinity(tmpValue))
            {
                tmpValue = float.MaxValue;
            }
            else if (float.IsNegativeInfinity(tmpValue))
            {
                tmpValue = float.MinValue;
            }

            xmlcontroler_withdrawMoney(_cNumber, tmpValue);
        }
        //Überweisen
        public void transfer(int _cNumber, int _toAccNumber, string _usage, double _amount)
        {
            //Bei anderen nciht implementiert
            _usage = "";

            float tmpValue = (float)_amount;
            if (float.IsPositiveInfinity(tmpValue))
            {
                tmpValue = float.MaxValue;
            }
            else if (float.IsNegativeInfinity(tmpValue))
            {
                tmpValue = float.MinValue;
            }
            xmlcontroler_transferMoney(_cNumber, _toAccNumber, tmpValue);
        }
        //Fügt Verfüger hinzu
        public void addSavingsAccountUser(int _sNumber, int _id)
        {
            xmlcontroler_attachAccount(_sNumber, _id);
        }
        //Fügt Verfüger hinzu
        public void addCreditAccountUser(int _cNumber, int _id)
        {
            xmlcontroler_attachAccount(_cNumber, _id);
        }
        //Gibt Acc eines Verfügers zurück ???
        unsafe public int getBankAccountNumber(int _id, int _whichAccount)
        {

            int* outParam = (int*)_whichAccount;

            xmlcontroler_getAccsByCusID(_id, outParam);

            return 0;
        }

        /******************************************/
        /*                                        */
        /*             Währungsmodul              */
        /*                                        */
        /******************************************/

        //Bankstatement erstellen
        public void createBankStatement(int _accNumber)
        {
            xmlcontroler_getBankStatement(_accNumber);
        }
        //Konvertiert Währung in verschiedene Fremdwährung
        public void convertMoney(int Balance, string _currency)
        {
            int currency = 0;
            if(_currency == "USD")
            {
                currency = 1;
            }
            else if (_currency == "GBP")
            {
                currency = 2;
            }
            else if (_currency == "INR")
            {
                currency = 3;
            }
            else if (_currency == "JPY")
            {
                currency = 4;
            }
            currencyExchange_exchange(Balance, 0, currency);
        }
        //von anderem Team nicht implementiert
        public void showChangeOfCourse(int _cNumber)
        {
            throw new NotImplementedException();
        }
    }
}
