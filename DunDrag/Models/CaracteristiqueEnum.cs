using System.ComponentModel.DataAnnotations;

namespace DunDrag.Models
{
    public enum CaracteristiqueEnum
    {
        Force,

        [Display(Name = "Dextérité")]
        Dexterite,

        Constitution,

        Intelligence,

        Sagesse,

        Charisme
    }
}