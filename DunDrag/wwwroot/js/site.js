// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var NIVMAX = 20;

function changeRace(race) {
    $("img[id^='img-card-race']").addClass("img-card-unselected");
    var id = '#img-card-race' + race;
    $(id).removeClass("img-card-unselected");
    $('#Personnage_Race').val(race);
}

function changeClasse(classe) {
    $("img[id^='img-card-classe']").addClass("img-card-unselected");
    var id = '#img-card-classe' + classe;
    $(id).removeClass("img-card-unselected");
    $('#Personnage_Classe_Id').val(classe);
}

function changeHistorique(historique) {
    $("img[id^='img-card-historique']").addClass("img-card-unselected");
    var id = '#img-card-historique' + historique;
    $(id).removeClass("img-card-unselected");
    $('#Personnage_Historique_Id').val(historique);
}

function changeNiveau(sens) {
    var old = parseInt($('#Personnage_Niveau').text());
    if ((old > 1 || sens === 1) && (old < NIVMAX || sens === -1)) {
        $('#Personnage_Niveau').html(old + sens);
    }
}

function changeCaracteristique(element, caracteristiqueId) {
    var value = $(element).val();
    var id = "#td-caracteristique" + caracteristiqueId;
    $(id).html(value);
    var inputName = "input[name='valeur-caracteristique" + caracteristiqueId + "'";
    $(inputName).val(value);
    var modifieur = -4;
    if (value >= 20) {
        modifieur = 5;
    }
    else if (value >= 18) {
        modifieur = 4;
    }
    else if (value >= 16) {
        modifieur = 3;
    }
    else if (value >= 14) {
        modifieur = 2;
    }
    else if (value >= 12) {
        modifieur = 1;
    }
    else if (value >= 10) {
        modifieur = 0;
    }
    else if (value >= 8) {
        modifieur = -1;
    }
    else if (value >= 6) {
        modifieur = -2;
    }
    else if (value >= 4) {
        modifieur = -3;
    }

    id = "#td-modifieur" + caracteristiqueId;
    $(id).html(modifieur);
}