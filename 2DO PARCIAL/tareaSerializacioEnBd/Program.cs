using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace tareaSerializacioEnBd
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> category = new List<Category>();
            queryingCategories(category);
        }

        static void queryingCategories(List<Category> category){
            using (var db = new Northwind()){
                IQueryable<Category> cats = db.Categories
                .Include(c => c.Products); 
                foreach (Category c in cats){
                    category.Add(c);
                }
                serializeWithXml(category);
            }
        }
        static void serializeWithXml(List<Category> category){
            var xs = new XmlSerializer(typeof(List<Category>));
            // string path = Combine(CurrentDirectory, "people.xml");
            string path = ("/Users/luisvillalobos/Documents/ProgramacionAvanzadaI/2DO PARCIAL/tareaSerializacioEnBd/categoriesAndProducts.xml");
            using (FileStream stream = File.Create(path)){
                xs.Serialize(stream, category);
            }
        }
    }
}
