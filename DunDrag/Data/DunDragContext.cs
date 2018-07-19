using DunDrag.Models;
using Microsoft.EntityFrameworkCore;

namespace DunDrag.Data
{
    public class DunDragContext : DbContext
    {
        public DunDragContext(DbContextOptions<DunDragContext> options) : base(options)
        {
        }

        public DbSet<Sort> Sorts { get; set; }

        public DbSet<Personnage> Personnages { get; set; }

        public DbSet<Langue> Langues { get; set; }

        public DbSet<Competence> Competences { get; set; }

        public DbSet<Caracteristique> Caracteristiques { get; set; }

        public DbSet<Classe> Classes { get; set; }

        public DbSet<Historique> Historiques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Historique>().ToTable("Historiques");
            modelBuilder.Entity<Classe>().ToTable("Classes");
            modelBuilder.Entity<Caracteristique>().ToTable("Caracteristiques");
            modelBuilder.Entity<Competence>().ToTable("Competences");
            modelBuilder.Entity<Sort>().ToTable("Sorts");
            modelBuilder.Entity<Langue>().ToTable("Langues");
            modelBuilder.Entity<PersonnageSort>().ToTable("PersonnagesSorts");
            modelBuilder.Entity<Personnage>().ToTable("Personnages");
            modelBuilder.Entity<PersonnageSort>()
                .HasKey(t => new { t.PersonnageId, t.SortId });
            modelBuilder.Entity<PersonnageLangue>()
                .HasKey(t => new { t.PersonnageId, t.LangueId });
            modelBuilder.Entity<PersonnageCompetence>()
                .HasKey(t => new { t.PersonnageId, t.CompetenceId });
            modelBuilder.Entity<PersonnageCaracteristique>()
                .HasKey(t => new { t.PersonnageId, t.CaracteristiqueId });
            modelBuilder.Entity<SortClasse>()
                .HasKey(t => new { t.SortId, t.ClasseId });
        }
    }
}