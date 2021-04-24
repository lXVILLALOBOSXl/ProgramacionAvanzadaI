using System;

namespace GeneralLibrary
{
    /// <summary>
    /// Se encarga de escribir y mostrar segun el tipo de direccionj
    /// </summary>
    /// <typeparam name="T">Recibe el tipo de direccion</typeparam>
    public class Direction<T>
    {
        private T[] directions; //Areglo tipo generico para almacenar direcciones ipv4 o ipv6
        private int count = 0; //Guarda el index de las posiciones del arreglo
        
        /// <summary>
        /// Se encarga de inicializar los arreglos de direcciones para cada tipo
        /// </summary>
        /// <param name="size">Recibe el tamano de direcciones deseadas</param>
        public Direction(int size){ 
            directions = new T[size];
        }

        /// <summary>
        /// Se encarga de crear una direccion ipv4 o ipv6 representa en sistema binario
        /// </summary>
        /// <param name="obj">Recibe el tipo de objeto que se va a inicializar</param>
        public void Write(T obj){
            directions[count] = obj; //Guarda dicho objeto en su correspondiente areglo
            count++; //Aumenta uno para llevar la cuenta de cuantas direcciones existen
        }

        /// <summary>
        /// Consulta la informacion para mostar la direccion que fue representada en binario
        /// </summary>
        /// <param name="index">Recibe el index de la direccion que se desea desea mostar</param>
        /// <returns>//Retorna la direccion representada en binario</returns>
        public T GetItem(int index){
            return directions[index];
        }


    }
}
