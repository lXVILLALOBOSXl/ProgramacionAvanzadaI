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
    [Serializable]
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            //this.Products = new List<Product>();
        }

        [Key]
        [Column("CategoryID")]
        [XmlAttribute("CategoryID")]
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
        [XmlIgnore]
        [JsonIgnore]
        [field:NonSerialized]
        public virtual ICollection<Product> Products { get; set; }
    }

}