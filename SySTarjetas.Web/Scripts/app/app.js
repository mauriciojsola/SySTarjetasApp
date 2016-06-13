﻿'use strict';

angular.module('SysApp', ['ngRoute', 'ngResource', 'ui.bootstrap', 'toaster', 'chieffancypants.loadingBar', 'ui.grid', 'ui.grid.pagination', 'angularModalService', 'mgcrea.ngStrap.datepicker']);

angular.module('SysApp').config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when("/cupones", {
            controller: "CuponesController",
            templateUrl: "Scripts/app/views/cupones/list.html"
        })
        .when("/cupones/new", {
            controller: "CuponesController",
            templateUrl: "Scripts/app/views/cupones/new.html"
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


