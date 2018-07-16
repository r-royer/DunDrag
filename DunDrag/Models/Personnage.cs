using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DunDrag.Models
{
    public class Personnage
    {
        private static readonly int[] TableauXp = {
            300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000,
            225000, 265000, 305000, 355000
        };

        public int Id { get; set; }

        public Classe Classe { get; set; }

        public Race Race { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Expérience")]
        public int Experience { get; set; }

        [NotMapped]
        public string ExperienceEnCours => string.Format("{0} / {1}", Experience, TableauXp[Niveau]);

        [Display(Name = "Classe d'armure")]
        public int ClasseArmure { get; set; }

        public int Initiative { get; set; }

        public int Vitesse { get; set; }

        [Display(Name = "Points de vie maximums")]
        public int PvMaximum { get; set; }

        [Display(Name = "Points de vie temporaires")]
        public int? PvTemporaires { get; set; }

        [Display(Name = "Points de vie actuels")]
        public int PvActuels { get; set; }

        public int DesDeVieActuels { get; set; }

        [Display(Name = "Total")]
        public int DesDeVieTotal { get; set; }

        [Required]
        public string TypeDesDeVie { get; set; }

        [Required]
        public string Nom { get; set; }

        [Range(1, 20)]
        public int Niveau { get; set; }

        [Range(0, 5)]
        public decimal Taille { get; set; }

        [Range(1, 999)]
        public int Age { get; set; }

        public string Yeux { get; set; }

        public string Peau { get; set; }

        public string Cheveux { get; set; }

        [Range(0, 500)]
        public decimal Poids { get; set; }

        public string Historique { get; set; }

        [Display(Name = "Joueur")]
        public string NomJoueur { get; set; }

        public Alignement Alignement { get; set; }

        [Display(Name = "Personnalité")]
        public string TraitsDePersonnalite { get; set; }

        public string Ideaux { get; set; }

        public string Liens { get; set; }

        [Display(Name = "Défauts")]
        public string Defauts { get; set; }

        [Display(Name = "Autres compétences")]
        public string AutresCompetences { get; set; }

        [Display(Name = "PC")]
        public int PiecesCuivre { get; set; }

        [Display(Name = "PA")]
        public int PiecesArgent { get; set; }

        [Display(Name = "PE")]
        public int PiecesEthereum { get; set; }

        [Display(Name = "PO")]
        public int PiecesOr { get; set; }

        [Display(Name = "PP")]
        public int PiecesPlatine { get; set; }

        public int DesDeSauvegardeContreSorts { get; set; }

        public int BonusAttaqueAvecSort { get; set; }

        public byte[] Image { get; set; }

        public List<PersonnageLangue> PersonnagesLangues { get; } = new List<PersonnageLangue>();

        public List<PersonnageSort> PersonnagesSorts { get; } = new List<PersonnageSort>();

        public List<PersonnageCompetence> PersonnagesCompetences { get; } = new List<PersonnageCompetence>();

        public virtual List<PersonnageCaracteristique> PersonnagesCaracteristiques { get; } = new List<PersonnageCaracteristique>();

        public int? CalculerModificateurCompetence(PersonnageCompetence personnageCompetence)
        {
            if (personnageCompetence?.Competence == null)
            {
                return default(int?);
            }

            var personageCaracteristique = PersonnagesCaracteristiques.First(pc =>
                pc.Caracteristique.CaracteristiqueEnum == personnageCompetence.Competence.CaracteristiqueAssociee);
            if (personageCaracteristique == null)
            {
                return default(int?);
            }

            if (personnageCompetence.Maitrise)
            {
                return personageCaracteristique.Modifieur;
            }

            if (personnageCompetence.Expertise)
            {
                return personageCaracteristique.Modifieur * 2;
            }

            return default(int?);
        }
    }
}