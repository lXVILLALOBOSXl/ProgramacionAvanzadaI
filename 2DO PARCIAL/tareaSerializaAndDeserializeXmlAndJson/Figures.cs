using System;
using System.Xml.Serialization;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tareaSerializaAndDeserializeXmlAndJson
{
    public struct Figures
    {
        public Figures(string name, decimal area, string color){
            this.name = name;
            this.area = area;
            this.color = color;
        }
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("area")]
        public decimal area { get; set; }
        [XmlAttribute("color")]
        public string color { get; set; }
    }
}