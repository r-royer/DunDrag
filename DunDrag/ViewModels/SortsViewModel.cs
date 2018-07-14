using System.Collections.Generic;
using DunDrag.Models;
using DunDrag.Tech;

namespace DunDrag.ViewModels
{
    public class SortsViewModel
    {
        public PaginatedList<Sort> Sorts { get; set; }

        public Personnage Personnage { get; set; }
    }
}