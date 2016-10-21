(function (app) {
    'use strict';

    app.service('ajaxService', ajaxService);

    ajaxService.$inject = ['$http', '$rootScope'];

    function ajaxService($http, $rootScope) {
        var service = {
            get: get,
            post: post
        };
        function get(url, config, success, failure) {
            return $http.get(url, config)
                    .then(function (result) {
                        success(result);
                    }, function (error) {
                        if (error.status == '401') {
                            //redirect to custome page
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    });
        }

        function post(url, data, success, failure) {
            return $http.post(url, data)
                    .then(function (result) {
                        success(result);
                    }, function (error) {
                        if (error.status == '401') {
                            //redirect to custome page
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    });
        }

        return service;
    }
})(angular.module('app.core'))