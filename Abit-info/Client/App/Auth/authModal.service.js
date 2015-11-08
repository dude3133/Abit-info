(function () {
    'use strict';

    angular
        .module('abitApp')
        .factory('authModal', authModal);

    authModal.$inject = ['$modal'];

    function authModal($modal) {
        var service = {
            openModal: openModal,
            isModalOpen: isModalOpen
        };
        var modalConfig = {
            templateUrl: 'client/app/auth/auth.html',
            controller: 'authController as auth',
            animation: true,
            size: 'md'
        };
        var signupIndex = 2;
        var loginIndex = 1;
        var isOpen = false;

        return service;

        function openModal(tab) {
            if (isOpen) {
                return null;
            }

            isOpen = true;
            if (tab === "signup") {
                modalConfig.resolve = { currTab: signupResolve};
            }
            else {
                modalConfig.resolve = { currTab: loginResolve};
            }
            
            var modalInstance = $modal.open(modalConfig);
            modalInstance.result.finally(function() {
                isOpen = false;
            });
            return modalInstance;
        }
        
        function signupResolve() {
            return signupIndex;
        }

        function loginResolve() {
            return loginIndex;
        }

        function isModalOpen() {
            return isOpen;
        }
    }
})();