(function () {
    'use strict';
    angular
        .module('abitApp')
        .controller('universityController', universityController);

    universityController.$inject = ['universityInfo', 'universityService'];

    function universityController(universityInfo, universityService) {
        var vm = this;
        vm.university = universityInfo;
        vm.Message = " ";
    };
})();