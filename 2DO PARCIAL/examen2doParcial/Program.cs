using System;
using static System.Console;

namespace examen2doParcial
{
    class Program
    {
        static void Main(string[] args)
        {
                if(verifyString(readString())){
                    WriteLine("Your string is valid");
                }else{
                    WriteLine("Your string is invalid");
                }      
        }

        static string readString(){
            Write("Hi!, please please enter your string to verify: ");
            return ReadLine();
        }

        static bool verifyString(string toVerify){
            int keyO = 0; //Guarda el numero de llaves de apertura que existen en el dato entrada
            int keyC = 0; //Guarda el numero de llaves de apertura que existen en el dato entrada
            int squareO = 0; //Guarda el numero de corchetes de apertura que existen en el dato entrada
            int squareC = 0; //Guarda el numero de corchetes de apertura que existen en el dato entrada
            int parenthesisO = 0; //Guarda el numero de parentesis de apertura que existen en el dato entrada
            int parenthesisC = 0; //Guarda el numero de parentesiss de apertura que existen en el dato entrada

            foreach (var item in toVerify) //Recorre todo el arreglo y cuenta el numero de simbolos de agrupacion que existen
            {
                switch (item)
                {
                    case '{':
                        keyO++;
                        break;
                    case '}':
                        keyC++;
                        break;
                    case '[':
                        squareO++;
                        break;
                    case ']':
                        squareC++;
                        break;
                    case '(':
                        parenthesisO++;
                        break;
                    case ')':
                        parenthesisC++;
                        break;
                    default:
                        break;
                }
            }

            if( (keyO+keyC) % 2 != 0 || (squareO+squareC) % 2 != 0 || (parenthesisO+parenthesisC) % 2 != 0 ){ //Si el numero de simbolos de agrupacion no son pares
                return false; //Falta una llave de cierre o de apertura entonces es falso
            }else{
                string operators = ""; //Guarda solo los simbolos de agrupacion en el dato de entrada
                for (int i = 0; i < (toVerify.Length); i++) //Recorre todo el arreglo y guarda todos los simbolos de agrpacion que existen en el dato de netrada
                {
                    switch (toVerify[i])
                    {
                        case '{':
                            operators += toVerify[i];
                            break;
                        case '}':
                            operators += toVerify[i];
                            break;
                        case '[':
                            operators += toVerify[i];
                            break;
                        case ']':
                            operators += toVerify[i];
                            break;
                        case '(':
                            operators += toVerify[i];
                            break;
                        case ')':
                            operators += toVerify[i];
                            break;
                        default:
                            return true;
                    }
                }
                char pair = 'a'; //Guarda el par del simbolo de apertura encontrado
                int pairs = 0; //Cuenta los pares encontrados
                for (int i = 0; i < operators.Length; i++) //Se recoore todo el arreglo de operadores para encontrar el par
                {
                    switch (operators[i])
                    {
                        case '{':
                            pair = '}'; //Se asigna a par, su par correspondiente
                            break;
                        case '[':
                            pair = ']';
                            break;
                        case '(':
                            pair = ')';
                            break;
                        default:
                            break;
                    }

                    for (int y = i+1; y <  operators.Length; y++) //Despues de definir el par se busca  a partir de la posicion en la que nos quedamos + 1
                    {
                        if (operators[y] == pair) //si se encuentra
                        {
                            pairs++; //decimos que ya encontramos un par
                            y = operators.Length; //nos salimos del ciclo
                        }
                    }
                }
                if(operators.Length / pairs == 2){ //si los pares encontrados fueron la mitad del; arreglo de operadores
                    return true; //esta correcto
                }else{
                    return false; //si no, no
                }
            }
        }
    }
}
