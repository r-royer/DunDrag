using System.ComponentModel.DataAnnotations;

namespace DunDrag.Models
{
    public enum Ecole
    {
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