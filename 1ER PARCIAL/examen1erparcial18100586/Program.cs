using System;
using static System.Console;

namespace examen1erparcial18100586
{
    class Program
    {
        static void Main(string[] args)
        {
            getArrange(getSize());
        }

        //Esta funcion sirve para indicarle al usuario que debe de ingresar sus numeros
        static int getSize(){
            string answer; //Guarda lo ingresado en copnsola
            Write("Hola, ingrese el tamano positivo de su arreglo, en rango de 1 a 1000: ");
            answer = ReadLine(); //Funcion para guaradar lo ingresado
            return tryConvertStringToInt(answer); //Manda a llamar a la funcion con lo ingresado por el usuario para que convierta la entrada string en un int y regresa el numero que ingreso el usuario 
        }

        static int tryConvertStringToInt(string answer){ //Recibe la entrada del usuario
            int error = 1; //Solo la utilizo por que el compilador maracaba error si no existia un retorno despues del catch pero logicamente es correcto que no se use
            try{
                int sizeOfArrange = int.Parse(answer); //intenta convertir en entero la entrada
                if(sizeOfArrange < 1 || sizeOfArrange > 1000){ //Si no se encuentra dentro del parametro
                     WriteLine("El numero del arreglo tiene que ser en un rango de 1 a 1000, intentelo de nuevo");
                     getSize(); //Vuelve a pedir los numeros
                }else{ //si no
                    return sizeOfArrange; //retorna  el numero ya convertido
                }
            }catch (Exception ex){ //en caso de que ingrese una letra o que no este en el rango
                 WriteLine($"Error: {ex.GetType()} dice: {ex.Message}"); //se muestra el mensaje de error
                 getSize(); //se piden los numeros de nuevo
            }
            return error; //logicamente nunca se retorna esto
        }

        static void getArrange(int sizeOfArrange){//recibe el tramaño del arreglo
            int[] numbers = new int[1000]; //creamos un arreglo de 1000 espacios para guardar los numeros
            int numberPositive, numberNegative; //funciona para llevar una cuenta y agregarlos al arreglo
            if(sizeOfArrange == 1){ //si solo es de una posicion
                WriteLine("{0}"); //se imprime 0
            }else{ // si no
                numberNegative = ((sizeOfArrange/2)*(-1)); //se saca la mitad de numeros del arreglo y se convierten negativos
                numberPositive = (sizeOfArrange/2); //se saca la mitad de numeros del arreglo y se convierten positivos
                if((sizeOfArrange % 2) == 0){ //si el tamano del arreglo es par
                    for (int i = 0; i <= sizeOfArrange; i++)
                    {
                        if(i >= (sizeOfArrange/2)){ //de la mitad para el positivo se contrarrestan los numeros
                            numbers[i] = numberPositive; //se guarda la mitad en la mitad
                            numberPositive--; //y se decrementa
                        }else{ //si no
                            numbers[i] = numberNegative; //se guarda la mitad negativa en la posicion 0
                            numberNegative++; //se va acercando a la parte positiva sumandp
                        }
                    }
                }else{ //si es impar 
                    for (int i = 0; i <= sizeOfArrange; i++)
                    {
                        if(i > (sizeOfArrange/2)){ //funciona como la parte positiva del arreglo par
                            numbers[i] = numberPositive;
                            numberPositive--;
                        }else if(i == (sizeOfArrange/2)){ //en el punto medio agrega un 0
                            numbers[i] = 0;
                        }else{ //funciona como la parte negativa del arreglo par
                            numbers[i] = numberNegative;
                            numberNegative++;
                        }

                    }
                } //se imprime
                   Write("{"); 
                    for (int i = 0; i < sizeOfArrange; i++)
                    {
                        Write($"{numbers[i]}, ");  
                    }
                    Write("}");  
            }
        }
    }
}
