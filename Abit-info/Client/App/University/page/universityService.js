(function () {
    'use strict';

    angular
        .module('abitApp')
        .factory('universityService', universityService);

    universityService.$inject = ['$http'];

    function universityService($http) {
        return {
            getFaculties: getFaculties,
            getUnivesity: getUnivesity
        };

        function getFaculties(id,page) {
            return $http.get('/api/Faculty/get/?id=' + id + '&offset=' + page.offset + '&count=' + page.count)
                .then(function (httpData) {
                    return httpData.data;
                });
        }
        function getUnivesity(id) {
            return $http.get('/api/University/get/'+id)
                .then(function (httpData) {
                    return httpData.data;
                });
        }
    }
})();