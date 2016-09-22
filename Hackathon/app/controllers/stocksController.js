'use strict';
app.controller('stocksController', ['$scope', 'stocksService', 'authService', '$interval', function ($scope, stocksService, authService, $interval) {

    $scope.stocks = [];

    stocksService.getStocks().then(function (results) {
        $scope.stocks = results.data;
    }, function (error) {
        console.log(error.data.message);
    });

    $scope.buyStock = function (index) {
        var stockToBuy = $scope.stocks[index];
        stocksService.buyStock(stockToBuy.code);
        stockToBuy.isMyStock = true;
    };

    $interval(function () {
        if (authService.authentication.isAuth) {
            stocksService.getStocks().then(function (results) {
                $scope.stocks = results.data;
            }, function (error) {
                console.log(error.data.message);
            });
        }
    }, 10000);


}]);