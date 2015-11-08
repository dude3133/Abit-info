(function () {
    'use strict';

    angular
        .module('abitApp')
        .controller('associateController', associateController);

    associateController.$inject = ['$location', '$timeout', 'authService'];

    function associateController($location, $timeout, authService) {
        /* jshint validthis: true*/
        var vm = this;
        vm.savedSuccessfully = false;
        vm.message = '';
        vm.registerData = {
            userName: authService.externalAuthData.userName,
            provider: authService.externalAuthData.provider,
            externalAccessToken: authService.externalAuthData.externalAccessToken
        };
        vm.registerExternal = registerExternal; 
        
        function registerExternal() {
            authService.registerExternal(vm.registerData)
                .then(function(response) {
                        vm.savedSuccessfully = true;
                        vm.message = "User has been registered successfully, you will be redicted to main page in 2 seconds.";
                        startTimer();
                    },
                    function(response) {
                        var errors = [];
                        for (var key in response.modelState) {
                            errors.push(response.modelState[key]);
                        }
                        $scope.message = "Failed to register user due to:" + errors.join(' ');
                    });
        };

        function startTimer() {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/');
            }, 2000);
        }
    };
})();