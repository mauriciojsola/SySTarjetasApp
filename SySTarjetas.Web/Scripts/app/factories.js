'use strict';

angular.module('SysApp').factory('CuponesRepo', ['$resource',
    function ($resource) {
        return $resource('/api/cupones/list/',
        {
            'get': { method: 'GET' }
        });
    }
]);

angular.module('SysApp').factory('TitularesRepo', ['$resource',
    function ($resource) {
        return $resource('/api/titulares/list/',
        {
            'query': {
                method: 'GET', isArray: true
            }
        });
    }
]);

angular.module('SysApp').factory('TarjetasRepo', ['$resource',
    function ($resource) {
        return $resource('/api/tarjetas/list/',
        {
            'query': {
                method: 'GET', isArray: true
            }
        });
    }
]);


angular.module('SysApp').factory('ComerciosRepo', ['$resource',
    function ($resource) {
        return $resource('/api/comercios/list/',
        {
            'query': {
                method: 'GET', isArray: true
            }
        });
    }
]);

// https://github.com/jirikavi/AngularJS-Toaster toast-center
angular.module('SysApp').factory('MessagingService', ['toaster', function (toaster) {
    return {
        showSuccess: function (message) {
            toaster.pop({
                type: 'success',
                title: '',
                body: message,
                timeout: 5000
            });
        },

        showError: function (responseError) {
            var message = responseError.message;
            message += '<ul>';
            if (responseError.hasErrors) {
                for (var i = 0; i < responseError.errors.length; i++) {
                    message += '<li>' + responseError.errors[i] + '</li>';
                }
            }
            message += '</ul>';

            toaster.pop({
                type: 'error',
                title: '',
                body: message,
                bodyOutputType: 'trustedHtml',
                timeout: 15000,
                position: 'toast-center'
            });
        }
    };
}]);