using System;
using factorsLib;
using static System.Console;

namespace consoleAplicationPrimeFactors
{
    class Program
    {

        //Dividi mi problema en 3 pequeños procesos (Leer, verificar y procesar)
        //La función de readNumber() es indicar al usuario que ingrese el numero que desea convertir a factores primos
        //La función de valideData() es corroborar que la entrada del usuario fue correcta para los parametros indicados
        static void Main(string[] args)
        {
            readNumber(); //Llamada de función para leer datos
        }

        /// <summary>
        /// indica al usuario que ingrese el numero que desea convertir a factores primos, guarda el dato y manda a llamar
        /// la función valideData() para corroborar que todo este de acuerdo a lo indicado.
        /// </summary>
        public static void readNumber(){
            string input; //Se encarga de guardar el dato de entrada del usuario
            do{ //Por primera vez pide la información al usuario
                Write("Write a number between 0 and 1000 that you want to convert in prime factors: ");
                input = ReadLine();
            }while(!validateData(input)); //Mientras que el dato sea incorrecto, se volverá a pedir un nuevo dato.
        }

        /// <summary>
        /// Corrobora que el dato de entrada sea correcto de acuerdo a los parametros y si es así manda a llamar
        /// la función GetPrimeFactors(int) para mostrar el numero convertido a factores primos
        /// si no es así, indica al usuario que es lo que esta mal y retorna falso indicando que existe un error
        /// para volver a pedir los datos
        /// </summary>
        /// <param name="input">Dato ingresado por el usuario</param>
        /// <returns>Estado de validación; true = datos correctos, false = datos incorrectos</returns>
        public static bool validateData(string input){
            var primeFactors = new PrimeFactors(); //Instancia de mi clase PrimeFactors para utilizar los metodos pertenecientes
            int numToPrimeFactors; //Si el dato es correcto, guarda el numero ingresado
            if(int.TryParse(input, out numToPrimeFactors)){//Se intenta convertir la entrada (string) a int, si es así se guarda en numToPrimeFactors
                if(primeFactors.IsInTheRange(numToPrimeFactors)){ //Llama el metodo IsInTheRange con el parametro int del dato usuario para verificar si se encuentra entre el rango
                    WriteLine(primeFactors.GetPrimeFactors(numToPrimeFactors));//Llama el metodo GetPrimeFactors con el parametro int del dato usuario para convertir el numero a factores primos
                    return true; //Retorna estado verdadero indicando que no existe un error de rango y no vuelva a pedir otro numero
                }else{//Si no se encuentra en el rango
                    WriteLine("I could not convert your number because isn´t in the range, please check again");
                    return false; //Retorna estado falso indicando que existe un error de rango
                }
            }else{ //Si no se pudo convertir
                    WriteLine("I could not parse the input, please write a int number");
                    return false; //Retorna estado falso indicando que existe un error
            }
        }

    }
}
