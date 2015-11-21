(function () {
    'use strict';
    angular
        .module('abitApp')
        .controller('universitiesListController', universitiesListController);

    universitiesListController.$inject = ['universitiesCount', 'universitiesListService'];

    function universitiesListController(universitiesCount, universitiesListService) {
        var vm = this;
        vm.universities = [];
        vm.Message = " ";
        vm.universityCount = universitiesCount;
        vm.universityCurrentPage = 1;
        vm.universitiesPerPage = 20;
        vm.fetchUniversities = fetchUniversities;

        function fetchUniversities(currentPage) {
            var page = {
                offset: vm.universitiesPerPage * (currentPage - 1),
                count: vm.universitiesPerPage
            }
            universitiesListService.getUniversities(page).then(function (data) {
                vm.universities = data;
            });
        }

        init();

        function init() {
            var page = {
                offset: vm.universitiesPerPage * (vm.universityCurrentPage - 1),
                count: vm.universitiesPerPage
            }
            universitiesListService.getUniversities(page).then(function (data) {
                vm.universities = data;
            });
        }
    };
})();