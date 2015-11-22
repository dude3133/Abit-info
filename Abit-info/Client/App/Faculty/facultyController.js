(function () {
    'use strict';
    angular
        .module('abitApp')
        .controller('facultyController', facultyController);

    facultyController.$inject = ['facultyInfo',  'facultyService'];

    function facultyController(facultyInfo,  facultyService) {
        var vm = this;
        vm.faculty = facultyInfo;
        vm.specialities = [];
        vm.Message = " ";
        vm.specialitiesCount = 20;
        vm.specialitiesCurrentPage = 1;
        vm.specialitiesPerPage = 20;
        vm.fetchspecialities = fetchspecialities;

        function fetchspecialities(currentPage) {
        //    var page = {
        //        offset: vm.specialitiesPerPage * (currentPage - 1),
        //        count: vm.specialitiesPerPage
        //    }
        //    facultyService.getspecialities(vm.faculty.Id,page).then(function (data) {
        //        vm.specialities = data;
        //    });
        }

        //init();

        //function init() {
        //    vm.specialitiesCount
        //    var page = {
        //        offset: vm.specialitiesPerPage * (vm.specialitiesCurrentPage - 1),
        //        count: vm.specialitiesPerPage
        //    }
        //    facultyService.getspecialities(vm.faculty.Id, page).then(function (data) {
        //        vm.specialities = data;
        //    });
        //}
    };
})();