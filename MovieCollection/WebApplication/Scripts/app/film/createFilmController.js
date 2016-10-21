(function (app) {
    'use strict';

    app.controller('createFilmController', createFilmController);

    createFilmController.$inject = ['$scope', '$routeParams', '$injector','ajaxService',  '$rootScope'];

    function createFilmController($scope, $routeParams,  $injector,ajaxService, $rootScope) {

        createFilmController.$inject = ['$scope'];
        $scope.pageTitle = "Provide Movie Details";

        $scope.film = { rating: 1, charactors: [] };
        $scope.Directors = [];
        $scope.Languages = [];
        $scope.addCharacters = 0;
        $scope.film.characterList = [];

        $scope.createFilmForm = {
            submit: function (form) {
                var isValid = ValidateForm();
                if (isValid) {
                    CreateFilm();
                }
                else {
                    alert("Please provide all fields");
                }
                
            }
        };

        function ValidateForm() {
            if (!$scope.film.title)
                return false;
            else if (!$scope.film.description)
                return false;
            else if ($scope.film.directorId == 0 || $scope.film.directorId == undefined)
                return false;
            else if (!$scope.film.ReleaseDate)
                return false;
            else if (!$scope.film.rating)
                return false;
            else if ($scope.film.languageId == 0 || $scope.film.languageId == undefined)
                return false;
            else
                return true;
        }

        function CreateFilm() {
            ajaxService.post('/api/film/addfilm', $scope.film,
                             filmSaveCompleted, filmSaveFailed);
        }

        function filmSaveCompleted(result) {
            $scope.film.id = result.data.id;
            $scope.isSavedSucess = 1;
            $scope.addCharacters = 1;
            alert("Film Details Saved Sucessfully");
        }

        function filmSaveFailed(response) {
            $scope.isSavedSucess = 0;
            alert("Error Saving Film Details");
        }


        $scope.addFilmCharacters = function () {
            if ($scope.film.characterList === undefined || $scope.film.characterList === null)
                $scope.film.characterList = [];

            $scope.film.characterList.push({
                character: $scope.film.charactors.characterName,
                actorName: $scope.film.charactors.actor
            });
            $scope.film.charactors.characterName = '';
            $scope.film.charactors.actor = '';

            $scope.createFilmForm.submit();
        }
        
        function LoadDirectors() {
            if (!ajaxService) {
                window.location.reload();
            }
            else {
                ajaxService.get('/api/film/getAllDirectors/', null, directorLoadCompleted, directorLoadFailed);
            }
            
        }

        function LoadLanguages() {
            ajaxService.get('/api/film/getAllLanguages/', null, languageLoadCompleted, languageLoadFailed);
        }

        function directorLoadCompleted(result) {
            $scope.Directors = result.data;
        }

        function directorLoadFailed(response) {
            alert("error load directors!");
        }

        function languageLoadCompleted(result) {
            $scope.Languages = result.data;
        }

        function languageLoadFailed(response) {
            alert("error load language!");
        }

        LoadDirectors();
        LoadLanguages();

    }
})(angular.module('movieApp'))