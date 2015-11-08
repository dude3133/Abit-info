(function() {
    'use strict';

    angular
        .module('abitApp')
        .directive('equals', equals);

    equals.$inject = [];
    
    function equals () {
        var directive = {
            require: 'ngModel',
            link: link,
            restrict: 'A',
            scope: {
                check: '='
            }
        };
        return directive;

        function link(scope, element, attrs, ctrl) {
            ctrl.$validators.equals = function(modelValue, viewValue) {
                return modelValue === scope.check;
            }
        }
    }

})();