(function () {
    'use strict';
    angular
        .module('abitApp')
        .controller('userController', userController);

    userController.$inject = [];

    function userController() {
        var vm = this;
        vm.listOfUsers = [{ 'Name': 'UserName1', 'Id':1 }];
        vm.Message = " ";
    };
})();