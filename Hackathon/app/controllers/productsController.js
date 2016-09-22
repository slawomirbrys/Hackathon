'use strict';
app.controller('productsController', ['$scope', 'productService', 'authService', function ($scope, productService, authService) {

    $scope.products = [];

    productService.getProducts().then(function (results) {
        $scope.products = results.data;
    }, function (error) {
        console.log(error.data.message);
    });

}]);