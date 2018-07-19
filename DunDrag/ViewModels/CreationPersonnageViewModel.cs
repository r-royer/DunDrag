using System.Collections.Generic;
using DunDrag.Models;
using Microsoft.EntityFrameworkCore;

namespace DunDrag.ViewModels
{
    public class CreationPersonnageViewModel
    {
        public int Etape { get; set; }

        public Personnage Personnage { get; set; }

        public List<Race> Races { get; set; }

        public List<Classe> Classes { get; set; }

        public List<Historique> Historiques { get; set; }
    }
}