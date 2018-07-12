using System.Collections.Generic;

namespace DunDrag.Models
{
    public class PersonnageCaracteristique
    {
        public int CaracteristiqueId { get; set; }

        public Caracteristique Caracteristique { get; set; }

        public int PersonnageId { get; set; }

        public Personnage Personnage { get; set; }

        public int Valeur { get; set; }

        public int? ValeurTemporaire { get; set; }
    }
}