(function () {
    angular
        .module('abitApp')
        .config(routesConfig);

    routesConfig.$inject = ['$stateProvider', '$urlRouterProvider'];

    function routesConfig($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('mainPage', {
                templateUrl: '../Client/App/Main/main.html',
                controller: 'mainPageController as main',
                url: '/'
            })
            .state('users', {
                controller: "userController as users",
                templateUrl: "../Client/App/Applicant/applicants.html",
                url: '/users'
            })
            .state('universities', {
                controller: 'universitiesListController as univlist',
                templateUrl: '../Client/App/University/list/universitiesList.html',
                url: '/universities',
                resolve: {
                    universitiesCount: universitiesCountResolve
                }
            })
            .state('university', {
                controller: 'universitiesListController as univlist',
                templateUrl: '../Client/App/University/list/universitiesList.html',
                url: '/university/:id',
                resolve: {
                    universityInfo: universityInfoResolve
                }
            })
            .state('admin', {
                controller: 'adminController as admin',
                templateUrl: '../Client/App/admin/admin.panel.html',
                url: '/admin',
                data: {
                    roles: ['Admin']
                }
            })
            .state('associate', {
                controller: 'associateController as associate',
                templateUrl: '../Client/App/auth/associate.html',
                url: '/associate'
            })
            .state('streamBoard', {
                controller: 'adminController as admin',
                templateUrl: '../Client/App/admin/admin.panel.html',
                url: '/admin',
                data: {
                    roles: ['User']
                }
            });


        $urlRouterProvider.otherwise('/');

        universitiesCountResolve.$inject = ['universitiesListService'];
        function universitiesCountResolve(universitiesListService) {
            return universitiesListService.getUniversitiesCount();
        }

        universityInfoResolve.$inject = ['$stateParams','universityService'];
        function universityInfoResolve($stateParams, universityService) {
            return universityService.getUnivesity($stateParams.Id);
        }
        //facultyInfoResolve.$inject = ['$stateParams', 'facultyService'];
        //function facultyInfoResolve($stateParams, eventService) {
        //    return facultyService.getFacultyData($stateParams.id);
        //}
    }
})();
