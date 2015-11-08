(function () {
    'use strict';

    angular
        .module('abitApp')
        .controller('authController', authController);

    authController.$inject = ['$modalInstance', 'currTab'];

    function authController($modalInstance, currTab) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'authController';
        vm.currTab = currTab;
        vm.close = close;

        function close() {
            $modalInstance.close("cancel");
        }
    }
})();
