'use strict';

var app = angular.module('SysApp', ['ngRoute', 'ngResource', 'ui.bootstrap', 'toaster', 'chieffancypants.loadingBar', 'ui.grid', 'ui.grid.pagination']);

app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider.when("/cupones", {
        controller: "ListCuponesController",
        templateUrl: "Scripts/app/views/cuponeslist.html"
    })
    .when("/index", {
        templateUrl: "Scripts/app/views/index.html"
    });
    $routeProvider.otherwise({ redirectTo: "/index" });

}]);

app.factory('CuponesRepo', ['$resource',
    function ($resource) {
        return $resource('/api/cupones/list/',
        {
            'get': { method: 'GET' }
        });
    }
]);

app.factory('TitularesRepo', ['$resource',
    function ($resource) {
        return $resource('/api/titulares/list/',
        {
            'query': {
                method: 'GET', isArray: true
            }
        });
    }
]);

app.factory('TarjetasRepo', ['$resource',
    function ($resource) {
        return $resource('/api/tarjetas/list/',
        {
            'query': {
                method: 'GET', isArray: true
            }
        });
    }
]);

app.service('ListCuponesService', ['$q', 'CuponesRepo', 'TitularesRepo', 'TarjetasRepo', function ($q, cuponesRepo, titularesRepo, tarjetasRepo) {
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

app.directive('yearDropDown', function () {
    var currentYear = new Date().getFullYear();
    return {
        link: function (scope, element, attrs) {
            scope.years = [];

            for (var i = (currentYear - parseInt(attrs.offset)) ; i < (currentYear + parseInt(attrs.offset)) ; i++) {
                scope.years.push(i);
            }
            scope.year = currentYear;
        },
        template: '<select ng-model="year" ng-options="year for year in years" ng-change="loadCupones()" class="form-control"><option value="">Seleccione Año</option></select>'
    }
});

app.directive('monthDropDown', function () {
    var currentMonth = new Date().getMonth();
    return {
        link: function (scope, element, attrs) {
            scope.months = [];
            scope.months.push({ number: 1, name: "Enero" });
            scope.months.push({ number: 2, name: "Febrero" });
            scope.months.push({ number: 8, name: "Agosto" });
            scope.months.push({ number: 9, name: "Setiembre" });

            scope.month = {number : currentMonth};
        },
        template: '<select ng-model="month" ng-options="month.name for month in months track by month.number" ng-change="loadCupones()" class="form-control"><option value="">Seleccione Mes</option></select>'
    }
});


app.controller('ListCuponesController', [
    '$q', '$scope', '$http', 'uiGridConstants', 'ListCuponesService', function ($q, $scope, $http, uiGridConstants, listCuponesService) {

        $scope.pageSize = 25;
        $scope.pageNumber = 1;
        $scope.sort = null;

        var getQueryParams = function () {
            return {
                tarjetaId: $scope.tarjeta ? $scope.tarjeta.Id : null,
                anio: $scope.year ? $scope.year : null,
                mes: $scope.month ? $scope.month.number : null,
                listarTodos: false
            }
        }
        
        var params = getQueryParams();

        // Init pagination
        var paginationOptions = {
            pageNumber: $scope.pageNumber,
            pageSize: $scope.pageSize,
            sort: null,
            tarjetaId: params.tarjetaId,
            anio: params.anio,
            mes: params.mes,
            listarTodos: params.listarTodos
        };

        var getCupones = function () {

            if (paginationOptions.tarjetaId) {
                listCuponesService.listCupones(paginationOptions).then(function (result) {
                    $scope.gridOptions.totalItems = result.TotalCount;
                    $scope.gridOptions.data = result.Items;
                },
                    function (error) {
                        console.debug(error);
                    });
            } else {
                $scope.gridOptions.totalItems = 0;
                $scope.gridOptions.data = [];
            }
        };

        var getPage = function () {
            var url;
            switch (paginationOptions.sort) {
                case uiGridConstants.ASC:
                    url = '/data/100_ASC.json';
                    break;
                case uiGridConstants.DESC:
                    url = '/data/100_DESC.json';
                    break;
                default:
                    url = '/data/100.json';
                    break;
            }
            getCupones();
        };

       

        $scope.gridOptions = {
            paginationPageSizes: [25, 50, 100],
            paginationPageSize: 25,
            useExternalPagination: true,
            useExternalSorting: true,
            enableFiltering: false,
            columnDefs: [
                { name: 'Id' },
                { name: 'RazonSocial', enableSorting: false },
                { name: 'FechaCompra', enableSorting: false }
            ],
            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;
                $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                    if (sortColumns.length === 0) {
                        paginationOptions.sort = null;
                    } else {
                        paginationOptions.sort = sortColumns[0].sort.direction;
                    }
                    getPage();
                });
                gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                    paginationOptions.pageNumber = newPage;
                    paginationOptions.pageSize = pageSize;
                    $scope.pageSize = pageSize;
                    $scope.pageNumber = newPage;
                    getPage();
                });
            }
        };

        getPage();

        $scope.titulares = [];
        $scope.titularId = null;
        $scope.tarjetas = [];
        $scope.tarjetaId = null;

        listCuponesService.listTitulares().then(
            function (result) {
                $scope.titulares = result;
                $scope.titular = null;
                $scope.tarjeta = null;
                $scope.loadCards();
            },
            function (error) {
                alert(error);
            }
        );

        $scope.loadCards = function () {
            var titularId = $scope.titular ? $scope.titular.Id : null;
            if (titularId) {
                $scope.tarjetas = listCuponesService.listTarjetas({ titularId: titularId }).then(
                    function (result) {
                        $scope.tarjetas = result;
                    });
            } else {
                $scope.tarjetas = null;
            }
        };

        $scope.loadCupones = function () {
            params = getQueryParams();

            paginationOptions = {
                pageNumber: $scope.pageNumber ? $scope.pageNumber : 1,
                pageSize: $scope.pageSize ? $scope.pageSize : 25,
                sort: null,
                tarjetaId: params.tarjetaId,
                anio: params.anio,
                mes: params.mes,
                listarTodos: params.listarTodos
            };
            getCupones();

        };

    }
]);