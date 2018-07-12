using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
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
                    }
                });
                context.SaveChanges();
            }


            if (!context.Sorts.Any())
            {
                var regexNiveauEcole = new Regex(@"^niveau\s+(?<niveau>[0-9])\s+\-\s+(?<ecole>\w+)(?<rituel>\s+\(rituel\))?$",
                    RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                XElement root = XElement.Load(".\\Data\\sorts.xml");
                IEnumerable<XElement> sortElements = root.Elements("div");
                foreach (XElement el in sortElements)
                {
                    var sort = new Sort();
                    sort.Nom = el.Elements().ElementAt(0).Value;
                    var matchNiveauEcole =
                        regexNiveauEcole.Match(el.Elements().ElementAt(1).Elements().ElementAt(0).Value);
                    if (matchNiveauEcole.Success)
                    {
                        sort.Niveau = Convert.ToInt32(matchNiveauEcole.Groups["niveau"].Value);
                        sort.Ecole = DecodeLibelleEcole(matchNiveauEcole.Groups["ecole"].Value);
                        if (matchNiveauEcole.Groups["rituel"].Success)
                        {
                            sort.Rituel = true;
                        }
                    }
                    else
                    {
                        Trace.WriteLine("Ca va pas");
                    }

                    sort.Incantation = el.Elements().ElementAt(2).Value;
                    sort.Portee = el.Elements().ElementAt(3).Value;
                    sort.Composantes = el.Elements().ElementAt(4).Value;
                    sort.Duree = el.Elements().ElementAt(5).Value;
                    sort.Description = el.Elements().ElementAt(6).ToString();
                    var source = el.Elements().ElementAt(8).Value.Split(";");
                    sort.Source = source[0];
                    
                    context.Sorts.Add(sort);
                    context.SaveChanges();
                    for (int i = 1; i < source.Length; i++)
                    {
                        sort.SortsClasses.Add(new SortClasse { SortId = sort.Id, ClasseId = context.Classes.First(c => string.Compare(c.Nom, source[i].Trim(), StringComparison.InvariantCultureIgnoreCase) == 0).Id });
                    }
                }
            }

            if (!context.Personnages.Any())
            {
                context.Personnages.AddRange(new List<Personnage>
                {
                    new Personnage
                    {
                        Nom = "Arkenos Entropie",
                        Niveau = 5
                    }
                });
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
            }

            if (!context.Competences.Any())
            {
                context.Competences.AddRange(new List<Competence>
                {
                    new Competence{ Nom = "Acrobaties", CaracteristiqueAssociee = CaracteristiqueEnum.Dexterite},
                    new Competence{ Nom = "Dressage", CaracteristiqueAssociee = CaracteristiqueEnum.Intelligence},
                    new Competence{ Nom = "Arcanes", CaracteristiqueAssociee = CaracteristiqueEnum.Force},
                    new Competence{ Nom = "Athlétisme", CaracteristiqueAssociee = CaracteristiqueEnum.Dexterite},
                    new Competence{ Nom = "Tromperie", CaracteristiqueAssociee = CaracteristiqueEnum.Sagesse},
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
            }

            context.SaveChanges();
        }

        private static Ecole DecodeLibelleEcole(string ecole)
        {
            if (Enum.TryParse(typeof(Ecole), ecole.Replace("é", "e"), true, out var enumEcole))
            {
                return (Ecole)enumEcole;
            }

            throw new Exception();
        }
    }
}