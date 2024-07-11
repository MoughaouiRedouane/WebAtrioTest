using System.ComponentModel.DataAnnotations.Schema;

namespace WebAtrioTest.DataBaseCommunication.Model
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime DateDeNaissance { get; set; }

        public ICollection<Emploi> Emplois { get; set; }

        [NotMapped]
        public int Age { get; set; }

    }
}
