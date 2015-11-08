(function () {
	'use strict';
	angular
        .module('abitApp')
        .factory('authInterceptorService', authInterceptorService);

	authInterceptorService.$inject = ['$q', '$location', 'localStorageService', '$injector'];

	function authInterceptorService($q, $location, localStorageService, $injector) {

	    var authModal;
		var authInterceptorServiceFactory = {
			request: request,
			responseError: responseError
		};
		return authInterceptorServiceFactory;


		function request(config) {

			config.headers = config.headers || {};

			var authData = localStorageService.get('authorizationData');
			if (authData) {
				config.headers.Authorization = 'Bearer ' + authData.token;
			}
			return config;
		}

		function responseError(rejection) {
		    authModal = authModal || $injector.get("authModal");
		    if (rejection.status === 401) {
			    authModal.openModal();
			}
			return $q.reject(rejection);
		}
	}
})();