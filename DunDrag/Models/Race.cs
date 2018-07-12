using System.ComponentModel.DataAnnotations;

namespace DunDrag.Models
{
    public enum Race
    {
        Elfe,

        Halfelin,

        Humain,

        Nain,
        [Display(Name = "Demi-Elfe")]
        DemiElfe,

        [Display(Name = "Demi-Orque")]
        DemiOrque,

        [Display(Name = "Drakéide")]
        Drakeide,

        Gnome,

        Tieffelin
    }
}