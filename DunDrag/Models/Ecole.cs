using System.ComponentModel.DataAnnotations;

namespace DunDrag.Models
{
    public enum Ecole
    {
        Toutes = -1,

        Abjuration,

        Divination,

        Enchantement,

        Evocation,

        Illusion,

        Invocation,

        [Display(Name = "Nécromancie")]
        Necromancie,

        Transmutation
    }
}