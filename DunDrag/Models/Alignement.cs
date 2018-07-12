using System.ComponentModel.DataAnnotations;

namespace DunDrag.Models
{
    public enum Alignement
    {
        [Display(Name = "Loyal bon")]
        LoyalBon,

        [Display(Name = "Neutre bon")]
        NeutreBon,

        [Display(Name = "Chaotique bon")]
        ChaotiqueBon,

        [Display(Name = "Loyal neutre")]
        LoyalNeutre,

        Neutre,

        [Display(Name = "Chaotique neutre")]
        ChaotiqueNeutre,

        [Display(Name = "Loyal mauvais")]
        LoyalMauvais,

        [Display(Name = "Neutre mauvais")]
        NeutreMauvais,

        [Display(Name = "Chaotique mauvais")]
        ChaotiqueMauvais
    }
}