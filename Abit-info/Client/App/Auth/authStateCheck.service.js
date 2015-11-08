(function () {
    'use strict';

    angular
        .module('abitApp')
        .factory('authStateCheck', authStateCheck);

    authStateCheck.$inject = ['$state', 'authService', 'authModal', 'toastr'];

    function authStateCheck($state, authService, authModal, toastr) {
        var service = {
            checkAccess: checkAccess
        };

        return service;

        function checkAccess(event, toState, toStateParams) {
            if (!toState.data) {
                return;
            }
            var roles = toState.data.roles;
            if (roles && roles.length > 0 && !authService.authentication.isInRoles(roles)) {
                event.preventDefault();
                if (!authService.authentication.isAuth) {
                    authModal.openModal().result.then(function () {
                        $state.go(toState.name, toStateParams);
                    });
                }
                else {
                    toastr.error('Access denied');
                }
            }
        }
    }
})();