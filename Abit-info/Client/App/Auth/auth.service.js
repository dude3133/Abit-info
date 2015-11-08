(function () {
    'use strict';
    angular
        .module('abitApp')
        .factory('authService', authService);

    authService.$inject = ['$http', '$q', 'localStorageService'];

    function authService($http, $q, localStorageService) {

        var authentication = {
            isAuth: false,
            userName: "",
            roles: [],
            isInRoles: isInRoles
        };
        var externalAuthData = {
            provider: "",
            userName: "",
            externalAccessToken: ""
        };
        var authServiceFactory = {
            saveRegistration: saveRegistration,
            login: login,
            logOut: logOut,
            fillAuthData: fillAuthData,
            authentication: authentication,
            externalAuthData: externalAuthData,
            obtainAccessToken: obtainAccessToken,
            registerExternal: registerExternal
        };
        return authServiceFactory;

        function registerExternal(registerExternalData) {
            var deferred = $q.defer();

            $http.post('api/facebook/register', registerExternalData)
                .success(function (response) {
                    var roles = $.parseJSON(response.roles);
                    localStorageService.set('authorizationData', {
                        token: response.access_token,
                        userName: response.userName,
                        roles: roles,
                        refreshToken: "",
                        useRefreshTokens: false
                    });

                    authentication.isAuth = true;
                    authentication.userName = response.userName;
                    authentication.useRefreshTokens = false;
                    authentication.roles = roles;

                    deferred.resolve(response);

                }).error(function (err, status) {
                    _logOut();
                    deferred.reject(err);
                });

            return deferred.promise;
        }

        function obtainAccessToken(externalData) {
            var deferred = $q.defer();

            $http.get('api/Facebook/ObtainLocalAccessToken', {
                params: {
                    provider: externalData.provider,
                    externalAccessToken: externalData.externalAccessToken
                }
            }).success(function (response) {
                var roles = $.parseJSON(response.roles);
                localStorageService.set('authorizationData', {
                    token: response.access_token,
                    userName: response.userName,
                    roles: roles,
                    refreshToken: "",
                    useRefreshTokens: false
                });

                authentication.isAuth = true;
                authentication.userName = response.userName;
                authentication.useRefreshTokens = false;
                authentication.roles = roles;

                deferred.resolve(response);

            }).error(function (err, status) {
                _logOut();
                deferred.reject(err);
            });

            return deferred.promise;
        }

        function saveRegistration(registration) {
            logOut();
            return $http.post('api/account/register', registration).then(function (response) {
                return response;
            });

        }

        function login(loginData) {

            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

            var deferred = $q.defer();

            $http.post('token', data, {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            })
                .success(function (response) {
                    var roles = $.parseJSON(response.roles);
                    localStorageService.set('authorizationData', {
                        token: response.access_token,
                        userName: loginData.userName,
                        roles: roles
                    });
                    authentication.isAuth = true;
                    authentication.userName = loginData.userName;
                    authentication.roles = roles;
                    deferred.resolve(response);

                }).error(function (err) {
                    logOut();
                    deferred.reject(err);
                });

            return deferred.promise;
        }

        function logOut() {
            localStorageService.remove('authorizationData');
            authentication.isAuth = false;
            authentication.userName = "";
            authentication.roles = [];
        }

        function fillAuthData() {
            var authData = localStorageService.get('authorizationData');
            if (authData) {
                authentication.isAuth = true;
                authentication.userName = authData.userName;
                authentication.roles = authData.roles;
            }
        }

        function isInRoles(roles) {
            return _.any(roles, function (item) {
                return _.include(authentication.roles, item);
            });
        }
    }
})();