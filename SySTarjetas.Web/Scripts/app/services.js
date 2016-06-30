﻿'use strict';

angular.module('SysApp').service('CuponesService', ['$q', '$http', 'CuponesRepo', function ($q, $http, cuponesRepo) {
    return {
        listCupones: function (limit) {
            return cuponesRepo.get(limit).$promise;
        },

        saveCupon: function (cupon, callbackSuccess, callbackError) {
            $http.post('api/cupones/save', cupon)
                .then(function (success) {
                    if (callbackSuccess) {
                        callbackSuccess(success);
                    }
                }, function (error) {
                    if (callbackError) {
                        callbackError(error);
                    }
                });
        }
    };

}]);


angular.module('SysApp').service('TitularesService', ['$q', 'TitularesRepo', function ($q, titularesRepo) {
    return {
        listTitulares: function (limit) {
            return titularesRepo.query(limit).$promise;
        }
    };
}]);


angular.module('SysApp').service('TarjetasService', ['$q', 'TarjetasRepo', function ($q, tarjetasRepo) {
    return {
        listTarjetas: function (limit) {
            return tarjetasRepo.query(limit).$promise;
        }
    };
}]);


angular.module('SysApp').service('ComerciosService', ['$q', 'ComerciosRepo', function ($q, comerciosRepo) {
    return {
        listComercios: function (limit) {
            return comerciosRepo.query(limit).$promise;
        }
    };
}]);


angular.module('SysApp').service('Utils', [function () {
    this.parseResponse = function (response) {
        var result = {};
        if (angular.isDefined(response.data)) {
            var data = response.data;

            result.success = data.Success;
            result.message = data.Message;
            result.hasErrors = data.HasErrors;
            result.errors = [];

            if (angular.isDefined(data.Errors)) {
                for (var i = 0; i < data.Errors.length; i++) {
                    result.errors.push(data.Errors[i]);
                }
            }
        }
        return result;
    }
}]);

