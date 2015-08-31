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

app.factory('CuponesService', ['$resource',
    function ($resource) {
        return $resource('/api/cupones/list/?tarjetaId=2&anio=2015&mes=5&listarTodos=true',
        {
            'get': { method: 'GET' }
        });
    }
]);

app.controller('ListCuponesController', ['$q', '$scope', '$http', 'CuponesService', 'uiGridConstants', function ($q, $scope, $http, cuponesService, uiGridConstants) {

    var paginationOptions = {
        pageNumber: 1,
        pageSize: 25,
        sort: null
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

        var deferred = $q.defer();

        cuponesService.get(paginationOptions,
               function (result) {
                   deferred.resolve(result);
                   $scope.gridOptions.totalItems = result.TotalCount;
                   $scope.gridOptions.data = result.Items;
               },
                   function (error) {
                       alert(error);
                   }
            );

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
                getPage();
            });
        }
    };



    getPage();

}]);