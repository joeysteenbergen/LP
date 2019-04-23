const soccerLeagues = {
    Argentina: "argentina_primera_division",
    Australia: "australia_aleague",
    Belgium: "belgium_first_div",
    Brazil: "brazil_campeonato",
    ChampionsLeague: "uefa_champs_league",
    Denmark: "denmark_superliga",
    EnglandOne: "epl",
    EnglandTwo: "efl_champ",
    EnglandThree: "efl_england_league1",
    EnglandFour: "efl_england_league2",
    EuropeLeague: "uefa_europa_league",
    Finland: "finland_veikkausliiga",
    France: "france_ligue_one",
    Germany: "germany_bundesliga",
    Italy: "italy_serie_a",
    Japan: "japan_j_league",
    Netherlands: "netherlands_eredivisie",
    Norway: "norway_eliteserien",
    Portugal: "portugal_primeira_liga",
    Russia: "russia_premier_league",
    Spain: "spain_la_liga",
    Scotland: "spl",
    Sweden: "sweden_allsvenskan",
    Switzerland: "switzerland_superleague",
    Turkey: "turkey_super_league",
    USA: "usa_mls",
    WorldCup: "fifa_world_cup"
}

const OtherSports = {
    NFL: "americanfootball_nfl",
    AFL: "aussierules_afl",
    MMA: "mma_mixed_martial_arts",
    NRL: "rugbyleague_nrl",
    NHL: "icehockey_nhl",
    MLB: "baseball_mlb",
    NBA: "basketball_nba",
    NCAAB: "basketball_ncaab"
}

$(document).ready(function () {

});

function LoadAllSoccerLeagues() {
    var leagues = ObjectToValueArray(soccerLeagues);
    for (x = 0; x < leagues.length; x++) {
        var number = x;
        $.ajax({
            type: "GET",
            url: 'https://api.the-odds-api.com/v3/odds?sport=soccer_' + leagues[number] + '&region=uk&mkt=h2h&apiKey=46a2580a2141f2468c4b996a84ed7d71',
            dataType: 'json',
            success: function (result) {
                for (i = 0; i < result['data'].length; i++) {
                    if (result != undefined || result.length != 0) {
                        console.log(leagues[number]);
                        $('#gamesContainer').append("<div id='" + leagues[number]+"' class='row'><div class='col-md-12'><div class='col-md-6'><p class='division'>" + result['data'][i]['sport_nice'] + "</p><p class='game'><span>" + result['data'][i]['teams'][1] + "</span> - <span>" + result['data'][i]['teams'][0] + "</span></p></div><div class='col-md-4 offset-md-2'><a class='OddsButton' onclick='AddBetToList(this, 1)'>" + result['data'][i]['sites'][0]['odds']['h2h'][1] + "</a><a class='OddsButton' onclick='AddBetToList(this, 2)'>" + result['data'][i]['sites'][0]['odds']['h2h'][2] + "</a><a class='OddsButton' onclick='AddBetToList(this, 3)'>" + result['data'][i]['sites'][0]['odds']['h2h'][0] + "</a></div></div></div><hr/>");
                    }
                }
            }
        })
    }
}

function AddBetToList(object, winner) {
    var odd = object.innerText;
    var parentElement = $(object).parents()[1];
    var contestantParent = $(parentElement).find(".game");
    var divisionParent = $(parentElement).find(".division");
    var contestants = contestantParent[0].childNodes;
    var division = divisionParent[0].innerText;
    var gameWinner = "";

    if (winner == 1) {
        gameWinner = contestants[0].innerText;
    }
    else if (winner == 3) {
        gameWinner = contestants[2].innerText;
    }
    else {
        gameWinner = "Draw";
    }

    $("#bets").append("<div class='row'><div class='col-md-12'><div class='row'><p>" + division + "</p></div><div class='row'><p>" + gameWinner + "</p><p>" + odd + "</p></div></div></div>");
    var totalOdds = document.getElementById("totalOdds").innerText;
    document.getElementById("totalOdds").innerText = +totalOdds + +odd;

    if ($("#betslip").hasClass('close')) {
        ToggleBetslip();
    }
}

function calculatePayout() {
    var totalOdds = document.getElementById("totalOdds").innerText;
    var betAmount = document.getElementById("betAmount").value;

    document.getElementById("payoutAmount").innerText = +totalOdds * +betAmount;
}

/*function LoadOtherSports(sport) {
    $.ajax({
        type: "GET",
        url: 'https://api.the-odds-api.com/v3/odds?sport=' + OtherSports[sport] + '&region=uk&mkt=h2h&apiKey=46a2580a2141f2468c4b996a84ed7d71',
        dataType: 'json',
        success: function (result) {
            for (i = 0; i < result['data'].length; i++) {
                console.log(result['data'][i]['teams'][0]);
                
            }
        }
    })
}*/

function ObjectToValueArray(obj) {
    var arr = [];
    for (var i in obj) {
        var v = obj[i];
        arr.push(v);
    }
    return arr;
}

function ToggleBetslip() {
    $("#betslip").toggleClass('close');
}