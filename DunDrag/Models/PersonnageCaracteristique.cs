using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DunDrag.Models
{
    public class PersonnageCaracteristique
    {
        public int CaracteristiqueId { get; set; }

        public virtual Caracteristique Caracteristique { get; set; }

        public int PersonnageId { get; set; }

        public virtual Personnage Personnage { get; set; }

        public int Valeur { get; set; }

        public int? ValeurTemporaire { get; set; }

        [NotMapped]
        public int Modifieur
        {
            get
            {
                if (Valeur >= 20)
                {
                    return 5;
                }

                if (Valeur >= 18)
                {
                    return 4;
                }

                if (Valeur >= 16)
                {
                    return 3;
                }

                if (Valeur >= 14)
                {
                    return 2;
                }

                if (Valeur >= 12)
                {
                    return 1;
                }

                if (Valeur >= 10)
                {
                    return 0;
                }

                if (Valeur >= 8)
                {
                    return -1;
                }

                if (Valeur >= 6)
                {
                    return -2;
                }

                if (Valeur >= 4)
                {
                    return -3;
                }

                return -4;
            }
        }
    }
}