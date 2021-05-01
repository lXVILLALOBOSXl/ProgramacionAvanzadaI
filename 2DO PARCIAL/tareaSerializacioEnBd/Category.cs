using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tareaSerializacioEnBd
{
    
    [Index(nameof(CategoryName), Name = "CategoryName")]
    [Serializable] //Importante indicar al serializador binario cual es la clase serializable
    /// <summary>
    /// /// Se encarga de almacenar en tipo Objeto las rows que tiene una tabla (Category) dentro de la base de datos  (Northwind)
    /// </summary>
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("CategoryID")]
        [XmlAttribute("CategoryID")] //Atributos para el archivo XML
        public long CategoryId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar (15)")]
        [XmlAttribute("CategoryName")]
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        [XmlAttribute("Description")]
        public string Description { get; set; }
        [Column(TypeName = "image")]
        [XmlAttribute("Picture")]
        public byte[] Picture { get; set; }
        [InverseProperty(nameof(Product.Category))]
        [XmlIgnore] //Importante indicar que no serialize el apartado Products ya que es un ICollection FK en XML
        [JsonIgnore] //Importante indicar que no serialize el apartado Products ya que es un ICollection FK en JSON
        [field:NonSerialized] //Importante indicar que no serialize el apartado Products ya que es un ICollection FK en Binary
        public virtual ICollection<Product> Products { get; set; }
    }

}