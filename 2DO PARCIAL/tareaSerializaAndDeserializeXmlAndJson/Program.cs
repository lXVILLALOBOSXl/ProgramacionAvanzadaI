using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace tareaSerializaAndDeserializeXmlAndJson
{
    class Program
    {
        static void Main(string[] args)
        {
            serializeXml(addFigures());
            serializeJson(addFigures());
        }

        /// <summary>
        /// Se encarga de agregar en una lista tipo structure objetos tipo figures
        /// </summary>
        /// <returns>Retorna la lista llena de objetos tipo figures</returns>
        static List<Figures> addFigures(){
            List<Figures> figures = new List<Figures> //Declaracion de objeto lista tipo figura, guarda objetos de la estrucura figures
            {
                new Figures( //Declaracion de instancia de la estructura Figures
                    name: "Circle", //Argumento nombre para constructor
                    area: 19.63M, //Argumento area para constructor
                    color: "Red" //Argumento color para constructor
                ),
                new Figures(
                    name: "Rectangle",
                    area: 200.00M,
                    color: "Blue"
                ),
                new Figures(
                    name: "Circle",
                    area: 201.6M,
                    color: "Green"
                ),
                new Figures(
                    name: "Circle",
                    area: 475.29M,
                    color: "Purple"
                ),
                new Figures(
                    name: "Rectangle",
                    area: 810.00M,
                    color: "Blue"
                )
            };
            return figures; //retorna la lista de figuras una vez que esta llena
        }

        /// <summary>
        /// Se encarga de crear y serializar las figuras en un archivo XML y se manda a llamar la funcion que se encarga de deserializar dicho archivo serializado
        /// </summary>
        /// <param name="figures">Recibe la lista tipo figuras</param>
        static void serializeXml(List<Figures> figures){
            var xs = new XmlSerializer(typeof(List<Figures>)); //Instancia del serializador XML
            string path = Combine(CurrentDirectory, "figures.xml"); //Ruta para crear el archivo xml
            using (FileStream stream = File.Create(path)) //Se crea el archivo
            {
                xs.Serialize(stream, figures); //La informacion serialiada se guarda en el archivo
            }
            DeserializeXml(path, xs); //Se manda a llamar la deserializacion con la ruta del archivo y la instancia del serializador

        }
        /// <summary>
        /// Se encarga de crear y serializar las figuras en un archivo Json y se manda a llamar la funcion que se encarga de deserializar dicho archivo serializado
        /// </summary>
        /// <param name="figures">Recibe la lista tipo figuras</param>
        static void serializeJson(List<Figures> figures){
            string js = JsonSerializer.Serialize(figures); //Guarda la informacion serializada en formato json
            string path = Combine(CurrentDirectory, "figures.json"); //Rut para crear el archivo Json
            using(StreamWriter file = File.CreateText(path)){  //Se crea el archivo
                file.WriteLineAsync(js); //Se escribe en el archivo el resultado de la serializacion
            }
            DeserializeJson(js); //Se manda a llamar la deserializacion con la serialzacion en json como argumento
        }
        /// <summary>
        /// Se encarga de deserializar la informacion XML e imprimir dicha deserializacion en consola
        /// </summary>
        /// <param name="path">Recibe la ruta del archivo XML</param>
        /// <param name="xs">Recibe la instancia del objeto serializador XML</param>
        static void DeserializeXml(string path, XmlSerializer xs){
            WriteLine("\n Loading shapes from XML:");
            using (FileStream xmlLoad = File.Open(path, FileMode.Open)) //Se abre el archivo
            {
                var loadFigures = (List<Figures>)xs.Deserialize(xmlLoad); //El archivo XML se deserializa y se guarda en una lista
                foreach (var item in loadFigures)
                {
                    WriteLine($"\n {item.name} is {item.color} and has an area of {item.area}"); //Se imprime la deserializacion del archivo XML
                }
            }
            WriteLine($"\n -----------------------------------------------------------------------------");
        }
        /// <summary>
        ///Se encarga de deserializar la informacion Json e imprimir dicha deserializacion en consola
        /// </summary>
        /// <param name="js">Recibe la serializacion en formato json</param>
        static void DeserializeJson(string js){
            var jsonLoad = JsonSerializer.Deserialize<List<Figures>>(js); //Guarda la informacion serializada
            WriteLine("\n Loading shapes from Json:");
            foreach (var item in jsonLoad)
            {
                WriteLine($"\n {item.name} is {item.color} and has an area of {item.area}"); //Se imprime la deserializacion del archivo Json
            }
            WriteLine();
        }

    }
}
