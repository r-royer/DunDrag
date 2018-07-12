namespace DunDrag.Models
{
    public class PersonnageSort
    {
        public int PersonnageId { get; set; }

        public Personnage Personnage { get; set; }

        public int SortId { get; set; }

        public Sort Sort { get; set; }

        public bool EstPrepare { get; set; }
    }
}