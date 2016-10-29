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
        static void Main(string[] args)
        {
            // IN DER ANWENDUNG BEI DOUBLE BETRÄGEN STATT "." einen "," machen

            // Überweisung wegen verwendungszweck schaun -> vlt anders umgehen
            BankManagement bankManagement = new BankManagement();

            Console.WriteLine("BANK_SST ANWENDUNG");
            Console.WriteLine("========================= \n");

            bool exit = true;
            while(exit)
            {
                int user = 0;

                Console.WriteLine("Press 1 for further options concerning the customer management / Press 2 for further options concerning the account management / Press 3 to exit");
                int answer = Convert.ToInt32(Console.ReadLine());

                if (answer == 1)
                {
                    // Customer Management - AUSLAGERN
                    bool custM = true;
                    while (custM)
                    {
                        Console.WriteLine("Press 1 to create a new customer / Press 2 to change your personal information / Press 3 to delete your customer account / Press 4 to exit the customer management");
                        int customerAns = Convert.ToInt32(Console.ReadLine());

                        if (customerAns == 1)
                        {
                            Console.WriteLine("Insert first name");
                            string firstName = Console.ReadLine().ToString();
                            Console.WriteLine("Insert last name");
                            string lastName = Console.ReadLine().ToString();
                            Console.WriteLine("Insert birthday");
                            string birthday = Console.ReadLine().ToString();
                            Console.WriteLine("Insert address");
                            string address = Console.ReadLine().ToString();
                            Console.WriteLine("Insert location");
                            string location = Console.ReadLine().ToString();
                            Console.WriteLine("Insert telephone number");
                            string telephoneNumber = Console.ReadLine().ToString();

                            user = bankManagement.createCustomer(firstName, lastName, birthday, address, location, telephoneNumber);
                            Console.WriteLine("CREATED NEW CUSTOMER!");
                        }
                        // Change Bank Account information
                        else if (customerAns == 2)
                        {
                            // Informationen eingeben um die ID zu erhalten 
                            if(user == 0)
                            {
                                user = getCustomerID(bankManagement);
                            }

                            Console.WriteLine("Insert first name");
                            string firstName = Console.ReadLine().ToString();
                            Console.WriteLine("Insert last name");
                            string lastName = Console.ReadLine().ToString();
                            Console.WriteLine("Insert address");
                            string address = Console.ReadLine().ToString();
                            Console.WriteLine("Insert location");
                            string location = Console.ReadLine().ToString();
                            Console.WriteLine("Insert telephone number");
                            string telephoneNumber = Console.ReadLine().ToString();

                            bankManagement.changeFirstName(user, firstName);
                            bankManagement.changeLastName(user, lastName);
                            bankManagement.changeAddress(user, address);
                            bankManagement.changeLocation(user, location);
                            bankManagement.changeTelephonNr(user, telephoneNumber);

                            Console.WriteLine("CUSTOMER INFORMATION CHANGED!");
                        }
                        // Delete Customer Account
                        else if (customerAns == 3)
                        {
                            if (user == 0)
                            {
                                user = getCustomerID(bankManagement);
                            }
                            bankManagement.deleteCustomer(user);
                            Console.WriteLine("DELETED CUSTOMER!");
                        }
                        else if (customerAns == 4)
                        {
                            custM = false;
                        }
                        else
                        {
                            Console.WriteLine("Wrong Input");
                        }
                    }
                }
                else if(answer == 2)
                {
                    // Account Management
                    bool accM = true;
                    while (accM)
                    {
                        int creditAcc = 0;
                        int savingsAcc = 0;

                        if (user == 0)
                        {
                            user = getCustomerID(bankManagement);
                        }

                        Console.WriteLine("****************************************************");
                        Console.WriteLine("Press 1 to create a new credit account / Press 2 to create a new savings account / Press 3 to deposit credit account");
                        Console.WriteLine("Press 4 to deposit savings account / Press 5 to withdraw credit account / Press 6 to transfer money / Press 7 to delete savings account");
                        Console.WriteLine("Press 8 to delete credit account / Press 9 for bank statement / Press 10 to exit the account management");
                        int accAns = Convert.ToInt32(Console.ReadLine());

                        if (accAns == 1)
                        {
                            // create a new credit account
                            bankManagement.createCreditAccount(user);
                            Console.WriteLine("NEW CREDIT ACOOUNT CREATED!");
                        }
                        else if (accAns == 2)
                        {
                            // create a new savings account 
                            bankManagement.createSavingsAccount(user);

                            Console.WriteLine("NEW SAVINGS ACOOUNT CREATED!");
                        }
                        else if (accAns == 3)
                        {
                            // deposit credit account 
                            if (creditAcc == 0)
                            {
                                creditAcc = getAccountNumber(user, bankManagement);
                            }
                            
                            Console.WriteLine("Insert a usage: ");
                            string _usage = Console.ReadLine().ToString();
                            Console.WriteLine("Insert the amount: ");

                            double amount;
                            string amountString = Console.ReadLine().ToString();
                            if(Double.TryParse(amountString, out amount))
                            {
                                bankManagement.depositCreditAcc(creditAcc, _usage, amount);
                            }
                            else
                            {
                                Console.WriteLine("Error: deposit credit account");
                            }

                            Console.WriteLine("CREDIT ACCOUNT DEPOSIT!");
                        }
                        else if (accAns == 4)
                        {
                            // deposit savings account 
                            // get account number
                            if (savingsAcc == 0)
                            {
                                // Verbessern -> alle auflisten und auswählen lassen
                                Console.WriteLine("****************************************************");
                                Console.WriteLine("Insert one of your 'savings' account numbers - you can have 1 to 5 accounts [acc1 = insert 1, acc2 = insert 2, acc3 = insert 3, acc4 = insert 4, acc5 = insert 5] ");
                                int whichAcc = Convert.ToInt32(Console.ReadLine());
                                savingsAcc = bankManagement.getBankAccountNumber(user, whichAcc);
                            }
                            Console.WriteLine("****************************************************");
                            Console.WriteLine("Insert a usage: ");
                            string _usage = Console.ReadLine().ToString();
                            Console.WriteLine("Insert the amount: ");
                            double amount;
                            string amountString = Console.ReadLine().ToString();
                            if (Double.TryParse(amountString, out amount))
                            {
                                bankManagement.depositSavingsAcc(savingsAcc, _usage, amount);
                            }
                            else
                            {
                                Console.WriteLine("Error: deposit savings account");
                            }

                            Console.WriteLine("SAVINGS ACCOUNT DEPOSIT!");
                        }
                        else if (accAns == 5)
                        {
                            // withdraw credit account
                            if (creditAcc == 0)
                            {
                                creditAcc = getAccountNumber(user, bankManagement);
                            }

                            Console.WriteLine("Insert the amount: ");
                            double amount;
                            string amountString = Console.ReadLine().ToString();
                            if (Double.TryParse(amountString, out amount))
                            {
                                bankManagement.withdrawCreditAcc(creditAcc, amount);
                            }
                            else
                            {
                                Console.WriteLine("Error: withdraw");
                            }

                            Console.WriteLine("CREDIT ACCOUNT WITHDRAW!");
                        }
                        else if (accAns == 6)
                        {
                            // transfer money
                            if (creditAcc == 0)
                            {
                                creditAcc = getAccountNumber(user, bankManagement);
                            }

                            Console.WriteLine("****************************************************");
                            Console.WriteLine("Insert account number to which you want to transfer money:");
                            int toAccNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Insert usage:");
                            string usage = Console.ReadLine().ToString();

                            Console.WriteLine("Insert the amount: ");
                            double amount;
                            string amountString = Console.ReadLine().ToString();
                            if (Double.TryParse(amountString, out amount))
                            {
                                bankManagement.transfer(creditAcc, toAccNumber, usage, amount);
                            }
                            else
                            {
                                Console.WriteLine("Error: transfer");
                            }

                            Console.WriteLine("CREDIT ACCOUNT TRANSFER!");
                        }
                        else if (accAns == 7)
                        {
                            //  Press 7 to delete savings account
                            if (savingsAcc == 0)
                            {
                                // Verbessern -> alle auflisten und auswählen lassen
                                Console.WriteLine("****************************************************");
                                Console.WriteLine("Insert one of your 'savings' account numbers - you can have 1 to 5 accounts [acc1 = insert 1, acc2 = insert 2, acc3 = insert 3, acc4 = insert 4, acc5 = insert 5] ");
                                int whichAcc = Convert.ToInt32(Console.ReadLine());
                                savingsAcc = bankManagement.getBankAccountNumber(user, whichAcc);
                            }
                            bankManagement.deleteSavingsAccount(savingsAcc, user);

                            Console.WriteLine("SAVINGS ACCOUNT DELETED!");
                        }
                        else if (accAns == 8)
                        {
                            // delete credit account
                            if (creditAcc == 0)
                            {
                                creditAcc = getAccountNumber(user, bankManagement);
                            }
                            bankManagement.deleteCreditAccount(creditAcc, user);

                            Console.WriteLine("CREDIT ACCOUNT DELETED!");
                        }
                        else if(accAns == 9)
                        {
                            // bank statement
                            if (creditAcc == 0)
                            {
                                creditAcc = getAccountNumber(user, bankManagement);
                            }
                            bankManagement.createBankStatement(creditAcc);
                        }
                        else if (accAns == 10)
                        {
                            // exit the account management
                            accM = false;
                        }
                        else
                        {
                            Console.WriteLine("Wrong Input");
                        }
                    }
                }
                else if(answer == 3)
                {
                    exit = false;
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }
            }

            // todo if anweisungen ! EXCEPTIONS

            Console.WriteLine("2. Test");      
        }

        private static int getCustomerID(BankManagement bm)
        {
            int customerID = -1;

            while(customerID == -1)
            {
                Console.WriteLine("****************************************************");
                Console.WriteLine("Insert following information to log in: ");
                Console.WriteLine("First name:");
                string firstname = Console.ReadLine().ToString();
                Console.WriteLine("Last name: ");
                string lastname = Console.ReadLine().ToString();
                Console.WriteLine("Birthdate: [dd.mm.yyyy] ");
                string birthday = Console.ReadLine().ToString();

                customerID = bm.getCustomer(firstname, lastname, birthday);             
            }

            return customerID;
        }

        private static int getAccountNumber(int user, BankManagement bm)
        {
            Console.WriteLine("****************************************************");
            Console.WriteLine("Choose your credit account");
            // Verbessern -> alle auflisten und auswählen lassen
            Console.WriteLine("Insert one of your 'credit' account numbers - you can have 1 to 5 accounts [acc1 = insert 1, acc2 = insert 2, acc3 = insert 3, acc4 = insert 4, acc5 = insert 5]");
            int whichAcc = Convert.ToInt32(Console.ReadLine());
            int creditAcc = bm.getBankAccountNumber(user, whichAcc);

            return creditAcc;
        }
    }
}
