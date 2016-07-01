'use strict';

angular.module('SysApp').factory('CuponesRepo', ['$resource',
    function ($resource) {
        return $resource('/api/cupones/:id', { id: '@id' }, {
            query: { method: 'GET', params: {}, isArray: true },
            list: { url: '/api/cupones/list', method: 'GET', params: {}, isArray: false },
            select: { url: '/api/cupones/select', method: 'GET', params: {}, isArray: false }
        });
    }
]);

angular.module('SysApp').factory('TitularesRepo', ['$resource',
    function ($resource) {
        return $resource('/api/titulares/:id', { id: '@id' }, {
            query: { method: 'GET', params: {}, isArray: true },
            list: { url: '/api/titulares/list', method: 'GET', params: {}, isArray: true },
            select: { url: '/api/titulares/select', method: 'GET', params: {}, isArray: true }
        });
    }
]);

angular.module('SysApp').factory('TarjetasRepo', ['$resource',
    function ($resource) {
        return $resource('/api/tarjetas/:id', { id: '@id' }, {
            query: { method: 'GET', params: {}, isArray: true },
            list: { url: '/api/tarjetas/list/titular/:titularId', method: 'GET', params: { titularId: '@titularId' }, isArray: true },
            select: { url: '/api/tarjetas/select/titular/:titularId', method: 'GET', params: {}, isArray: true }
        });
    }
]);

angular.module('SysApp').factory('ComerciosRepo', ['$resource',
    function ($resource) {
        return $resource('/api/comercios/:id', { id: '@id' }, {
            query: { method: 'GET', params: {}, isArray: true },
            list: { url: '/api/comercios/list', method: 'GET', params: {}, isArray: true },
            select: { url: '/api/comercios/select', method: 'GET', params: {}, isArray: true }
        });
    }
]);

// https://github.com/jirikavi/AngularJS-Toaster 
angular.module('SysApp').factory('AlertService', ['toaster', function (toaster) {
    return {
        showSuccess: function (message) {
            toaster.pop({
                type: 'success',
                title: '',
                body: message,
                bodyOutputType: 'trustedHtml',
                timeout: 20000
            });
        },

        showError: function (message) {
            toaster.pop({
                type: 'error',
                title: '',
                body: message,
                bodyOutputType: 'trustedHtml',
                timeout: 20000,
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
                    timeout: 20000,
                    position: 'toast-center'
                });
            } else {
                toaster.pop({
                    type: 'success',
                    title: '',
                    body: message,
                    bodyOutputType: 'trustedHtml',
                    timeout: 20000
                });
            }
        }
    };
}]);

angular.module('SysApp').factory('CuponViewModel', [
    function () {
        return {
            getNew: function () {
                var now = new Date();
                return {
                    id: 0,
                    titularId: '',
                    tarjetaId: '',
                    comercioId: '',
                    selectedDate: now,
                    numeroCupon: null,
                    importe: null,
                    cuotas: null
                };
            }
        }
    }
]);
