(function () {
    'use strict';

    angular
        .module('abitApp')
        .factory('specialitySearchService', specialitySearchService);

    specialitySearchService.$inject = ['$http'];

    function specialitySearchService($http) {
        return {
            getSpecialities: getSpecialities
        };

        function getSpecialities(q,count) {
            return $http.get('/api/Speciality/get/?q='+q+ '&count=' + count)
                .then(function (httpData) {
                    return httpData.data;
                });
        }

    }
})();