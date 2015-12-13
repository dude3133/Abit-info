(function () {
    'use strict';
    angular
        .module('abitApp')
        .controller('specialitySearchController', specialitySearchController);

    specialitySearchController.$inject = ['specialitySearchService'];

    function specialitySearchController(specialitySearchService) {
        var vm = this;
        vm.query = "";
        vm.specialities = [];
        vm.Message = " ";
        vm.find = find;

        function find() {
            specialitySearchService.getSpecialities(vm.query, 20).then(function (data) {
                       vm.specialities = data;
                    });
        }
    };
})();