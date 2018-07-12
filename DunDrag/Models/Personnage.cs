using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DunDrag.Models
{
    public class Personnage
    {
        public int Id { get; set; }

        public Classe Classe { get; set; }

        public Race Race { get; set; }

        [Range(0, int.MaxValue)]
        public int Experience { get; set; }

        public int ClasseArmure { get; set; }

        public int Initiative { get; set; }

        public int Vitesse { get; set; }

        public int PvMaximum { get; set; }

        public int? PvTemporaires { get; set; }

        public int PvActuels { get; set; }

        public int DesDeVie { get; set; }

        [Required]
        public string Nom { get; set; }

        [Range(1, 20)]
        public int Niveau { get; set; }

        [Range(0, 5)]
        [DataType(DataType.Custom)]
        public decimal Taille { get; set; }

        [Range(1, 999)]
        public int Age { get; set; }

        public string Yeux { get; set; }

        public string Peau { get; set; }

        public string Cheveux { get; set; }

        [Range(0, 500)]
        [DataType(DataType.Custom)]
        public decimal Poids { get; set; }

        public string Historique { get; set; }

        public string NomJoueur { get; set; }

        public Alignement Alignement { get; set; }

        public string TraitsDePersonnalite { get; set; }

        public string Ideaux { get; set; }

        public string Liens { get; set; }

        public string Defauts { get; set; }

        public int PiecesCuivre { get; set; }

        public int PiecesArgent { get; set; }

        public int PiecesEthereum { get; set; }

        public int PiecesOr { get; set; }

        public int PiecesPlatine { get; set; }

        public int DesDeSauvegardeContreSorts { get; set; }

        public int BonusAttaqueAvecSort { get; set; }

        public List<PersonnageLangue> PersonnagesLangues { get; } = new List<PersonnageLangue>();

        public List<PersonnageSort> PersonnagesSorts { get; } = new List<PersonnageSort>();

        public List<PersonnageCompetence> PersonnagesCompetences { get; } = new List<PersonnageCompetence>();

        public List<PersonnageCaracteristique> PersonnagesCaracteristiques { get; } = new List<PersonnageCaracteristique>();
    }
}