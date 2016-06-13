'use strict';

angular.module('SysApp').directive('yearDropDown', function () {
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

angular.module('SysApp').directive('monthDropDown', function () {
    var currentMonth = new Date().getMonth();
    return {
        link: function (scope, element, attrs) {
            scope.months = [];
            scope.months.push({ number: 1, name: "Enero" });
            scope.months.push({ number: 2, name: "Febrero" });
            scope.months.push({ number: 3, name: "Marzo" });
            scope.months.push({ number: 4, name: "Abril" });
            scope.months.push({ number: 5, name: "Mayo" });
            scope.months.push({ number: 6, name: "Junio" });
            scope.months.push({ number: 7, name: "Julio" });
            scope.months.push({ number: 8, name: "Agosto" });
            scope.months.push({ number: 9, name: "Setiembre" });
            scope.months.push({ number: 10, name: "Octubre" });
            scope.months.push({ number: 11, name: "Noviembre" });
            scope.months.push({ number: 12, name: "Diciembre" });

            scope.month = { number: currentMonth + 1 };
        },
        template: '<select ng-model="month" ng-options="month.name for month in months track by month.number" ng-change="loadCupones()" class="form-control"><option value="">Seleccione Mes</option></select>'
    }
});

//angular.module('SysApp').directive('datePicker', ['ui.bootstrap.datepicker', function () {
//    var currentMonth = new Date().getMonth();
//    return {
//        link: function (scope, element, attrs) {
//            scope.months = [];
//            scope.months.push({ number: 1, name: "Enero" });
//            scope.months.push({ number: 2, name: "Febrero" });
//            scope.months.push({ number: 3, name: "Marzo" });
//            scope.months.push({ number: 4, name: "Abril" });
//            scope.months.push({ number: 5, name: "Mayo" });
//            scope.months.push({ number: 6, name: "Junio" });
//            scope.months.push({ number: 7, name: "Julio" });
//            scope.months.push({ number: 8, name: "Agosto" });
//            scope.months.push({ number: 9, name: "Setiembre" });
//            scope.months.push({ number: 10, name: "Octubre" });
//            scope.months.push({ number: 11, name: "Noviembre" });
//            scope.months.push({ number: 12, name: "Diciembre" });

//            scope.month = { number: currentMonth + 1 };
//        },
//        template: '<select ng-model="month" ng-options="month.name for month in months track by month.number" ng-change="loadCupones()" class="form-control"><option value="">Seleccione Mes</option></select>'
//    }
//}]
//);

// Draggable directive from: http://docs.angularjs.org/guide/compiler

angular.module('SysApp').directive('draggable', function ($document) {
    "use strict";
    return function (scope, element) {
        var startX = 0,
          startY = 0,
          x = 0,
          y = 0;

        element.css({
            position: 'fixed',
            cursor: 'move'
        });

        element.on('mousedown', function (event) {
            // Prevent default dragging of selected content
            //event.preventDefault();
            startX = event.screenX - x;
            startY = event.screenY - y;
            $document.on('mousemove', mousemove);
            $document.on('mouseup', mouseup);
        });

        function mousemove(event) {
            y = event.screenY - startY;
            x = event.screenX - startX;
            element.css({
                top: y + 'px',
                left: x + 'px'
            });
        }

        function mouseup() {
            $document.unbind('mousemove', mousemove);
            $document.unbind('mouseup', mouseup);
        }
    };
});
