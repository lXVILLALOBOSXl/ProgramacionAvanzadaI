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

        static List<Figures> addFigures(){
            List<Figures> figures = new List<Figures>
            {
                new Figures(
                    name: "Circle",
                    area: 19.63M,
                    color: "Red"
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
            return figures;
        }

        static void serializeXml(List<Figures> figures){
            var xs = new XmlSerializer(typeof(List<Figures>));
            string path = Combine(CurrentDirectory, "figures.xml");
            using (FileStream stream = File.Create(path))
            {
                xs.Serialize(stream, figures);
            }
            DeserializeXml(path, xs);

        }
        static void serializeJson(List<Figures> figures){
            string js = JsonSerializer.Serialize(figures); 
            string path = Combine(CurrentDirectory, "figures.json"); 
            using(StreamWriter file = File.CreateText(path)){ 
                file.WriteLineAsync(js); 
            }
            DeserializeJson(path);
        }
        static void DeserializeXml(string path, XmlSerializer xs){
            WriteLine("Loading shapes from XML:");
            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {
                var loadFigures = (List<Figures>)xs.Deserialize(xmlLoad);
                foreach (var item in loadFigures)
                {
                    WriteLine($"{item.name} is {item.color} and has an area of {item.area} ");
                }
            }
        }
        static void DeserializeJson(string path){
            string jsonString = File.ReadAllText(path);
            string jsonLoad = JsonSerializer.Deserialize<Figures>(jsonString);
            // foreach (var item in jsonLoad)
            //     {
                    WriteLine($"{jsonLoad} ");
                //}

            // using (FileStream jsonLoad = File.Open(path, FileMode.Open))
            // {
            //     var loadFigures = JsonSerializer.DeserializeAsync<Figures>(jsonLoad);
            //     foreach (var item in loadFigures)
            //     {
            //         WriteLine($"{item.name} is {item.color} and has an area of {item.area} ");
            //     }
            // }
        }

    }
}
