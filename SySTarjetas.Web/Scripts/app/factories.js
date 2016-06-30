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

angular.module('SysApp').factory('MessagingService', ['toaster', function (toaster) {
    return {
        showSuccess: function (message) {
            toaster.pop('success', '', message);
        }
    };
}]);