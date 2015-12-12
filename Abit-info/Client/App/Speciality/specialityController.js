(function () {
    'use strict';
    angular
        .module('abitApp')
        .controller('specialityController', specialityController);

    specialityController.$inject = ['specialityInfo', 'specialityService'];

    function specialityController(specialityInfo, specialityService) {
        var vm = this;
        vm.speciality = specialityInfo;
        vm.Message = " ";

    };
})();