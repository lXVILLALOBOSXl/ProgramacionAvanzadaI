using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
namespace tareaSerializacioEnBd
{
    [Index(nameof(CategoryId), Name = "CategoriesProducts")]
    [Index(nameof(CategoryId), Name = "CategoryID")]
    [Index(nameof(ProductName), Name = "ProductName")]
    [Index(nameof(SupplierId), Name = "SupplierID")]
    [Index(nameof(SupplierId), Name = "SuppliersProducts")]
    public class Product
    {
        [Key]
        [Column("ProductID")]
        [XmlAttribute("ProductId")]
        public long ProductId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar (40)")]
        [XmlAttribute("ProductName")]
        public string ProductName { get; set; }
        [Column("SupplierID", TypeName = "int")]
        [XmlAttribute("SupplierId")]
        public long? SupplierId { get; set; }
        [Column("CategoryID", TypeName = "int")]
        [XmlAttribute("CategoryId")]
        public long? CategoryId { get; set; }
        [Column(TypeName = "nvarchar (20)")]
        [XmlAttribute("QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }
        [Column(TypeName = "money")]
        [XmlAttribute("UnitPrice")]
        public byte[] UnitPrice { get; set; }
        [Column(TypeName = "smallint")]
        [XmlAttribute("UnitsInStock")]
        public long? UnitsInStock { get; set; }
        [Column(TypeName = "smallint")]
        [XmlAttribute("UnitsOnOrder")]
        public long? UnitsOnOrder { get; set; }
        [Column(TypeName = "smallint")]
        [XmlAttribute("ReorderLevel")]
        public long? ReorderLevel { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        [XmlAttribute("Discontinued")]
        public byte[] Discontinued { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
    }

}