using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace tareaSerializacioEnBd
{
    class Program
    {
        static void Main(string[] args)
        {
            var category = new List<Category>(); //Almacena un arreglo dinamico de objetos tipo category (cada row de una consulta)
            var product = new List<Product>(); //Almacena un arreglo dinamico de objetos tipo product (cada row de una consulta)
            queryingCategories(category, product); //Se envian los 2 arreglos de objetos para trabajar con ellos
        }

        /// <summary>
        /// Realiza las querys, llena los arreglos de objetos con los resultados de dichas querys y manda a llamar a las funciones que realizan las serializaciones
        /// </summary>
        /// <param name="category">Lista de objetos del tipo de la tabla a la que se va hacer la consulta (category)</param>
        /// <param name="product">Lista de objetos del tipo de la tabla a la que se va hacer la consulta (category)</param>
        static void queryingCategories(List<Category> category, List<Product> product){
            using (var db = new Northwind()){ //Se conecta a la base de datos
                IQueryable<Category> cats = db.Categories; //Se hace la query SELECT * FROM CATEGORY y se guarda en cats
                IQueryable<Product> prods = db.Products; //Se hace la query SELECT * FROM PRODUCTS y se guarda en prods
                foreach (Category c in cats){ //Recorremos entre los rows de la query category
                    category.Add(c); //Agregamos el objeto category de la row a la lista
                }
                foreach (Product p in prods){ //Recorremos entre los rows de la query products
                    product.Add(p); //Agregamos el objeto products de la row a la lista
                }
                serializeWithXml(category,product); //Mandamos a llamar serializar con XML y mandamos la lista llena
                serializeWithJson(category,product); //Mandamos a llamar serializar con XML y mandamos la lista llena
                serializeWithBinary(category,product); //Mandamos a llamar serializar con XML y mandamos la lista llena
            }
        }
        /// <summary>
        /// Se encarga de serializar la informacion y crear un documento en XML
        /// </summary>
        /// <param name="category">Lista de objetos llena del tipo de la tabla a la que se hizo la consulta (category)</param>
        /// <param name="product">Lista de objetos llena del tipo de la tabla a la que se hizo la consulta (products)</param>
        static void serializeWithXml(List<Category> category, List<Product> product){
            var xsC = new XmlSerializer(typeof(List<Category>)); //Objeto xmlserializer tipo lista de objetos category (funciona para serializar)
            var xsP = new XmlSerializer(typeof(List<Product>)); //Objeto xmlserializer tipo lista de objetos category (funciona para serializar)
            string pathC = Combine(CurrentDirectory, "categories.xml"); //Ruta, nombre y extension donde se guardara la serializacion de categorias
            string pathP = Combine(CurrentDirectory, "products.xml"); //Ruta, nombre y extension donde se guardara la serializacion de productos
            if(File.Exists(pathC)) File.Delete(pathC); //En caso de que ya exista dicho archivo de categorias se elimina
            if(File.Exists(pathP)) File.Delete(pathP); ///En caso de que ya exista dicho archivo de categorias se elimina
            using (FileStream stream = File.Create(pathC)){ //Se crea, abre el archivo category
                xsC.Serialize(stream, category); //Se serializa la lista y se guarda en el archivo category
            }
            using (FileStream stream = File.Create(pathP)){ //Se crea, abre el archivo category
                xsP.Serialize(stream, product); //Se serializa la lista y se guarda en el archivo product
            }
        }

        /// <summary>
        /// Se encarga de serializar la informacion y crear un documento en JSON, es asyncrona por que primero se hace la serializacion y despues se escribe dicha serializacion
        /// </summary>
        /// <param name="category">Lista de objetos llena del tipo de la tabla a la que se hizo la consulta (category)</param>
        /// <param name="product">Lista de objetos llena del tipo de la tabla a la que se hizo la consulta (products)</param>
        /// <returns>Retorna hasta que el proceso termine</returns>
        static async void serializeWithJson(List<Category> category, List<Product> product){
            string jsC = JsonSerializer.Serialize(category); //Se realiza la serializacion de category y se guarda en un string
            string jsP = JsonSerializer.Serialize(product); //Se realiza la serializacion de products y se guarda en un string
            string pathC = Combine(CurrentDirectory, "categories.json"); //Ruta, nombre y extension donde se guardara la serializacion de categorias
            string pathP = Combine(CurrentDirectory, "products.json"); //Ruta, nombre y extension donde se guardara la serializacion de productos
            if(File.Exists(pathC)) File.Delete(pathC); //En caso de que ya exista dicho archivo de categorias se elimina
            if(File.Exists(pathP)) File.Delete(pathP); ///En caso de que ya exista dicho archivo de categorias se elimina
            using(StreamWriter file = File.CreateText(pathC)){ //Se crea, abre el archivo category
                await file.WriteLineAsync(jsC); //Se escribe la serializacion en el archivo category
            }
            using(StreamWriter file = File.CreateText(pathP)){ //Se crea, abre el archivo products
                await file.WriteLineAsync(jsP); //Se escribe la serializacion en el archivo products
            }
        }
        /// <summary>
        /// Se encarga de serializar la informacion y crear un documento en Binary (YA NO ES RECOMENDADO, OBSOLETO)
        /// </summary>
        /// <param name="category">Lista de objetos llena del tipo de la tabla a la que se hizo la consulta (category)</param>
        /// <param name="product">Lista de objetos llena del tipo de la tabla a la que se hizo la consulta (products)</param>
        static void serializeWithBinary(List<Category> category, List<Product> product){
            string pathC = Combine(CurrentDirectory, "categories.bin"); //Ruta, nombre y extension donde se guardara la serializacion de categorias
            string pathP = Combine(CurrentDirectory, "products.bin"); //Ruta, nombre y extension donde se guardara la serializacion de productos
            BinaryFormatter bsC = new BinaryFormatter(); //Objeto  category para poder serializar en modo binario
            BinaryFormatter bsP = new BinaryFormatter(); //Objeto  products para poder serializar en modo binario
            if(File.Exists(pathC)) File.Delete(pathC); //En caso de que ya exista dicho archivo de categorias se elimina
            if(File.Exists(pathP)) File.Delete(pathP); ///En caso de que ya exista dicho archivo de categorias se elimina
            using (FileStream stream = File.Create(pathC)){ //Se crea, abre el archivo category
                bsC.Serialize(stream, category); //Se serializa la lista y se guarda en el archivo category
            }
            using (FileStream stream = File.Create(pathP)){ //Se crea, abre el archivo products
                bsC.Serialize(stream, product); //Se serializa la lista y se guarda en el archivo product
            }
        }
    }
}
