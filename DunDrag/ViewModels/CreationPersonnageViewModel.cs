using System.Collections.Generic;
using DunDrag.Models;

namespace DunDrag.ViewModels
{
    public class CreationPersonnageViewModel
    {
        public int Etape { get; set; }

        public Personnage Personnage { get; set; }

        public List<Race> Races { get; set; }
    }
}