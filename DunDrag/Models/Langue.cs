using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DunDrag.Models
{
    public class Langue
    {
        public int  Id { get; set; }

        public string Nom { get; set; }

        public List<PersonnageLangue> PersonnagesLangues { get; } = new List<PersonnageLangue>();
    }
}