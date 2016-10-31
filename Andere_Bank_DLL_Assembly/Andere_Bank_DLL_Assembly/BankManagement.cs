using System;
using System.Runtime.InteropServices;

namespace Andere_Bank_DLL_Assembly
{
    class BankManagement : IBankManagement {

        //Implementierung aller benötigten DLL Funktionen 
        /**********************************************************************************************************************************************/

    /* Customer */
        [DllImport("C:\\Users\\wiela\\Documents\\GitHub\\BankSST02\\Andere_Bank_DLL_Assembly\\Andere_Bank_DLL_Assembly\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr xmlcontroler_createuser(String firstName, String lastname, String plzOrt, String strasse, String hausNr);

        [DllImport("C:\\Users\\wiela\\Documents\\GitHub\\BankSST02\\Andere_Bank_DLL_Assembly\\Andere_Bank_DLL_Assembly\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int xmlcontroler_updateCustomer(int cusID, String firstName, String lastname, String plzOrt, String strasse, int hausNr);

        [DllImport("C:\\Users\\wiela\\Documents\\GitHub\\BankSST02\\Andere_Bank_DLL_Assembly\\Andere_Bank_DLL_Assembly\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool xmlcontroler_deleteCustomerByUUID(String cusUUID);

        /* Account */
        [DllImport("C:\\Users\\wiela\\Documents\\GitHub\\BankSST02\\Andere_Bank_DLL_Assembly\\Andere_Bank_DLL_Assembly\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int xmlcontroler_createAccount(int tmpType, float tmpValue);

        [DllImport("C:\\Users\\wiela\\Documents\\GitHub\\BankSST02\\Andere_Bank_DLL_Assembly\\Andere_Bank_DLL_Assembly\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int xmlcontroler_closeAccount(int tmpAccID);

        [DllImport("C:\\Users\\wiela\\Documents\\GitHub\\BankSST02\\Andere_Bank_DLL_Assembly\\Andere_Bank_DLL_Assembly\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool xmlcontroler_attachAccount(int tmpAccID, int tmpCusID);

        [DllImport("C:\\Users\\wiela\\Documents\\GitHub\\BankSST02\\Andere_Bank_DLL_Assembly\\Andere_Bank_DLL_Assembly\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool xmlcontroler_dettachAccount(int tmpAccID, int tmpCusID);

        [DllImport("C:\\Users\\wiela\\Documents\\GitHub\\BankSST02\\Andere_Bank_DLL_Assembly\\Andere_Bank_DLL_Assembly\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool xmlcontroler_depositMoney(int tmpAccID, float tmpValue);

        [DllImport("C:\\Users\\wiela\\Documents\\GitHub\\BankSST02\\Andere_Bank_DLL_Assembly\\Andere_Bank_DLL_Assembly\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool xmlcontroler_withdrawMoney(int tmpAccID, float tmpValue);

        [DllImport("C:\\Users\\wiela\\Documents\\GitHub\\BankSST02\\Andere_Bank_DLL_Assembly\\Andere_Bank_DLL_Assembly\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool xmlcontroler_transferMoney(int tmpFromAccID, int tmpToAccID, float tmpValue);

        [DllImport("C:\\Users\\wiela\\Documents\\GitHub\\BankSST02\\Andere_Bank_DLL_Assembly\\Andere_Bank_DLL_Assembly\\XMLControler.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool xmlcontroler_getBankStatement(int tmpAccID);


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
        //noch nicht implementiert
        public void addSavingsAccountDisposer(int _sNumber, int _id)
        {
            xmlcontroler_attachAccount(_sNumber, _id);
        }
        //noch nicht implementiert
        public void addCreditAccountDisposer(int _cNumber, int _id)
        {
            xmlcontroler_attachAccount(_cNumber, _id);
        }
        //nicht implementiert von anderem Team
        public int getBankAccountNumber(int _id, int _whichAccount)
        {
            throw new NotImplementedException();
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
        //von anderem Team nicht implementiert
        public void convertMoney(int _cNumber, string _currency)
        {
            throw new NotImplementedException();
        }
        //von anderem Team nicht implementiert
        public void showChangeOfCourse(int _cNumber)
        {
            throw new NotImplementedException();
        }
    }
}
