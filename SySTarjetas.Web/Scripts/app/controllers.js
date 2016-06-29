'use strict';

angular.module('SysApp').controller('ListCuponesController', ['$q', '$scope', '$http', 'uiGridConstants', 'ModalService', '$log', 'TitularesService', 'TarjetasService', 'CuponesService',
                function ($q, $scope, $http, uiGridConstants, ModalService, $log, titularesService, tarjetasService, cuponesService) {

                    $scope.pageSize = 25;
                    $scope.pageNumber = 1;
                    $scope.sort = null;

                    var now = new Date();
                    $scope.selectedDate = now;

                    var getQueryParams = function () {
                        return {
                            tarjetaId: $scope.tarjeta ? $scope.tarjeta.Id : null,
                            anio: $scope.year ? $scope.year : null,
                            mes: $scope.month ? $scope.month.number : null,
                            listarTodos: $scope.listarTodos ? $scope.listarTodos : false
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
                            cuponesService.listCupones(paginationOptions).then(function (result) {
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
                        enableFiltering: true,
                        resizable: true,
                        columnDefs: [
                            { field: 'FechaCompra', displayName: 'Fecha Compra', enableSorting: false },
                            { field: 'NumeroCupon', displayName: 'Numero Cupón', enableSorting: false },
                            { field: 'Comercio', displayName: 'Razón Social', enableSorting: true },
                            { field: 'Cuotas', displayName: 'Cuotas', enableSorting: false },
                            { field: 'ImporteFormateado', displayName: 'Importe', enableSorting: false },
                            { field: 'Id', displayName: 'Actions', cellTemplate: '<div class="ui-grid-cell-contents"><button class="btn btn-warning btn-xs" ng-click="grid.appScope.editCupon(row.entity.Id)"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span> Edit&nbsp;</button></div>' }
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

                    titularesService.listTitulares().then(
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
                            $scope.tarjetas = tarjetasService.listTarjetas({ titularId: titularId }).then(
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

                    $scope.editCupon = function (cuponId) {
                        alert(cuponId);
                    };

                    //$scope.agregarCupon = function () {
                    //    ModalService.showModal({
                    //        templateUrl: 'scripts/app/views/cupones/new.html',
                    //        controller: "AgregarCuponController"
                    //    }).then(function (modal) {
                    //        //it's a bootstrap element, use 'modal' to show it
                    //        modal.element.modal();
                    //        modal.close.then(function (result) {
                    //            //$log.info('Modal dismissed at: ' + new Date() + " RESULT: " + result);
                    //            console.debug(result);
                    //        });
                    //    });
                    //};

                    $scope.newCupon = function () {

                    };

                }
]);

angular.module('SysApp').controller('EditarCuponesController', ['$scope', 'TitularesService', 'TarjetasService', 'CuponesService', 'ComerciosService',
    function ($scope,titularesService, tarjetasService, cuponesService, comerciosService) {
        $scope.titulares = [];
        $scope.titularId = null;
        $scope.tarjetas = [];
        $scope.tarjetaId = null;
        $scope.comercios = [];
        $scope.comercioId = null;
        var now = new Date();
        $scope.selectedDate = now;

        titularesService.listTitulares().then(
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

        comerciosService.listComercios().then(
                               function (result) {
                                   $scope.comercios = result;
                               },
                               function (error) {
                                   alert(error);
                               }
                           );


        $scope.loadCards = function () {
            var titularId = $scope.titular ? $scope.titular.Id : null;
            if (titularId) {
                $scope.tarjetas = tarjetasService.listTarjetas({ titularId: titularId }).then(
                    function (result) {
                        $scope.tarjetas = result;
                    });
            } else {
                $scope.tarjetas = null;
            }
        };

        $scope.saveCupon = function () {

            if (!$scope.newCuponForm.$valid)
                return;

            var cupon = {
                TitularId: $scope.titular.Id,
                TarjetaId: $scope.tarjeta.Id,
                ComercioId: $scope.comercio.Id,
                FechaCompra: $scope.selectedDate,
                NumeroCupon: $scope.numeroCupon,
                Importe: $scope.importe,
                Cuotas: $scope.cuotas
        }
            cuponesService.saveCupon(cupon);
            $scope.newCuponForm.$setPristine();
        };

    }]);


angular.module('SysApp').controller('AgregarCuponController', ['$scope', '$element', 'close', function ($scope, $element, close) {
    $scope.close = function () {
        close({
            name: $scope.name,
            username: $scope.username,
            email: $scope.email
        }, 500); // close, but give 500ms for bootstrap to animate
    };

    //  This cancel function must use the bootstrap, 'modal' function because
    //  the doesn't have the 'data-dismiss' attribute.
    $scope.cancel = function () {
        //  Manually hide the modal.
        $element.modal('hide');

        //  Now call close, returning control to the caller.
        close({
            name: $scope.name,
            username: $scope.username,
            email: $scope.email
        }, 500); // close, but give 500ms for bootstrap to animate
    };

}]);