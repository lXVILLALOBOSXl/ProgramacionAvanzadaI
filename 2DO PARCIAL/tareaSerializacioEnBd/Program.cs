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
            var category = new List<Category>();
            var product = new List<Product>();
            queryingCategories(category, product);
        }

        static void queryingCategories(List<Category> category, List<Product> product){
            using (var db = new Northwind()){
                IQueryable<Category> cats = db.Categories;
                IQueryable<Product> prods = db.Products;
                foreach (Category c in cats){
                    category.Add(c);
                }
                foreach (Product p in prods){
                    product.Add(p);
                }
                serializeWithXml(category,product);
                serializeWithJson(category,product);
                serializeWithBinary(category,product);
            }
        }
        static void serializeWithXml(List<Category> category, List<Product> product){
            var xsC = new XmlSerializer(typeof(List<Category>));
            var xsP = new XmlSerializer(typeof(List<Product>));
            string pathC = Combine(CurrentDirectory, "categories.xml");
            string pathP = Combine(CurrentDirectory, "products.xml");
            if(File.Exists(pathC)) File.Delete(pathC); 
            if(File.Exists(pathP)) File.Delete(pathP); 
            using (FileStream stream = File.Create(pathC)){
                xsC.Serialize(stream, category);
            }
            using (FileStream stream = File.Create(pathP)){
                xsP.Serialize(stream, product);
            }
        }

        static async void serializeWithJson(List<Category> category, List<Product> product){
            string jsC = JsonSerializer.Serialize(category);
            string jsP = JsonSerializer.Serialize(product);
            string pathC = Combine(CurrentDirectory, "categories.json");
            string pathP = Combine(CurrentDirectory, "products.json");
            if(File.Exists(pathC)) File.Delete(pathC); 
            if(File.Exists(pathP)) File.Delete(pathP);
            using(StreamWriter file = File.CreateText(pathC)){
                await file.WriteLineAsync(jsC);
            }
            using(StreamWriter file = File.CreateText(pathP)){
                await file.WriteLineAsync(jsP);
            }
        }

        static void serializeWithBinary(List<Category> category, List<Product> product){
            string pathC = Combine(CurrentDirectory, "categories.bin");
            string pathP = Combine(CurrentDirectory, "products.bin");
            BinaryFormatter bsC = new BinaryFormatter();
            BinaryFormatter bsP = new BinaryFormatter();
            if(File.Exists(pathC)) File.Delete(pathC); 
            if(File.Exists(pathP)) File.Delete(pathP);
            using (FileStream stream = File.Create(pathC)){
                bsC.Serialize(stream, category);
            }
            using (FileStream stream = File.Create(pathP)){
                bsC.Serialize(stream, product);
            }
        }
    }
}
