using System;
using static System.Console;

namespace _1erTareaImprimiendoEnConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            //Entendí que una region es una sentencia que el compilador reconoce como una seccion dentro del programa,
            //función, metódo, etc. Este nos permite una mejor legibilidad en el codigo y permite segmentarlo.
            #region primitiveVariablesMaxAndMinValues
                //Margen posterior de la tabla
                WriteLine("----------------------------------------------------------------------------------------");
                //El caracter $ sirve para indicarle al compilador que dentro de nuestro string vamos a utilizar expresiones
                //e incluso operandos dentro de mis llaves{}
                //El formato consiste en 2 parametros, el 1 es para el argumento o lo que se va imprimir y el segundo es
                //para segmentar los espacios de escritura, los negativos (-8) parte desde la derecha hacia la izquierda
                //y los positivos desde la izquierda hasta la derecha
                WriteLine($"{"Type",-8}{"Byte(s) of memory"}{"Min",18}{"Max",45}");
                //Margen inferior de la primera fila
                WriteLine("----------------------------------------------------------------------------------------");
                //La funcion sizeof() debe recibir un parametro tipo objeto y retorna en bytes la capacidad que puede
                //almacenar. 
                //El método MaxValue sirve para regresar en valor decimal el maximo valor que puede tomar el objeto
                //con el que ha sido llamado
                //El método MinValue sirve para regresar en valor decimal el minimo valor que puede tomar el objeto
                //con el que ha sido llamado
                WriteLine($"{"sbyte",-8}{sizeof(sbyte)}{sbyte.MinValue,34}{sbyte.MaxValue,45}");
                WriteLine($"{"byte",-8}{sizeof(byte)}{byte.MinValue,34}{byte.MaxValue,45}");
                WriteLine($"{"short",-8}{sizeof(short)}{short.MinValue,34}{short.MaxValue,45}");
                WriteLine($"{"ushort",-8}{sizeof(ushort)}{ushort.MinValue,34}{ushort.MaxValue,45}");
                WriteLine($"{"int",-8}{sizeof(int)}{int.MinValue,34}{int.MaxValue,45}");
                WriteLine($"{"uint",-8}{sizeof(uint)}{uint.MinValue,34}{uint.MaxValue,45}");
                WriteLine($"{"long",-8}{sizeof(long)}{long.MinValue,34}{long.MaxValue,45}");
                WriteLine($"{"ulong",-8}{sizeof(ulong)}{ulong.MinValue,34}{ulong.MaxValue,45}");
                WriteLine($"{"float",-8}{sizeof(float)}{float.MinValue,34}{float.MaxValue,45}");
                WriteLine($"{"double",-8}{sizeof(double)}{double.MinValue,34}{double.MaxValue,45}");
                WriteLine($"{"decimal",-8}{sizeof(decimal)}{decimal.MinValue,33}{decimal.MaxValue,45}");
                //Margen inferior de la tabla
                WriteLine("----------------------------------------------------------------------------------------");
            #endregion
        }
    }
}
