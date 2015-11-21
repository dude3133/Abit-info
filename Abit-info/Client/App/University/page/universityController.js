(function () {
    'use strict';
    angular
        .module('abitApp')
        .controller('universityController', universityController);

    universityController.$inject = ['universityInfo','facultiesCount', 'universityService'];

    function universityController(universityInfo, facultiesCount, universityService) {
        var vm = this;
        vm.university = universityInfo;
        vm.faculties = [];
        vm.Message = " ";
        vm.facultiesCount = facultiesCount;
        vm.facultiesCurrentPage = 1;
        vm.facultiesPerPage = 20;
        vm.fetchFaculties = fetchFaculties;

        function fetchFaculties(currentPage) {
            var page = {
                offset: vm.facultiesPerPage * (currentPage - 1),
                count: vm.facultiesPerPage
            }
            universityService.getFaculties(vm.university.Id,page).then(function (data) {
                vm.faculties = data;
            });
        }

        init();

        function init() {
            var page = {
                offset: vm.facultiesPerPage * (vm.facultiesCurrentPage - 1),
                count: vm.facultiesPerPage
            }
            universityService.getFaculties(vm.university.Id, page).then(function (data) {
                vm.faculties = data;
            });
        }
    };
})();