(function () {
    'use strict';
    angular
        .module('abitApp')
        .controller('specialityController', specialityController);

    specialityController.$inject = ['specialityInfo', 'specialityService', '$stateParams'];

    function specialityController(specialityInfo, specialityService, $stateParams) {
        var vm = this;
        vm.speciality = specialityInfo;
        vm.Message = " ";
        vm.getAccepted = getAccepted;
        vm.getRecomended = getRecomended;
        vm.getApplicants = getApplicants;
        vm.apply = apply;


        function apply() {
            specialityService.apply($stateParams.id);
        }
        function getAccepted(to) {
            return vm.speciality.Applicants.slice(0, to);
        }
        function getRecomended(from,to) {
            return vm.speciality.Applicants.slice(from, to);
        }
        function getApplicants(from) {
            return vm.speciality.Applicants.slice(from, vm.speciality.Applicants.length);
        }
    };
})();