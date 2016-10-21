(function (app) {
    'use strict';

    app.controller('listFilmsController', listFilmsController);

    listFilmsController.$inject = ['$scope', 'ajaxService', '$rootScope'];

    function listFilmsController($scope, ajaxService) {
        $scope.Films = [];
        $scope.findFilms = findFilms;

        function findFilms(page) {
            ajaxService.get('/api/film/getfilm', null,
                        function (result) {
                            $scope.Films = result.data.result;
                        },
                        function (response) {
                            alert(response.data);
                        });
        }

        $scope.findFilms();
    }
})(angular.module('movieApp'));