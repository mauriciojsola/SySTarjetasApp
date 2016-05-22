'use strict';

angular.module('SysApp').service('ListCuponesService', ['$q', 'CuponesRepo', 'TitularesRepo', 'TarjetasRepo', function ($q, cuponesRepo, titularesRepo, tarjetasRepo) {
    return {
        listCupones: function (limit) {
            return cuponesRepo.get(limit).$promise;
        },

        listTitulares: function () {
            return titularesRepo.query().$promise;
        },

        listTarjetas: function (limit) {
            return tarjetasRepo.query(limit).$promise;
        }
    };

}]);