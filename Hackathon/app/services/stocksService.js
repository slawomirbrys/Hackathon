'use strict';
app.factory('stocksService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var stocksServiceFactory = {};

    var _getStocks = function () {
        return $http.get(serviceBase + 'api/stocks').then(function (results) {
            return results;
        });
    };

    var _getMyStocks = function () {
        return $http.get(serviceBase + 'api/mystocks').then(function (results) {
            return results;
        });
    };

    var _buyStock = function (stockCode) {
        return $http.put(serviceBase + 'api/mystocks/' + stockCode, { data: stockCode }).then(function (results) {
            return results;
        });
    };

    var _sellStock = function (stockCode) {
        return $http.delete(serviceBase + 'api/mystocks/' + stockCode, { data: stockCode }).then(function (results) {
            return results;
        });
    };

    stocksServiceFactory.getStocks = _getStocks;
    stocksServiceFactory.getMyStocks = _getMyStocks;
    stocksServiceFactory.buyStock = _buyStock;
    stocksServiceFactory.sellStock = _sellStock;


    return stocksServiceFactory;

}]);