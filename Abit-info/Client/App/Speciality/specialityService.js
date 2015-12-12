(function () {
    'use strict';

    angular
        .module('abitApp')
        .factory('specialityService', specialityService);

    specialityService.$inject = ['$http'];

    function specialityService($http) {
        return {
            getApplicants: getApplicants,
            getSpeciality: getSpeciality
        };

        function getApplicants(id) {
            return $http.get('/api/Specialities/get/?id=' + id)
                .then(function (httpData) {
                    return httpData.data;
                });
        }
        
        function getSpeciality(id) {
            return $http.get('/api/Specialities/get/?id=' + id)
                .then(function (httpData) {
                    return httpData.data;
                });
        }

    }
})();