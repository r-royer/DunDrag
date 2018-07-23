using System.Collections.Generic;

namespace DunDrag.Models
{
    public class Classe
    {
        public int Id { get; set; }

        public string Cle { get; set; }

        public string Nom { get; set; }

        public List<SortClasse> SortsClasses { get; } = new List<SortClasse>();
    }
}