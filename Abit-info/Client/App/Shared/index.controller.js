(function () {
    'use strict';
    angular
        .module('abitApp')
        .controller('indexController', indexController);

    indexController.$inject = ['$location',
                               'authService',
                                'authModal'];

    function indexController($location,
                             authService,
                             authModal) {
        var vm = this;
        vm.quantity = 0;
        vm.logOut = logOut;
        vm.authentication = authService.authentication;
        vm.LogIn = openLoginModal;
        vm.SignUp = openSignupModal;

       

        function openLoginModal() {
            authModal.openModal("login");
        }

        function openSignupModal() {
            authModal.openModal('signup');
        }

        function logOut() {
            authService.logOut();
            $location.path('/');
        }
    }
})();