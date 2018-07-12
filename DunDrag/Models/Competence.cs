using System.Collections.Generic;

namespace DunDrag.Models
{
    public class Competence
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public CaracteristiqueEnum CaracteristiqueAssociee { get; set; }

        public List<PersonnageCompetence> PersonnagesCompetences { get; } = new List<PersonnageCompetence>();
    }
}