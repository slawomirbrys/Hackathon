'use strict';
app.factory('productService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var productServiceFactory = {};

    var _getProducts = function () {
        return $http.get('data/products.json').then(function (results){
            //return $http.get(serviceBase + 'api/books').then(function (results) {
            return results;
        });
    };

    var _getBanks = function () {
        return $http.get('data/bank.json').then(function (results) {
            //return $http.get(serviceBase + 'api/books').then(function (results) {
            return results;
        });
    };

    productServiceFactory.getProducts = _getProducts;
    productServiceFactory.getBanks = _getBanks;

return productServiceFactory;

}]);