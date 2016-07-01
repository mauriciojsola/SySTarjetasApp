'use strict';

angular.module('SysApp').service('CuponesService', ['$q', '$http', 'CuponesRepo', function ($q, $http, cuponesRepo) {
    return {
        listCupones: function (limit) {
            return cuponesRepo.list(limit).$promise;
        },

        getCupon: function (cuponId) {
            return cuponesRepo.get({ id: cuponId });
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
            return titularesRepo.list(limit).$promise;
        },
        selectTitulares: function (limit) {
            return titularesRepo.select(limit).$promise;
        },
        getTitular: function (titularId) {
            return titularesRepo.get({ id: titularId });
        }
    };
}]);


angular.module('SysApp').service('TarjetasService', ['$q', 'TarjetasRepo', function ($q, tarjetasRepo) {
    return {
        listTarjetas: function (limit) {
            return tarjetasRepo.list(limit).$promise;
        },
        selectTarjetas: function (limit) {
            return tarjetasRepo.select(limit).$promise;
        }
    };
}]);


angular.module('SysApp').service('ComerciosService', ['$q', 'ComerciosRepo', function ($q, comerciosRepo) {
    return {
        listComercios: function (limit) {
            return comerciosRepo.query(limit).$promise;
        },
        selectComercios: function (limit) {
            return comerciosRepo.select(limit).$promise;
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

