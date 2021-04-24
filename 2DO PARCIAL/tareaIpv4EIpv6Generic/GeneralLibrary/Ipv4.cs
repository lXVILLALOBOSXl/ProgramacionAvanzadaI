using System;
using static System.Console;

namespace GeneralLibrary
{
    /// <summary>
    /// Esta clase representa una direccion ipv6 en binario
    /// </summary>
    public class Ipv4 : IGetDirection
    {
        private char [] binaryValue = new char[35]; //Guarda la direccion ipv4 en binario

        /// <summary>
        /// El constructor se encarga de registrar la informacion de la direccion y castinar a binario para poder erepresentarla
        /// </summary>
        /// <param name="ipv4">Recibe un arreglo con la direccion ipv4 en decimal</param>
        public Ipv4(byte [] ipv4){
            ipv4ToBinary(ipv4); //Llama al metodo que se encarga de registrar, representar y castinar la direccion en binario
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
        /// <param name="ipv4">Recibe un arreglo con la direccion ipv4 en decimal</param>
        public void ipv4ToBinary(byte [] ipv4){ 
            int index = 7, indexAuxiliar = 7; //Funcionan para llevar un control de la posicion de los bits de cada byte
            fillArrayWithZero();//Antes de iniciar se llena el arreglo con 0s representando que esta vacio para poder utilizar posiciones adelantadas
            for (int i = 1; i <= 4; i++) //Se encarga de llenar los 4 bytes del arreglo binario que representa una direccion ipv4
            {
                byte count = 0; //Lleva un control para cambiar de twobyte cada 8 bits
                do{
                    this.binaryValue[index] += Convert.ToChar(ipv4[i] % 2); //En la posicion del bit correspondiente en el arreglo binario guarda el resto de la cantidad decimal entre 2
                    ipv4[i] /= 2; //La cantidad en el byte correspondiente se divide en 2 
                    count++; //Se aumenta un uno, llevando el control de los bits
                    index--; //Disminuye de posicion de bit hasta llegar al mas signiifcativo de cada byte
                }while(count < 8);
                if(i == 4){ //Si se encuentra en el ultimo byte
                    continue; //Ya no hace lo que esta debajo por que se salta a la siguiente iteracion
                }
                this.binaryValue[indexAuxiliar+1] = '.'; //Se agrega un . cada byte para representarlo de manera correcta
                index = indexAuxiliar+9; //Se hace el cambio de posicionamiento de bit para cada cambio de byte
                indexAuxiliar = index;  //Se guarda en el bit que se quedo para la siguiente iteracion
            }
        }

        /// <summary>
        /// Llena e inicia todas las posiciones del arreglo con 0
        /// </summary>
        public void fillArrayWithZero(){ 
            for (int i = 0; i < 35; i++)
            {
                this.binaryValue[i] = '0';
            }
        }


    }
}