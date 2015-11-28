(function () {
    'use strict';
    angular
        .module('abitApp')
        .controller('userController', userController);

    userController.$inject = ['userService'];

    function userController(userService) {
        var vm = this;
        vm.listOfUsers = [];
        vm.Message = " ";

        activate();

        function activate() {
            userService.getUsers().then(function(data) {
                vm.listOfUsers = data;
            });
        }
    };
})();