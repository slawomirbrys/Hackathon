'use strict';
app.controller('myStocksController', ['$scope', 'stocksService', 'authService', '$interval', function ($scope, stocksService, authService, $interval) {

    $scope.myStocks = [];
    $scope.scopeCode = {
        value: "",
        writable: true
    };

    $interval(function () {
        if (authService.authentication.isAuth) {
            stocksService.getMyStocks().then(function (results) {
                $scope.myStocks = results.data;
            }, function (error) {
                console.log(error.data.message);
            });
        }
    }, 10000);

    stocksService.getMyStocks().then(function (results) {
        $scope.myStocks = results.data;
    }, function (error) {
        console.log(error.data.message);
    });

    $scope.sellStock = function (index) {
        var stockToSell = $scope.myStocks[index];

        stocksService.sellStock(stockToSell.code, function (results) {
        });
        $scope.myStocks.splice(index, 1);
    };
}]);