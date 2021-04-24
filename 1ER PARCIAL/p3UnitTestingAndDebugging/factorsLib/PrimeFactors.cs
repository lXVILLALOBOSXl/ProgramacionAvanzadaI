using System;
using static System.Convert;

namespace factorsLib
{
    public class PrimeFactors
    {
        /// <summary>
        /// Funciona para una vez que el numero ya esta evaluado, lo descomponga en factores primos
        /// </summary>
        /// <param name="numToPrimeFactors">Dato de ingreso de usuario ya verificado</param>
        /// <returns>//Retorna el numero descompuesto en factores primos con el formato num x num</returns>
        public string GetPrimeFactors(int numToPrimeFactors)
        {
            string result = (numToPrimeFactors.ToString() + " : "); //Variable para guardar y concatenar los factores primos
            if(isZeroOrOne(numToPrimeFactors)){//Caso base, manda a llamar isZeroOrOne() con el numero a evaluar para verificar si este es 0 u 1
                result = result + "1"; //Si es así el factor primo solo es 1 y se guarda en el resultado
            }else{ //Si no es 0 u 1
                for(int i = (numToPrimeFactors-1); i > 0 ; i--){//i es el contador que se inicializa con el valor del numero a convertir menos uno para no imprimir 1 como factor primo y dividirlo por si mismo
                //Mientras que sea mayor que 0 se ira disminuyendo
                    if(numToPrimeFactors % i == 0){ //Si al dividir el numeroAFactorPrimo entre el contador da 0 como resto quiere decir que hay un numero primo
                        if(i != 1){ //Si el contador no es 1 quiere decir que aun faltan mas factores
                            result = result + ((numToPrimeFactors/i).ToString() + " x "); //Se divide el numeroAFactorPrimo entre el contador para tener solamente el numero primo, se castea para poder imprimirlo y se concatena un x para indicar que existe una multiplicacion, se le iran concatenando los siguientes numeros primos encontrados
                        }else{//Si no, quiere decir que es el ultimo factor enconotrado
                            result = result + (numToPrimeFactors/i).ToString(); //Se le concatena el factor primo encontrado sin la x anterior
                        }
                        
                        numToPrimeFactors = i; //El numero a descomponer ahora se convierte por el que se dividio anteriormenye
                    }
                }
            }

            return result; //Se retorna la cadena final ya concatenada 
        }

        /// <summary>
        /// Funciona para determinar si el numero se encuentra en el rango de nuestros paramteros indicadps
        /// </summary>
        /// <param name="numToPrimeFactors">Numero que el usuario quiere descomponer en factores</param>
        /// <returns>//Retorna el estado de validacion: isIntheRange = true; se encuentra dentro del rango. isIntheRange = false; no se encuentra dentro del rango</returns>
        public bool IsInTheRange(int numToPrimeFactors)
        {
            if(numToPrimeFactors > 1000 || numToPrimeFactors < 0){//Si el numero del usuario es mayor a 1000 o menor a 0 
                return false; //No esta dentro del rango
            }else{//Si no es mayor a 1000 o menor de 0
                return true; //Esta dentro del rango
            }
        
        }

        /// <summary>
        /// Sirve para indicar si el numeroAConvertir es un caso base (1 o 0)
        /// </summary>
        /// <param name="numToPrimeFactors">Numero que el usuario quiere descomponer en factores</param>
        /// <returns>Retorna el estado de validacion: isZeroOrOne = true; Es un caso base. isZeroOrOne = false; No es un caso base</returns>
        public bool isZeroOrOne(int numToPrimeFactors)
        {
            if(numToPrimeFactors == 0|| numToPrimeFactors == 1){//si el numeroAConvertir es 1 o 0 
                return true; //Es un caso base
            }else{//si el numeroAConvertir no es 1 o 0 
                return false; //No es un caso base
            }
        
        }
    }
}
