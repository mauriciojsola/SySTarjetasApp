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

// https://github.com/jirikavi/AngularJS-Toaster 
angular.module('SysApp').factory('MessagingService', ['toaster', function (toaster) {
    return {
        showSuccess: function (message) {
            toaster.pop({
                type: 'success',
                title: '',
                body: message,
                bodyOutputType: 'trustedHtml',
                timeout: 5000
            });
        },

        showError: function (message) {
            toaster.pop({
                type: 'error',
                title: '',
                body: message,
                bodyOutputType: 'trustedHtml',
                timeout: 15000,
                position: 'toast-center'
            });
        },

        showMessage: function (response) {
            var message = response.message;
            message += '<ul>';
            if (response.hasErrors) {
                for (var i = 0; i < response.errors.length; i++) {
                    message += '<li>' + response.errors[i] + '</li>';
                }
            }
            message += '</ul>';

            if (response.hasErrors) {
                toaster.pop({
                    type: 'error',
                    title: '',
                    body: message,
                    bodyOutputType: 'trustedHtml',
                    timeout: 15000,
                    position: 'toast-center'
                });
            } else {
                toaster.pop({
                    type: 'success',
                    title: '',
                    body: message,
                    bodyOutputType: 'trustedHtml',
                    timeout: 5000
                });
            }
        }
    };
}]);