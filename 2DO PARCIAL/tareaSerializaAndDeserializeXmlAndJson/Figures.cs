using System;
using System.Xml.Serialization;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tareaSerializaAndDeserializeXmlAndJson
{
    /// <summary>
    /// Estructura para las figuras
    /// </summary>
    public struct Figures
    {
        /// <summary>
        /// Constructor se encarga de crear e inicializar las instancias de la estructura
        /// </summary>
        /// <param name="name">Recibe el nombre de la instancia de la figura</param>
        /// <param name="area">Recibe el area de la instancia de la figura</param>
        /// <param name="color">Recibe el color de la instancia de la figura</param>
        public Figures(string name, decimal area, string color){
            this.name = name; //Se asigna la propiedad a la instancia que se crea
            this.area = area;
            this.color = color;
        }
        [XmlAttribute("name")] //Asignacion para el archivo XMl
        public string name { get; set; } //propiedad para el nombre
        [XmlAttribute("area")]
        public decimal area { get; set; } //propiedad para el area
        [XmlAttribute("color")]
        public string color { get; set; } //propiedad para el color 
    }
}