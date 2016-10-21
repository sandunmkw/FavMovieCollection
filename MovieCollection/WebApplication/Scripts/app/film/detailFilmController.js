(function (app) {
    'use strict';

    app.controller('detailFilmController', detailFilmController);

    detailFilmController.$inject = ['$scope', '$routeParams', 'ajaxService', '$rootScope'];

    function detailFilmController($scope, $routeParams, ajaxService, $rootScope) {

        $scope.film = { CreatedDate: Date(),rating:1};
        

        var filmId = $routeParams.id;
        if (filmId != undefined && filmId != '') {
            $scope.film.filmId = filmId;
            
            GetDetails($scope.film.filmId);
        }

        function GetDetails(filmId) {
            ajaxService.get('/api/film/getfilmDetails/', { params: { movieId: filmId } },
                             function (result) { $scope.film = result.data; }, function (response) { alert(response.data)});
        }
    }

})(angular.module('movieApp'))