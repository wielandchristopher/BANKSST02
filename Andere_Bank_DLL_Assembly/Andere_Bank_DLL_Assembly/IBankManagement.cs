using System;

namespace Andere_Bank_DLL_Assembly
{
    interface IBankManagement
    {
        // Interface Methoden des Customer Managements
        int createCustomer(string _Vorname, string _Nachname, string _Geburtsdatum, string _adresse, string _Wohnort, string _Telefon);
        void changeCustomer(int _id, string _Vorname, string _Nachname, string _address, string _Wohnort, string _Telefon);
        int getCustomer(string _firstName, string _lastName, string _birthDate);        
        void deleteCustomer(int _id);

        // Interface Methoden des Account Managements
        int createSavingsAccount(int _id);
        int createCreditAccount(int _id);
        void deleteSavingsAccount(int _sNumber, int _id);
        void deleteCreditAccount(int _cNumber, int _id);
        void depositCreditAcc(int _cNumber, string _usage, double _amount);
        void depositSavingsAcc(int _sNumber, string _usage, double _amount);
        void withdrawCreditAcc(int _cNumber, double _amount);
        void transfer(int _cNumber, int _toAccNumber, string _usage, double _amount);
        void addSavingsAccountUser(int _sNumber, int _id);
        void addCreditAccountUser(int _cNumber, int _id);
        int getBankAccountNumber(int _id, int _whichAccount);

        // Währungsmodul und Kontoauszug
        void createBankStatement(int _accNumber);
        void convertMoney(int Balance, string _currency);
        void showChangeOfCourse(int _cNumber);
    }
}
