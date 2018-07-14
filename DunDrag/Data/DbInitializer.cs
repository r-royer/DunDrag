using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using DunDrag.Models;

namespace DunDrag.Data
{
    public class DbInitializer
    {
        public static void Initialize(DunDragContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Classes.Any())
            {
                context.Classes.AddRange(new List<Classe>
                {
                    new Classe
                    {
                        Nom = "Barde"
                    },
                    new Classe
                    {
                        Nom = "Clerc"
                    },
                    new Classe
                    {
                        Nom = "Druide"
                    },
                    new Classe
                    {
                        Nom = "Ensorceleur"
                    },
                    new Classe
                    {
                        Nom = "Magicien"
                    },
                    new Classe
                    {
                        Nom = "Paladin"
                    },
                    new Classe
                    {
                        Nom = "Rôdeur"
                    },
                    new Classe
                    {
                        Nom = "Sorcier"
                    },
                    new Classe
                    {
                        Nom = "Roublard"
                    }
                });

                context.SaveChanges();
            }

            if (!context.Sorts.Any())
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(".\\Data\\sorts.xml");
                foreach (XmlNode childNode in xmlDocument["Sorts"].ChildNodes)
                {
                    var sort = new Sort
                    {
                        Nom = childNode["Nom"].InnerText,
                        Niveau = Convert.ToInt32(childNode["Niveau"].InnerText),
                        Ecole = (Ecole)Enum.Parse(typeof(Ecole), childNode["Ecole"].InnerText, true),
                        Rituel = bool.Parse(childNode["Rituel"].InnerText),
                        Incantation = childNode["Incantation"].InnerText,
                        Portee = childNode["Portee"].InnerText,
                        Composantes = childNode["Composantes"].InnerText,
                        Duree = childNode["Duree"].InnerText,
                        Description = childNode["Description"].InnerXml,
                        Source = childNode["Source"].InnerText
                    };
                    context.Sorts.Add(sort);
                    context.SaveChanges();
                    foreach (var classe in childNode["Classes"].InnerText.Split(";"))
                    {
                        sort.SortsClasses.Add(new SortClasse
                        {
                            SortId = sort.Id,
                            ClasseId = context.Classes.First(c => string.Compare(c.Nom, classe, StringComparison.InvariantCultureIgnoreCase) == 0).Id
                        });
                    }

                    context.SaveChanges();
                }
            }

            if (!context.Langues.Any())
            {
                context.Langues.AddRange(new List<Langue>
                {
                    new Langue{ Nom = "Commun"},
                    new Langue{ Nom = "Elfique"},
                    new Langue{ Nom = "Géant"},
                    new Langue{ Nom = "Gnome"},
                    new Langue{ Nom = "Gobelin"},
                    new Langue{ Nom = "Halfelin"},
                    new Langue{ Nom = "Nain"},
                    new Langue{ Nom = "Orque"},
                    new Langue{ Nom = "Abyssal"},
                    new Langue{ Nom = "Céleste"},
                    new Langue{ Nom = "Commun des profondeurs"},
                    new Langue{ Nom = "Draconique"},
                    new Langue{ Nom = "Infernal"},
                    new Langue{ Nom = "Primordial"},
                    new Langue{ Nom = "Profond"},
                    new Langue{ Nom = "Sylvain"}
                });

                context.SaveChanges();
            }

            if (!context.Personnages.Any())
            {
                context.Personnages.AddRange(new List<Personnage>
                {
                    new Personnage
                    {
                        Nom = "Arkenos Entropie",
                        Niveau = 5,
                        Age = 25,
                        Alignement = Alignement.NeutreBon,
                        Classe = context.Classes.First(c => c.Nom == "Roublard"),
                        TypeDesDeVie = "d 8",
                        Vitesse = 9,
                        Initiative = 3,
                        ClasseArmure = 15
                    }
                });

                context.SaveChanges();
            }

            if (!context.Competences.Any())
            {
                context.Competences.AddRange(new List<Competence>
                {
                    new Competence{ Nom = "Acrobaties", CaracteristiqueAssociee = CaracteristiqueEnum.Dexterite},
                    new Competence{ Nom = "Dressage", CaracteristiqueAssociee = CaracteristiqueEnum.Intelligence},
                    new Competence{ Nom = "Arcanes", CaracteristiqueAssociee = CaracteristiqueEnum.Force},
                    new Competence{ Nom = "Athlétisme", CaracteristiqueAssociee = CaracteristiqueEnum.Dexterite},
                    new Competence{ Nom = "Supercherie", CaracteristiqueAssociee = CaracteristiqueEnum.Sagesse},
                    new Competence{ Nom = "Histoire", CaracteristiqueAssociee = CaracteristiqueEnum.Dexterite},
                    new Competence{ Nom = "Intimidation", CaracteristiqueAssociee = CaracteristiqueEnum.Intelligence},
                    new Competence{ Nom = "Investigation", CaracteristiqueAssociee = CaracteristiqueEnum.Charisme},
                    new Competence{ Nom = "Médecine", CaracteristiqueAssociee = CaracteristiqueEnum.Intelligence},
                    new Competence{ Nom = "Nature", CaracteristiqueAssociee = CaracteristiqueEnum.Sagesse},
                    new Competence{ Nom = "Perception", CaracteristiqueAssociee = CaracteristiqueEnum.Intelligence},
                    new Competence{ Nom = "Perspicacité", CaracteristiqueAssociee = CaracteristiqueEnum.Sagesse},
                    new Competence{ Nom = "Representation", CaracteristiqueAssociee = CaracteristiqueEnum.Sagesse},
                    new Competence{ Nom = "Persuasion", CaracteristiqueAssociee = CaracteristiqueEnum.Charisme},
                    new Competence{ Nom = "Religion", CaracteristiqueAssociee = CaracteristiqueEnum.Intelligence},
                    new Competence{ Nom = "Escamotage", CaracteristiqueAssociee = CaracteristiqueEnum.Sagesse},
                    new Competence{ Nom = "Discrétion", CaracteristiqueAssociee = CaracteristiqueEnum.Charisme},
                    new Competence{ Nom = "Survie", CaracteristiqueAssociee = CaracteristiqueEnum.Charisme}
                });

                context.SaveChanges();
            }

            if (!context.Caracteristiques.Any())
            {
                context.Caracteristiques.AddRange(new List<Caracteristique>
                {
                    new Caracteristique{ Nom = "Force", CaracteristiqueEnum = CaracteristiqueEnum.Force},
                    new Caracteristique{ Nom = "Dextérité", CaracteristiqueEnum = CaracteristiqueEnum.Dexterite},
                    new Caracteristique{ Nom = "Constitution", CaracteristiqueEnum = CaracteristiqueEnum.Constitution},
                    new Caracteristique{ Nom = "Intelligence", CaracteristiqueEnum = CaracteristiqueEnum.Intelligence},
                    new Caracteristique{ Nom = "Sagesse", CaracteristiqueEnum = CaracteristiqueEnum.Sagesse},
                    new Caracteristique{ Nom = "Charisme", CaracteristiqueEnum = CaracteristiqueEnum.Charisme}
                });

                context.SaveChanges();
            }
        }
    }
}