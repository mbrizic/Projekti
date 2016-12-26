﻿'use strict';

businessInteligenceApp.controller('obsoleteSupplies', ['$scope', 'reportsService', 'identityService', 'localizationService', 'DTOptionsBuilder', 'DTColumnBuilder', function ($scope, reportsService, identityService, localizationService, DTOptionsBuilder, DTColumnBuilder) {

    $scope.retailWholesalePlantTypes = 3;

    var currentMonth = (new Date).getMonth() + 1;
    var currentDay = (new Date).getDate();
    $scope.dateFrom = new Date('2013-01-01');
    $scope.dateTo = new Date('2013-' + currentMonth + '-' + currentDay);

    $scope.quantityFrom = 0;
    $scope.quantityTo = 1;

    var identity = identityService.getIdentity();
    if (identity)
        $scope.currentCompanyId = identity.defaultCompanyId;

    $scope.reportColumns = [
        DTColumnBuilder.newColumn('number').withTitle('Redni broj'),
        DTColumnBuilder.newColumn('productCode').withTitle('Šifra'),
        DTColumnBuilder.newColumn('productBarcode').withTitle('Barkod'),
        DTColumnBuilder.newColumn('productName').withTitle('Naziv'),
        DTColumnBuilder.newColumn('stockQuantity').withTitle('Lager'),
        DTColumnBuilder.newColumn('quantity').withTitle('Količina')
    ];

    $scope.reportFooter = '<tfoot><tr><th></th><th></th><th></th><th></th><th></th><th></th></tr></tfoot>';

    $scope.getReport = function (reportFilters) {

        var promise = reportsService.getObsoleteSupplies(reportFilters);

        promise.then(function (data) {
            $scope.reportOptions = DTOptionsBuilder.fromFnPromise(function () { return promise; })
                .withDataProp('items')
                .withPaginationType('full_numbers')
                .withDisplayLength(50)
                .withTableTools('/Content/libraries/datatables-v1.10.4/swf/copy_csv_xls_pdf.swf')
                .withTableToolsButtons(['xls'])
                .withOption('footerCallback', function () {
                    var api = this.api();
                    $(api.column(4).footer()).html(data.totals.stockQuantity);
                    $(api.column(5).footer()).html(data.totals.quantity);
                });
        });

    };

}]);