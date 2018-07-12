using System.ComponentModel.DataAnnotations;
using DunDrag.Data;

namespace DunDrag.Models
{
    public class Sort
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        [Range(0, 9)]
        public int Niveau { get; set; }

        [Required]
        public Ecole Ecole { get; set; }

        [Required]
        public string Incantation { get; set; }

        [Required]
        public bool Rituel { get; set; }

        public string Portee { get; set; }

        public string Composantes { get; set; }

        public string Duree { get; set; }

        [Required]
        public string Description { get; set; }

        public string Resume { get; set; }
    }
}