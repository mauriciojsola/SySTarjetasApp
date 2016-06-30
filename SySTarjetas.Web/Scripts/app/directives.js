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


angular.module('SysApp').directive('ngOnlyNumber', function () {
    // this directive allowes only numbers with decimal point.
    // You can specify the max decimal points using data-max-decimal-points in the dom element.
    // if data-max-decimal-points is not specified, it will allow upto any dicimal point.
    // https://github.com/rajesh38/ng-only-number
    return {
        restrict: "AE",
        link: function (scope, elem, attr) {
            if (!$(elem).attr("min")) {
                $(elem).attr("min", 0);
            }
            function toIncreaseMaxLengthBy(elem) {
                var maxDecimalPoints = elem.data('maxDecimalPoints');
                return (1 + maxDecimalPoints);
            }
            var el = $(elem)[0];
            el.initMaxLength = elem.data('maxLength');
            el.maxDecimalPoints = elem.data('maxDecimalPoints');
            var checkPositive = function (elem, ev) {
                try {
                    var el = $(elem)[0];
                    if (el.value.indexOf('.') > -1) {
                        if (ev.charCode >= 48 && ev.charCode <= 57) {
                            if (el.value.indexOf('.') === el.value.length - toIncreaseMaxLengthBy(elem)) {
                                if (el.selectionStart > el.value.indexOf('.')) {
                                    return false;
                                } else {
                                    if (el.value.length === elem.data('maxLength')) {
                                        return false;
                                    } else {
                                        return true;
                                    }
                                }
                            } else {
                                if (el.selectionStart <= el.value.indexOf('.')) {
                                    if (el.value.indexOf('.') === toIncreaseMaxLengthBy(elem)) {
                                        return false;
                                    }
                                }
                            }
                        }
                    } else {
                        if (el.value.length === elem.data('maxLength')) {
                            if (ev.charCode === 46) {
                                if (typeof el.maxDecimalPoints === 'undefined') {
                                    return true;
                                } else {
                                    if (el.selectionStart < el.value.length - el.maxDecimalPoints) {
                                        return false;
                                    };
                                }
                                elem.data('maxLength', el.initMaxLength + toIncreaseMaxLengthBy(elem));
                                return true;
                            } else if (ev.charCode >= 48 && ev.charCode <= 57) {
                                return false;
                            }
                        }
                        if (ev.charCode === 46) {
                            if (el.selectionStart < el.value.length - elem.data('maxDecimalPoints')) {
                                return false;
                            } else {
                                return true;
                            }
                        }
                    }
                    if (ev.charCode === 46) {
                        if (el.value.indexOf('.') > -1) {
                            return false;
                        } else {
                            return true;
                        }
                    }
                    if ((ev.charCode < 48 || ev.charCode > 57) && ev.charCode !== 0) {
                        return false;
                    }
                } catch (err) {
                }
                
            };

            var changeMaxlength = function (elem, ev) {
                try {
                    var el = $(elem)[0];
                    if (el.value.indexOf('.') > -1) {
                        elem.data('maxLength', el.initMaxLength + toIncreaseMaxLengthBy(elem));
                    } else {
                        if (elem.data('maxLength') === el.initMaxLength + toIncreaseMaxLengthBy(elem)) {
                            var dotPosPast = el.selectionStart;
                            el.value = el.value.substring(0, dotPosPast);
                        }
                        elem.data('maxLength', el.initMaxLength);
                    }
                } catch (err) {
                }
            };

            $(elem).on("keypress", function (event) {
                return checkPositive(elem, event);
            });

            $(elem).on("input", function (event) {
                return changeMaxlength(elem, event);
            });
        }
    }
});


angular.module('SysApp').directive('editCupon', ['', function () {
    var currentMonth = new Date().getMonth();
    return {
        templateUrl: 'Scripts/app/views/cupones/cupon-form.html',
        scope: {
            customerInfo: '=info'
        }
    }
}]
);
