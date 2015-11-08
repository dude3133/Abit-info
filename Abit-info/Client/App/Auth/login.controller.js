(function () {

    'use strict';
    angular
        .module('abitApp')
        .controller('loginController', loginController);

    loginController.$inject = ['$scope', '$location', 'authService'];

    function loginController($scope, $location, authService) {
        /* jshint validthis: true */
        var vm = this;

        vm.loginData = { userName: "", password: ""};
        vm.login = login;
        vm.authExternalProvider = authExternalProvider;
        vm.authCompletedCB = authCompletedCB;
        vm.message = "";
        vm.disabled = false;

        function login() {
            if (vm.disabled) {
                return;
            }
            vm.disabled = true;
            authService.login(vm.loginData).then(function (response) {
                $scope.auth.close();

            },
             function (err) {
                 vm.message = err.error_description;
             });
        }

        
        function authExternalProvider(provider) {
            var externalProviderUrl = "api/Facebook/ExternalLogin?provider=" + provider;
            // + "&response_type=token&client_id=" + ngAuthSettings.clientId
            // + "&redirect_uri=" + redirectUri;
            window.$windowScope = vm;

            var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
        }

        function authCompletedCB(fragment) {
            $scope.$apply(function() {

                if (fragment.haslocalaccount === 'False') {

                    authService.logOut();

                    authService.externalAuthData = {
                        provider: fragment.provider,
                        userName: fragment.external_user_name,
                        externalAccessToken: fragment.external_access_token
                    };

                    $location.path('/associate');

                    $scope.auth.close();
                } else {
                    //Obtain access token and redirect to orders
                    var externalData = {
                        provider: fragment.provider,
                        externalAccessToken: fragment.external_access_token
                    };
                    authService.obtainAccessToken(externalData).then(function(response) {
                            //$location.path('/');
                            $scope.auth.close();
                        },
                        function(err) {
                            $scope.message = err.error_description;
                        });
                }
            });
        }
    };
})();