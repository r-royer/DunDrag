﻿using System;
using DunDrag.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace DunDrag.Data
{
    public class DbInitializer
    {
        public static void Initialize(DunDragContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Sorts.
            if (context.Sorts.Any())
            {
                return; // DB has been seeded
            }

            var sorts = new[]
            {
                new Sort
                {
                    Nom = "Agrandissement/Rapetissement",
                    Niveau = 2,
                    Ecole = Ecole.Transmutation,
                    Incantation = "1 action",
                    Portee = "9 mètres",
                    Composantes = "V, S, M (une pincée de poudre de fer)",
                    Duree = "concentration, jusqu'à 1 minute",
                    Description = "Vous agrandissez ou réduisez en taille une créature ou un objet que vous pouvez voir et qui est à portée pour la durée du sort. Choisissez une créature ou un objet qui n'est pas porté ou transporté. Si la cible n'est pas consentante, elle peut effectuer un jet de sauvegarde de Constitution. En cas de succès, le sort n'a aucun effet." + Environment.NewLine + "Si la cible est une créature, toutes les choses qu'elle porte et transporte changent de taille avec elle. Tout objet lâché par la créature affectée reprend sa taille normale. " + Environment.NewLine + "Agrandissement. La cible double dans toutes les dimensions, et son poids est multiplié par huit. Cela augmente sa taille d'une catégorie, de M à G par exemple. S'il n'y a pas assez de place dans la pièce pour que la cible double de taille, la créature ou l'objet atteint la taille maximale possible dans l'espace disponible. Jusqu'à la fin du sort, la cible a aussi l'avantage à ses jets de Force et ses jets de sauvegarde de Force. Les armes de la cible grandissent également. Tant que ces armes sont agrandies, les attaques de la cible occasionnent 1d4 dégâts supplémentaires. " + Environment.NewLine + "Rapetissement. La taille de la cible est diminuée de moitié dans toutes les dimensions, et son poids est divisé par huit. Cette réduction diminue sa taille d'une catégorie, de M à P par exemple. Jusqu'à la fin du sort, la cible a un désavantage à ses jets de Force et à ses jets de sauvegarde de Force. Les armes de la cible rapetissent aussi. Tant que ces armes sont réduites, les attaques de la cible occasionnent 1d4 dégâts en moins (minimum 1 point de dégâts). "
                }
            };

            foreach (Sort s in sorts)
            {
                context.Sorts.Add(s);
            }

            context.SaveChanges();
        }
    }
}