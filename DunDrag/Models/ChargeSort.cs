using System.ComponentModel.DataAnnotations;

namespace DunDrag.Models
{
    public class ChargeSort
    {
        public int Id { get; set; }

        [Range(1, 9)]
        public int NiveauSort { get; set; }

        public int ChargesTotales { get; set; }

        public int ChargesRestantes { get; set; }
    }
}