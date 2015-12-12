(function () {
    'use strict';

    angular
        .module('abitApp')
        .factory('specialityService', specialityService);

    specialityService.$inject = ['$http'];

    function specialityService($http) {
        return {
            getApplicant: getApplicant
        };

        function getApplicant(id, page) {
            return $http.get('/api/Specialities/get/?id=' + id + '&offset=' + page.offset + '&count=' + page.count)
                .then(function (httpData) {
                    return httpData.data;
                });
        }

    }
})();