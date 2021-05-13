using System;
using static System.Console;

namespace abecedario
{
    class Program
    {
        static void Main(string[] args)
        {
            Letters x = new Letters(getInput());
        }

        static string getInput(){
            Write("Hi! please write your string: ");
            return ReadLine().ToLower();
        }
    }
}
