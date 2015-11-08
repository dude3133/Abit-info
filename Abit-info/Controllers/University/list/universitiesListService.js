(function () {
    'use strict';

    angular
        .module('abitApp')
        .factory('universitiesListService', universitiesListService);

    universitiesListService.$inject = ['$http'];

    function universitiesListService($http) {
        return {
            getUniversities: getUniversities,
            getUniversitiesCount: getUniversitiesCount
        };

        function getUniversities(page) {
            return $http.get('/api/University/get/?offset=' + page.offset + '&count=' + page.count)
                .then(function (httpData) {
                    return httpData.data;
                });
        }
        function getUniversitiesCount() {
            return $http.get('/api/University/getCount/')
                .then(function (httpData) {
                    return httpData.data;
                });
        }
    }
})();