using System;
using GeneralLibrary;
using static System.Console;

//Luis Adrian Villalobos Rivera ®
//Estructura del programa
//3 clases:
//Direction: Clase generica que se encarga de escribir y mostar direcciones para la clas eipv6 e ipv4
//Ipv6: Representa una direccion ipv6 en binario
//Ipv4: Representa una direccion ipv4 en binario
//1 Interfaz:
//IGetDirection: Tiene un metodo para polimorfismo al momento de motrar la direccion para la clase ipv6 e ipv4

namespace DirectionsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(!menu()); //Mientras la funcion menu retorne falso quiere decir que existe un error y es necesario volver a llamar a la funcion menu
        }

        /// <summary>
        /// Se encarga de imprimir el menu para el usuario y llamar a las funciones necesarias segun la opcion deseada
        /// </summary>
        /// <returns>Si existe un error retorna falso, si no existe alguno se termina la ejecucion del programa</returns>
        public static bool menu(){
            string option; //Variable donde se guarada la opcion ingresada por el usuario
            Write("\nMain menu : \n 1) Check ipv4  \n 2) Check ipv6 \n 3) Exit \n Please, select a correct option: ");
            option = ReadLine();
            switch (option)
            {
                case "1": //En caso de que el usuario quiera checar una direccion ipv4
                    return convertIpv4DirectionInDecimal(readUserInfo("ipv4")); //Se mandan a llamar las funciones requereidas para checar la direccion ipv4, dichas funciones retornan
                    //estados logicos segun el analisis de los datos, falso = existe error en el dato de entrada, verdadero = no existe error en el dato ingresado
                case "2": //En caso de que el usuario quiera checar una direccion ipv6
                    return convertIpv6DirectionInDecimal(readUserInfo("ipv6")); //Se mandan a llamar las funciones requereidas para checar la direccion ipv4, dichas funciones retornan
                    //estados logicos segun el analisis de los datos, falso = existe error en el dato de entrada, verdadero = no existe error en el dato ingresado
                case "3": //En caso de que el usuario quiera finalizar la ejecucion del programa
                    WriteLine(" Thank you for choosing us");
                    return true; //No hay error y se termina la ejecucion del programa (no vuelve a mostrar el menu)
                default: //De otra manera
                    WriteLine(" Incorrect option, please try again");
                    return false; //Existe error en la opcion del menu y es necesario volver a mostrarlo
            }
        }

        /// <summary>
        /// Da indicaciones al usuario para ingresar su tipo de direccion elegida y guarda dicho dato
        /// </summary>
        /// <param name="typeOfDirection">//Recibe el tipo de direccion que el usuario escogio</param>
        /// <returns>//Retorna el dato que el usuario ingreso</returns>
        public static string readUserInfo(string typeOfDirection){
            Write($"\nType a {typeOfDirection} direction to answer if is correct: ");
            return ReadLine();
        }

        /// <summary>
        /// Se encarga de analizar si una direccion ipv4 es correcta, si dicha direccion es correcta se encarga de convertir la direccion de entrada en decimal y guardar
        /// dicha direccion en un arreglo para poder mandar dicho arrgelo al constructor de la clase ipv4, para convertirla y REPRESENTARLA SOLO en sistema binario
        /// </summary>
        /// <param name="input">Recibe el dato que fue ingresado por el usuario</param>
        /// <returns>//Retorna estados logicos segun el analisis de los datos, falso = existe error en el dato de entrada, verdadero = no existe error en el dato ingresado</returns>
        public static bool convertIpv4DirectionInDecimal(string input){
            if(input.Length > 15 || input.Length < 6){ //Si la entrada tiene una longitud mayor a 15 o menor a 6 por formato NO es una direccion ipv4 correcta
                return isValidDirection(false); //Manda a llamar a una funcion que se encarga de imprimir el error y regresar un estado logico falso
            }else{ //Si esta dentro de los rangos de longitud
                byte [] ipv4 = new byte[5]; //A partir de la posicion 1 guarda el byte de la direccion en su posicion correspondiente dentro del arreglo
                byte b = 0; //Contador para saber en que byte se encuentra
                string threeDigits = " "; //Se encarga de concatenar y castinar los bytes de la direccion que escribio el usuario
                for (int i = 0; i < input.Length; i++) //Ciclo para moverme dentro de la direccion que proporciono el usuario
                {
                    if(input[i] == '.' || i == (input.Length-1)){ //Si se encuentra dentro de la direccion con un . o es el ultimo loop que hace
                        if ( i == (input.Length-1)) //Si es el ultimo loop
                        {
                            threeDigits += input[i]; //Se encarga de concatenar el ultimo digito de la direccion proporcionada por el usuario
                        }
                        b++; //Se suma 1 para empezar en el primer byte de la direccion
                        try{ //intenta
                            ipv4[b] = byte.Parse(threeDigits); //Dentro de mi arreglo en la posicion del byte correspondiente se guarda el byte correspondiente de la direccion del usuario
                            threeDigits = ""; //Se limpia por que en el siguiente ciclo guardara un nuevo byte
                            continue; //Se brinca a la siguiente iteracion
                        }
                        catch (Exception){//En caso de que no se pueda castinar quiere decir que el numero es mayor a 255, o simplemente hay un error dentro de la direccion escrita
                        //por el usuario
                            return isValidDirection(false); //Manda a llamar a una funcion que se encarga de imprimir el error y regresar un estado logico falso
                        }
                    }else{ //Si no
                        threeDigits += input[i]; //Concatena los numeros de los bytes correspondientes
                    }
                }
                return isValidDirection(true, ipv4); //Una vez que ya guardo en el arreglo la direccion en decimal en byte por posicion 
                //Retorna un estado logico verdadero, indicanco que no existe error y ademas guarda la direccion representada en binario en la clase ipv4
            }
        }

        /// <summary>
        /// Se encarga de convertir la direccion de entrada en decimal y guardar
        /// dicha direccion en un arreglo para poder mandar dicho arrgelo al constructor de la clase ipv6, para convertirla y REPRESENTARLA SOLO en sistema binario
        /// </summary>
        /// <param name="input">Recibe el dato que fue ingresado por el usuario</param>
        /// <returns>Retorna estados logicos segun el analisis de los datos, falso = existe error en el dato de entrada, verdadero = no existe error en el dato ingresado</returns>
        public static bool convertIpv6DirectionInDecimal(string input){
            if(!isValidDirection(input)){ //Se manda a llamar a la funcion que se encarga de analizar si la direccion ipv6 es correcta segun las reglas, si arroja falso quiere
            //decir que dicha direccion es incorrecta 
                return false; //por lo tanto se retorna un falso
            }else{ //Si la direccion es correcta se procede a convertirla en decimal
                ushort [] Ipv6 = new ushort[8]; //Guarda 2 Bytes en cada posicion del arreglo con la posision de dichos bytes en la direccion proporcionada
                ushort TwoByte = 0; //Contador para saber en que 2byte se encuentra
                int twoByte0 =3, twoByte1 = 2, twoByte2 = 1; //Guardan la posicion del bit que se analiza para despues multiplicar lo que esta en dicha posicion segun el analisis
                for (int i = 0; i < input.Length; i++) //Ciclo para moverme dentro de la direccion que proporciono el usuario
                {
                    if(input[i] != ':'){ //Si en la posicion de la direccion que me encuentro es diferente al operador quiere decir que existe un dato hexadecimal
                        if(i == 0 || i % 5 == 0){ //Si esta en el bit numero 0 o es multiplo de 5 quiere decir que es el mas significativo del byte correspondiente y en este caso se multiplica por la base (16) 
                        //a la potencia 3
                            Ipv6[TwoByte] += (ushort)(equalsToDecimal(input[i])*4096); //Se manda a llamar una funcion con el bit en la posicion del contador que se encarga de retornar su valor decimal
                            //el resultado se castea al tipo de dato del arreglo y se guarda en la posicion del twobyte correspondinte
                        }else if(i == twoByte2){ //Si esta en el bit numero 1 que es el mas significativo-1 del byte correspondiente y en este caso se multiplica por la base (16) a la potencia 2
                            Ipv6[TwoByte] += (ushort)(equalsToDecimal(input[i])*256); //Se manda a llamar una funcion con el bit en la posicion del contador que se encarga de retornar su valor decimal
                            //el resultado se castea al tipo de dato del arreglo y se guarda en la posicion del twobyte correspondinte
                            twoByte2 += 5; //Se suma 5 a la posicion del bit por que son los digitos que existen de diferencia cada twobyte
                        }else if(i == twoByte1){ //Si esta en el bit numero 2 que es el menos significativo+1 del byte correspondiente y en este caso se multiplica por la base (16) a la potencia 1
                            Ipv6[TwoByte] += (ushort)(equalsToDecimal(input[i])*16); //Se manda a llamar una funcion con el bit en la posicion del contador que se encarga de retornar su valor decimal
                            //el resultado se castea al tipo de dato del arreglo y se guarda en la posicion del twobyte correspondinte
                            twoByte1 += 5;  //Se suma 5 a la posicion del bit por que son los digitos que existen de diferencia cada twobyte
                        }else if(i == twoByte0){ //Si esta en el bit numero 2 que es el menos significativo del byte correspondiente y en este caso se multiplica por la base (16) a la potencia 0
                            Ipv6[TwoByte] += (ushort)equalsToDecimal(input[i]); //Se manda a llamar una funcion con el bit en la posicion del contador que se encarga de retornar su valor decimal
                            //el resultado se castea al tipo de dato del arreglo y se guarda en la posicion del twobyte correspondinte
                            TwoByte++; //Si se encuentra en el caso del bit menos significativo quiere decir que volvera a repetir todo el proceso pero con twobyte diferente
                            twoByte0 += 5; //Se suma 5 a la posicion del bit por que son los digitos que existen de diferencia cada twobyte
                        }
                    }else{ //Si hay un operador se analiza si se finaliza con dicho operador PARA FORMATOS XXXX:: = XXXX:0000:0000:0000:0000:0000:0000:0000
                        if(input[i+1] == ':'){ //Si despues del operador : existe otro operador igual quiere decir que se omiten los 0
                            TwoByte++; //Suma para cambiar de posicion TwoByte al momento de rellenar con 0s
                            return isValidDirection(true, fillDirectionWithZero(Ipv6,TwoByte)); //Se manda a llamar una funcion que se encarga de rellenar el arreglo en decimal con 0s y retorna un verdadero
                        }else{ //Si no
                            continue; //Solo salta a la siguiente iteracion
                        }
                    }
                }
                return isValidDirection(true, Ipv6); //Una vez que ya guardo en el arreglo la direccion en decimal en twobyte por posicion 
                //Retorna un estado logico verdadero, indicanco que no existe error y ademas guarda la direccion representada en binario en la clase ipv6
            }
        }
        
        /// <summary>
        /// Se encarga de rellenar el arreglo decimal de 0s cuando estos son omitidos por el formato ingresado
        /// </summary>
        /// <param name="Ipv6">Recibe el arreglo con la direccion en decimal que ya tiene registrada</param>
        /// <param name="TwoByte">Recibe el twobyte en el que se quedo escribiendo</param>
        /// <returns>Retorna el mismo arreglo lleno de 0s donde fueron omitidos</returns>
        public static ushort [] fillDirectionWithZero (ushort [] Ipv6, ushort TwoByte){
            for (int i = TwoByte; i < 8; i++)
            {
                Ipv6[i] = 0;
            }
            return Ipv6;
        }

        /// <summary>
        /// Se encarga de regresar el valor correspondiente de cada digito en la direccion
        /// </summary>
        /// <param name="character">Recibe el digito en la posicion de la iteracion correspondiente</param>
        /// <returns>Retorna el valor decimal de dicho digito hexadecimal</returns>
        public static int equalsToDecimal(char character){
            char [] hexaCharacters = new char[16]{'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'}; //Guarda los caracteres permitidos en el sistema hexadecimal
            for (int i = 0; i < hexaCharacters.Length; i++) //Se encarga de recorrer el arreglo de caracteres permitidos
            {
                if(character == hexaCharacters[i]){ //Si el caracter enviado es identico a uno de los del arreglo
                    return i; //retorna la posicion del caracter que es identico a su valor en decimal
                }
            }
            return -1; //Logicamente nunca llega aqui por que la direccion ya fue analizada digito por digito pero sintacticamente el compilador lo pide
        }
        
        /// <summary>
        ///Se encarga de retornar un verdadero para no mostrar de nuevo el menu e imprime el estado en el que se encuentra
        /// </summary>
        /// <param name="status">//Recibe el estado del casting</param>
        /// <param name="ipv4">//Recible el arreglo de la direccion ipv4 ya en decimal</param>
        /// <returns>//Retorna el estado logico de la direccion ingresada por el usuario</returns>
        public static bool isValidDirection(bool status, byte [] ipv4){ 
            addAdressIpv4(ipv4); //Manda llamar funcion que se encarga de agregar y mostrar la direccion ipv4 representada en binario
            WriteLine("is a valid direction\n");
            return true;
        }

        /// <summary>
        /// Se encarga de retornar un verdadero para no mostrar de nuevo el menu e imprime el estado en el que se encuentra
        /// </summary>
        /// <param name="status">//Recibe el estado del casting</param>
        /// <param name="ipv6">//Recible el arreglo de la direccion ipv6 ya en decimal</param>
        /// <returns>Retorna el estado logico de la direccion ingresada por el usuario</returns>
        public static bool isValidDirection(bool status, ushort [] ipv6){
            addAdressIpv6(ipv6); //Manda llamar funcion que se encarga de agregar y mostrar la direccion ipv6 representada en binario
            WriteLine("is a valid direction\n");
            return true;
        }

        /// <summary>
        /// Se encarga de senalar al usuario que su direccion es incorrecta y genera que el menu se muestre de nuevo
        /// </summary>
        /// <param name="status">Recibe el estado del casting</param>
        /// <returns>Retorna el estado logico de la direccion ingresada por el usuario</returns>
        public static bool isValidDirection(bool status){
            WriteLine("is a invalid direction, please try again");
            return false;
        }

        /// <summary>
        /// Se encarga de analizar toda la direccion ipv6 ingresada por el usuario y definir segun las reglas si es correcta o no
        /// </summary>
        /// <param name="input">Recibe la direccion ipv6 que ingreso el usuario</param>
        /// <returns>Retorna el estado logico de la direccion ingresada por el usuario</returns>
        public static bool isValidDirection(string input){
            char [] allowedCharacters = new char[16]{'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'}; //Guarda los caracteres permitidos en el sistema hexadecimal
            input = input.ToUpper(); //Convierte en mayusculas la direccion de ntrada del usuario
            if(input.Length > 39 || input.Length < 5){ //La direccion ingresada es incorrecta por el minimo o maximo tamano de caracteres que tiene una direccion ipv6
                return isValidDirection(false); //Informa al usuario que existe un error y repite el menu
            }else{ //Si no, se sigue analizando para ver si no existen mas errores
                for (int i = 0; i < input.Length; i++) //Ciclo para moverme dentro de la direccion que proporciono el usuario
                {
                    if((i+1) % 5 == 0){ //Si se enceuntra en las posiciones donde se supone que debe existir un operador :
                        if(input[i] != ':'){ //Si no hay un operador en esta posicion (FFFFF)
                            return isValidDirection(false); //La direccion esta mal
                        }else if(input[i] == ':' && (i+1) == input.Length){ //Si hay un operador en esta posicion y solo hay un caracter depues que dicho operador (FFFF:F)
                            return isValidDirection(false); //La direccion esta mal
                        }else if(input[i] == ':' && input[i+1] == ':' && (i+2) == input.Length){ //Si hay un operador en esta posicion y la siguiente posicion lo tiene y esta en la penultima posicion (FFFF::)
                            return true; //Quiere decir que es correcta con el formato que se omiten 0s
                        }else if(input[i] == ':' && input[i+1] != ':' && (i+2) == input.Length){ //Si hay un operador en esta posicion y la siguiente posicion no lo tiene y no esta en la penultima posicion (FFFF::F)
                            return isValidDirection(false); //La direccion esta mal
                        }else{
                            continue; //Salta una iteracion para seguir con el analisis
                        }
                    }
                    
                    if(input[i] == ':'){  //Si hay un operador en una posicion que no debe ir 
                        return isValidDirection(false); //La direccion esta mal
                    }else{ //Si no
                        for (int x = 0; i < allowedCharacters.Length; x++) ///Se encarga de recorrer el arreglo de caracteres permitidos
                        {
                            if(input[i] == allowedCharacters[x]){ //Si un bit es un caracter permitido
                                break; //Se sale de este ciclo
                            }else{ //Si no
                                if((char)input[i] != allowedCharacters[x] && x != 15){ //Si aun no llega al ultimo caracter permitido y no es igual
                                    continue; //Salta a la siguiente iteracion
                                }else{ //Si no, quiere decir que hay un caracter no permitido
                                    return isValidDirection(false); //La direccion esta mal
                                }
                            }
                        }
                    }
                }
                return true; //Si hizo todos los analizis sin ningun error, la direccion es correcta
            }
        }

        /// <summary>
        /// Se encarga de crear y mostrar una direccion ipv4 representada en sistema binario
        /// </summary>
        /// <param name="ipv4">Recibe un arreglo con la direccion en decimal</param>
        public static void addAdressIpv4(byte [] ipv4){     
            Direction<Ipv4> directionsIpv4 = new Direction<Ipv4>(1); //Crea un objeto de la clase generica tipo clase ipv4
            directionsIpv4.Write(new Ipv4(ipv4)); //Escribe una direccion ipv4 representada en binario
            Ipv4 d1 = directionsIpv4.GetItem(0); //Se crea un objeto de la clase ipv4 para poder mostrar su direccion representada en binario
            d1.getDirection(); //Se muestra la direccion
        }

        /// <summary>
        /// Se encarga de crear y mostrar una direccion ipv6 representada en sistema binario
        /// </summary>
        /// <param name="ipv6">Recibe un arreglo con la direccion en decimal</param>
        public static void addAdressIpv6(ushort [] ipv6){
            Direction<Ipv6> directionsIpv6 = new Direction<Ipv6>(1);//Crea un objeto de la clase generica tipo clase ipv6
            directionsIpv6.Write(new Ipv6(ipv6)); //Escribe una direccion ipv6 representada en binario
            Ipv6 d1 = directionsIpv6.GetItem(0); //Se crea un objeto de la clase ipv6 para poder mostrar su direccion representada en binario
            d1.getDirection(); //Se muestra la direccion
        }
    }
}
