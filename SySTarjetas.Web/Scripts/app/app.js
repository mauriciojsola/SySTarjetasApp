'use strict';

angular.module('SysApp', ['ngRoute', 'ngResource', 'ui.bootstrap', 'toaster', 'chieffancypants.loadingBar', 'ui.grid', 'ui.grid.pagination', 'angularModalService', 'mgcrea.ngStrap.datepicker', 'ngMessages', 'ngAnimate']);

angular.module('SysApp').config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when("/cupones", {
            controller: "ListCuponesController",
            templateUrl: "Scripts/app/views/cupones/list.html"
        })
        .when("/cupones/new", {
            controller: "NuevoCuponController",
            templateUrl: "Scripts/app/views/cupones/new.html",
            resolve: {
                cuponModel: ['CuponViewModel', function (cuponViewModel) {
                    return cuponViewModel.getNew();
                }]
            }
        })
        .when("/cupones/:id", {
            controller: "EditarCuponController",
            templateUrl: "Scripts/app/views/cupones/edit.html",
            resolve: {
                cuponModel: ['CuponesService', '$route', function (cuponesService, $route) {
                    return cuponesService.getCupon($route.current.params.id).$promise;
                }]
            }
        })
        .when("/index", {
            templateUrl: "Scripts/app/views/index.html"
        });
    $routeProvider.otherwise({ redirectTo: "/index" });

}]);

angular.module('SysApp')
    .config(function ($datepickerProvider) {
        angular.extend($datepickerProvider.defaults, {
            dateFormat: 'dd/MM/yyyy',
            startWeek: 1
        });
    });

angular
  .module('SysApp')
  .config(['toasterConfig', function (toasterConfig) {
      toasterConfig['close-button'] = true;
      //toasterConfig['time-out'] = 5000;
      toasterConfig['position-class'] = 'toast-top-center';
      toasterConfig['limit'] = 1;
    }]);


