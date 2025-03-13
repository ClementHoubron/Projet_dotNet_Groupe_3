using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projet.AppClient.Data.Entities
{
    [XmlRoot("Rapport")]
    public class Rapport
    {
        [XmlElement("DateDebut")]
        public DateTime Debut { get; set; }
        [XmlElement("DateFin")]
        public DateTime Fin { get; set; }
        [XmlElement("Client")]
        public Client Client { get; set; }
        [XmlElement("CompteBancaire")]
        public CompteBancaire CompteBancaire { get; set; }
        [XmlArray("Transactions")]
        [XmlArrayItem("Transaction")]
        public List<TransactionBancaire> Transactions { get; set; }
    }
}
