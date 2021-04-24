using System;
using static System.Console;
//Luis Adrian Villalobos RIvera 18100586 7°C1
//Dividí mi problema en 3 pequeños poblemas
//1ERO: Se leen los numeros
//2DO: Se analiza que los numeros esten en el rango
//3ERO: Se diden los numeros y se muestra el resultado
namespace p2Excepciones18100586
{
    class Program
    {
        static void Main(string[] args)
        {
            //La funcion division funciona para imprimir el resultado de la division
            //La funcion ingresarNum funciona para retornar los numeros evaluados
            //La funcion isInTheRange verifica que x numero este dentro del rango
            division(ingresarNum("1"),ingresarNum("2"));
        }

        private static byte ingresarNum(string index){ //La funcion es byte por que retorna el numero que el usuario ingreso
            //index funciona para indicarle al usuario el index del numero (solo estetica)
            string num; //num funciona para guardar lo que se llena en consola
            do{
                Write($"Ingrese su numero {index}: "); //pedimos el primer numero en el index que se haya enviado
                num = ReadLine(); //utilizamos el metodo ReadLine() para poder leer lo que hay en consola
            }while(!isInTheRange(num)); //Mientras que la funcion isInTheRange == false va volver a pedir el numero

            return byte.Parse(num); //LLegar aqui significa que no hay errores, se hace una conversion y se retrorna el numero
        }

        private static bool isInTheRange(string num){ //La funcion es bool por que indica si hay errores o no
            try{  
                byte number = byte.Parse(num); //Se hace un casteo para verificar que no haya error
                return true; //Si no hay error quiere decir que el numero es verdadero para nuestras condiciones
            }
            catch(OverflowException){ //Si el numero no esta en el rango
                WriteLine("El numero es demasiado grande o pequeño, intentelo de nuevo con rango del 0 al 255");
                return false; //El numero no estaa dentro de nuestras condiciones
            }
            catch(FormatException){//Si el numero es un digito no numerico
                WriteLine("El formato es incorrecto, intentelo de nuevo introduciendo solo digitos numericos enteros");
                return false; //El numero no estaa dentro de nuestras condiciones
            }
            catch (Exception error){//Definimos un objeto de la clase exception para cualquier otro error
                WriteLine($"{error.GetType()} dice {error.Message}"); //Se imprime el mensaje del error (obj.Message) y el tipo (obj.GetType()) 
                return false; //El numero no esta dentro de nuestras condiciones
            }
        }

        private static void division(byte num1, byte num2){//Recibe el dividendo como num1 y el divisor como num2
            try{ //Se intenta hacer la división
                WriteLine($"El resultado de la division es: {num1/num2}"); //Si la división se puede hacer se imprime el resultado
            }
            catch(DivideByZeroException){ //En caso de que el divisor sea 0
                WriteLine($"El resultado de la division es: Indefinido, división entre 0"); //Se dice que es indefinido
            }
        }
    }
}
