using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.IO.Path;
using static System.Environment;
using System.Text;
using System.IO.Compression;

namespace tareaCompresionBrotli
{
    class Program
    {
        static string[] names = new string [] {
                "Luis", "Ana", "Vicente", "Tiberio", "Layla", "Rivas" , "Diego1" , "Diego2"
        }; //Guarda la informacion que se guarda en xml y despues se comprime en formato brotli
        static void Main(string[] args)
        {
            WorkWithCompression(); 
        }

        /// <summary>
        /// Se encarga de comprimir, descomrpimir, crear y leer el archivo xml
        /// </summary>
        static void WorkWithCompression(){
           
            string brFilePath = Combine(CurrentDirectory, "streams.br"); //Se guarda la direccion del archivo
            FileStream brFile = File.Create(brFilePath); //Se crea el archivo

            // Comprimir
            using (BrotliStream compressor = new BrotliStream(brFile, CompressionMode.Compress)){ //Hace todo lo que esta dentro y despues comprime el archivo en brotli
                using (XmlWriter xmlBr = XmlWriter.Create(compressor)){ //Hace todo lo que esta dentro y despues crea el archivo xml
                    xmlBr.WriteStartDocument(); //inicia el documento XML
                    // Define el elemento raiz en el documento xml
                    xmlBr.WriteStartElement("Students"); //Etiqueta en documento xml
                    foreach (string item in names){ //Escribe elementos en el archivo xml
                        xmlBr.WriteElementString("Student", item);
                    }
                    foreach (string item in names){ //Escribe elementos en el archivo xml
                        xmlBr.WriteElementString("AnotherPeople", item);
                    } 
                    xmlBr.WriteStartElement("Info"); //Etiqueta en documento xml
                    foreach (string item in names){ //Escribe elementos en el archivo xml
                        xmlBr.WriteElementString("Name", item);
                        xmlBr.WriteElementString("Phone", "");
                        xmlBr.WriteElementString("Address", "");
                    }
                    xmlBr.WriteEndDocument(); //finaliza el documento XML
                }
            }

            WriteLine($"{brFilePath} contains {new FileInfo(brFilePath).Length} bytes"); //Muestra el tamaño del documento en bytes
            WriteLine("The compressed contents :");
            WriteLine(File.ReadAllText(brFilePath)); //Muestra lo que tiene el documento comprimido
            // read the compress file
            WriteLine("Readig the compressed XML File");
            brFile = File.Open(brFilePath, FileMode.Open); //Abrimos el archivo

            // Descomprmir
            using (BrotliStream decompressor = new BrotliStream(brFile, CompressionMode.Decompress)){ //Hace todo lo que esta dentro y despues descomprime el archivo brotli
                using (XmlReader reader = XmlReader.Create(decompressor)){ //Hace todo lo que esta dentro y despues crea el archivo xml
                    while(reader.Read()) { //Leemos el archivo xml abierto
                        // Check element by string
                        if((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Student")){ //En las etiquetas de estudiante
                            reader.Read(); //Leemos el texto
                            WriteLine($"{reader.Value}"); //Mostramos el elemento
                        } 
                    }
                }
            }
        }
    }
}
