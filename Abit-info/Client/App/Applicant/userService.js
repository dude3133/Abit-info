(function () {
    'use strict';

    angular
        .module('abitApp')
        .factory('userService', userService);

    userService.$inject = ['$http'];

    function userService($http) {
        return {
            getUsers: getUsers
        };
        function getUsers() {
            return $http.get('/api/User/getall/')
                .then(function (httpData) {
                    return httpData.data;
                });
        }
    }
})();