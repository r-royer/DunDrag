using System.Collections.Generic;

namespace DunDrag.Models
{
    public class PersonnageCompetence
    {
        public int CompetenceId { get; set; }

        public Competence Competence { get; set; }

        public int PersonnageId { get; set; }

        public Personnage Personnage { get; set; }

        public bool Maitrise { get; set; }

        public bool Expertise { get; set; }
    }
}