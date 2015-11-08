(function() {
    'use strict';

    angular
        .module('abitApp')
        .controller('mainPageController', mainPageController);

    mainPageController.$inject = ['$scope'];

    function mainPageController($scope) {
        var vm = this;
    }
})();