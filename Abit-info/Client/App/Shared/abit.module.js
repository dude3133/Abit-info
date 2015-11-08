(function () {
    'use strict';
    angular
        .module('abitApp',
        ['angularUtils.directives.dirPagination',
            'ngMaterial',
            'ui.router',
            'ngMessages',
            'ngAnimate',
            'LocalStorageModule',
            'formly',
            'formlyBootstrap',
            'ngAria',
            'ui.bootstrap',
            'luegg.directives',
            'chart.js',
            'toastr',
            'ngProgressLite'
        ]);
})();