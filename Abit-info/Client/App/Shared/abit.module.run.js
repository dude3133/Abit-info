(function () {
    'use strict';
    angular
        .module('abitApp')
        .run(runApplication);

    runApplication.$inject = ['$rootScope',
                             'authService',
                             'authStateCheck',
                             'formlyConfig',
                             'formlyValidationMessages',
                             'authStateCheck'];

    function runApplication($rootScope,
                            authService,
                            formlyConfig,
                            formlyValidationMessages,
                            authStateCheck) {
        authService.fillAuthData();
        //putStateChecks();

        //function putStateChecks() {
        //    $rootScope.$on('$stateChangeStart', function (event, toState, toStateParams) {
        //        authStateCheck.checkAccess(event, toState, toStateParams);
        //    });
        //}
    }
})();


