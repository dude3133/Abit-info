(function () {
    'use strict';
    angular
        .module('abitApp')
        .controller('signupController', signupController);

    signupController.$inject = ['$scope', '$timeout', 'authService'];

    function signupController($scope, $timeout, authService) {
        /* jshint validthis: true*/
        var vm = this;

        vm.savedSuccessfully = false;
        vm.message = "";
        vm.signUp = signUp;
        vm.startTimer = startTimer;
        vm.disabled = false;

        vm.registrationData = {
            username: "",
            password: "",
            confirmPassword: "",
            email: ""
        };

        function signUp() {
            if (!validate() || vm.disabled) {
                return;
            }
            vm.disabled = true;
            authService.saveRegistration(vm.registrationData).then(function (response) {
                vm.disabled = false;
                vm.savedSuccessfully = true;
                vm.message = "User has been registered successfully and confirmation email has been sent, " +
                "you will be redicted to login page in 2 seconds.";
                startTimer();

            },
             function (response) {
                 vm.disabled = false;
                 var errors = [];
                 for (var key in response.data.ModelState) {
                     for (var i = 0; i < response.data.ModelState[key].length; i++) {
                         errors.push(response.data.ModelState[key][i]);
                     }
                 }
                 vm.message = "Failed to register user due to:" + errors.join(' ');
             });
        }

        function startTimer() {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $scope.auth.currTab = 1;
            }, 2000);
        }

        function validate() {
            if (vm.registrationData.password != vm.registrationData.confirmPassword) {
                vm.message = "Confirm password and password does not match";
                return false;
            }
            return true;
        }
    }
})();