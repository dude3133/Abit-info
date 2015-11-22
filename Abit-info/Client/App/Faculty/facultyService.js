(function () {
    'use strict';

    angular
        .module('abitApp')
        .factory('facultyService', facultyService);

    facultyService.$inject = ['$http'];

    function facultyService($http) {
        return {
            getSpecialities: getSpecialities,
            getFaculty: getFaculty
        };

        function getSpecialities(id,page) {
            return $http.get('/api/Specialities/get/?id=' + id + '&offset=' + page.offset + '&count=' + page.count)
                .then(function (httpData) {
                    return httpData.data;
                });
        }
        function getFaculty(id) {
            return $http.get('/api/Faculty/get/'+id)
                .then(function (httpData) {
                    return httpData.data;
                });
        }
    }
})();