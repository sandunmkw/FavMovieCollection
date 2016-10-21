
(function () {

    "use strict";
    angular.module('movieApp', ['app.core', 'app.core.ui', 'ui.bootstrap', 'ui.bootstrap.datetimepicker'])
        .config(config)

    config.$inject = ['$routeProvider', '$locationProvider', '$httpProvider'];


    function config($routeProvider, $locationProvider, $httpProvider, $validationProvider) {
        $routeProvider
        .when("/", {
            templateUrl: "scripts/app/film/template/filmsList.html",
            controller: "listFilmsController"
        })
        .when("/createFilm", {
            templateUrl: "scripts/app/film/template/createFilm.html",
            controller: "createFilmController"
        })
        .when("/film/:id", {
            templateUrl: "scripts/app/film/template/filmDetails.html",
            controller: "detailFilmController"
        })
        .otherwise({ redirectTo: "/" });       
    }
})();