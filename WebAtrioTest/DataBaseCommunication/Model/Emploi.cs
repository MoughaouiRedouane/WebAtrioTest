using System.ComponentModel.DataAnnotations.Schema;

namespace WebAtrioTest.DataBaseCommunication.Model
{
    public class Emploi
    {
        public int Id { get; set; }

        public string NomEntreprise { get; set; }
        public string PosteOccupe { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        [ForeignKey("Personne")]
        public int PersonneId { get; set; }
     
        public Personne Personne { get; set; }
    }
}
