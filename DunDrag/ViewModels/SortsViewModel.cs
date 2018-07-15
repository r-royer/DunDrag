using DunDrag.Models;
using DunDrag.Tech;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DunDrag.ViewModels
{
    public class SortsViewModel
    {
        public int? PageIndex { get; set; }

        public string SortOrder { get; set; }

        public Ecole? Ecole { get; set; }

        public int? Classe { get; set; }

        public int? NiveauMin { get; set; }
        
        public int? NiveauMax { get; set; }

        public string Recherche { get; set; }

        public string NomSortParam { get; set; }

        public string NiveauSortParam { get; set; }

        public PaginatedList<Sort> Sorts { get; set; }

        public int? PersonnageId { get; set; }

        public Personnage Personnage { get; set; }

        public SelectList Classes { get; set; }
    }
}