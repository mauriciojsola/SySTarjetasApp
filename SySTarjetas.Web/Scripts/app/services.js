'use strict';

angular.module('SysApp').service('CuponesService', ['$q', '$http', 'CuponesRepo', function ($q, $http, cuponesRepo) {
    return {
        listCupones: function (limit) {
            return cuponesRepo.get(limit).$promise;
        },

        saveCupon: function (cupon) {
            $http.post('api/cupones/save',cupon);
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