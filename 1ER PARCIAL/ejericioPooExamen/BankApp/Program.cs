using System;
using GeneralLibrary;
using static System.Console;

namespace BankApp
{
    class Program
    {

        static void Main(string[] args)
        {   
            while(true){
                options(initialMenu());
            }
        }
        
        public static string initialMenu(){
            string answer;
            WriteLine("Menu prinicipal");
            WriteLine("1. Nuevo cliente");
            WriteLine("2. Cliente existente");
            Write("Ingrese su opcion: ");
            answer = ReadLine();
            WriteLine("");
            return answer;
        }

        public static void options(string option){
            bool isCorrect;
            int numAccount = 0;
            BankAccount[] clients = new BankAccount[50];
            do{
                switch (option)
                {
                    case "2":
                        existingClient(clients);
                        isCorrect = true;
                        break;
                    case "1":
                        newClient(numAccount, clients);
                        isCorrect = true;
                        break;
                    default:
                        WriteLine("Opcion incorrecta, intentelo de nuevo");
                        isCorrect = false;
                        break;
                }

            }while(!isCorrect);
        }


        public static void newClient(int numAccount, BankAccount[] clients){
            string name, dateOfBirth;
            DateTime dateOfBirthday;
            Write("Ingrese su nombre completo: ");
            name = ReadLine();
            do{
                Write("Ingrese su fecha de nacimiento: ");
                dateOfBirth = ReadLine(); 
            }while(!intentConvertDateTime(dateOfBirth));
            dateOfBirthday = convertDateTime(dateOfBirth);
            numAccount++;
            clients [numAccount] = new BankAccount(name, dateOfBirthday, 0, numAccount);
        }

        public static void existingClient(BankAccount[] clients){
            string readNumberAccount, nameClient = "";
            int numAccount;
            Write("Ingrese su numero de cuenta: ");
            readNumberAccount = ReadLine();
            try{
                numAccount = int.Parse(readNumberAccount);
                nameClient = clients[numAccount].getName();
            }catch(Exception ex){
                WriteLine($"Error: {ex.GetType()} dice {ex.Message}");
                existingClient(clients);
            }
            WriteLine($"Hello {nameClient}");
        }

        public static bool intentConvertDateTime(string dateOfBirthday){
            try{
                DateTime dateOfBirth = DateTime.Parse(dateOfBirthday);
            }catch(Exception ex){
                WriteLine($"Error: {ex.GetType()} dice {ex.Message}");
                return false;
            }
            return true;
        }

        public static DateTime convertDateTime(string dateOfBirthday){
             return DateTime.Parse(dateOfBirthday);
        }
    }
}
