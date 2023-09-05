using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercise02 {
    [XmlRoot("novelist")]
    [DataContract(Name = "novelist")]
    public class Novelist {

        [XmlElement("name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [XmlElement("birth")]
        [DataMember(Name = "birth")]
        public DateTime Birth { get; set; }

        [XmlElement("masterpieces")]
        [DataMember(Name = "masterpieces")]
        public string[] Masterpieces { get; set; }
    }
}
