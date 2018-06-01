using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace mcLittLe.Models
{
    [Serializable]
    [XmlRoot("product"), XmlType("product")]
    public class product
    {
        public int productId { get; set; }
        public long EAN { get; set; }
        public string title { get; set; }
        public string brand { get; set; }
        public string shortDesc { get; set; }
        public string fullDesc { get; set; }
        public string imageLink { get; set; }
        public string weight { get; set; }
        public float price { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public string subsubCategory { get; set; }
    }
}