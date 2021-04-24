using System;
using static System.Console;

namespace GeneralLibrary
{
    /// <summary>
    /// Esta clase representa una direccion ipv6 en binario
    /// </summary>
    public class Ipv6 : IGetDirection
    {
        private char [] binaryValue = new char[135]; //Guarda la direccion ipv6 en binario

        /// <summary>
        /// El constructor se encarga de registrar la informacion de la direccion y castinar a binario para poder erepresentarla
        /// </summary>
        /// <param name="ipv6">Recibe un arreglo con la direccion ipv6 en decimal</param>
        public Ipv6(ushort [] ipv6){ 
            ipv6ToBinary(ipv6); //Llama al metodo que se encarga de registrar, representar y castinar la direccion en binario
        }

        /// <summary>
        /// Imprime la direccion representada en binario, es una propiedad de la interfaz IGetDirection para ambas clases (ipv6, ipv4)
        /// </summary>
        public void getDirection(){
            foreach (var item in this.binaryValue)
            {
                Write($"{item}");
            }
            WriteLine();
        }

        /// <summary>
        /// Convierte la direccion ipv6 decimal y la representa en binario
        /// </summary>
        /// <param name="ipv6">Recibe un arreglo con la direccion ipv6 en decimal</param>
        public void ipv6ToBinary(ushort [] ipv6){ 
            int index = 15, indexAuxiliar = 15; //Funcionan para llevar un control de la posicion de los bits de cada twobyte
            fillArrayWithZero(); //Antes de iniciar se llena el arreglo con 0s representando que esta vacio para poder utilizar posiciones adelantadas
            for (int i = 0; i < 8; i++) //Se encarga de llenar los 8 twobytes del arreglo binario que representa una direccion ipv6
            {
                byte count = 0; //Lleva un control para cambiar de twobyte cada 16 bits
                do{
                    this.binaryValue[index] += Convert.ToChar(ipv6[i] % 2); //En la posicion del bit correspondiente en el arreglo binario guarda el resto de la cantidad decimal entre 2
                    ipv6[i] /= 2; //La cantidad en el twobyte correspondiente se divide en 2 
                    count++; //Se aumenta un uno, llevando el control de los bits
                    index--; //Disminuye de posicion de bit hasta llegar al mas signiifcativo de cada twobyte
                }while(count < 16);
                if(i == 7){ //Si se encuentra en el ultimo twobyte
                    continue; //Ya no hace lo que esta debajo por que se salta a la siguiente iteracion
                }
                this.binaryValue[indexAuxiliar+1] = '.'; //Se agrega un . cada twobyte para representarlo de manera correcta
                index = indexAuxiliar+17;  //Se hace el cambio de posicionamiento de bit para cada cambio de twobyte
                indexAuxiliar = index; //Se guarda en el bit que se quedo para la siguiente iteracion
            }
        }

        /// <summary>
        /// Llena e inicia todas las posiciones del arreglo con 0
        /// </summary>
        public void fillArrayWithZero(){ 
            for (int i = 0; i < 135; i++)
            {
                this.binaryValue[i] = '0';
            }
        }
    }

}