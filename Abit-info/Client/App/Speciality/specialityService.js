(function () {
    'use strict';

    angular
        .module('abitApp')
        .factory('specialityService', specialityService);

    specialityService.$inject = ['$http', 'authService'];

    function specialityService($http, authService) {
        return {
            getApplicants: getApplicants,
            getSpeciality: getSpeciality,
            apply: apply
        };

        function getApplicants(id) {
            return $http.get('/api/Speciality/get/?id=' + id)
                .then(function (httpData) {
                    return httpData.data;
                });
        }
        
        function getSpeciality(id) {
            return $http.get('/api/Speciality/get/?id=' + id)
                .then(function (httpData) {
                    return httpData.data;
                });
        }

        function apply(id) {
            var model = {
                UserName: authService.authentication.userName,
                UserId:"",
                Id:id
            }
            return $http.post('/api/Speciality/post/',model)
                .then(function (httpData) {
                    return httpData.data;
                });
        } 
    }
})();