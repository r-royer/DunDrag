namespace DunDrag.Models
{
    public class PersonnageLangue
    {
        public int LangueId { get; set; }

        public Langue Langue { get; set; }

        public int PersonnageId { get; set; }

        public Personnage Personnage { get; set; }
    }
}