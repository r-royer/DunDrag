using System.Collections.Generic;

namespace DunDrag.Models
{
    public class Caracteristique
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public CaracteristiqueEnum CaracteristiqueEnum { get; set; }

        public List<PersonnageCaracteristique> PersonnagesCaracteristiques { get; } = new List<PersonnageCaracteristique>();
    }
}