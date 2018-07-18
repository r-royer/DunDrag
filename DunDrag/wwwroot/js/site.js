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

function changeNiveau(sens) {
    var old = parseInt($('#Personnage_Niveau').text());
    if ((old > 1 || sens == 1) && (old < NIVMAX || sens == -1)) {
        $('#level').html(old + sens);
        levelSelected = (old + sens);
    }
}