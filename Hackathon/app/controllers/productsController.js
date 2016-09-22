'use strict';
app.controller('productsController', ['$scope', '$location', 'productService', 'authService', function ($scope, $location, productService, authService) {

    $scope.products = [];

    productService.getProducts().then(function (results) {
        $scope.products = results.data;
    }, function (error) {
        console.log(error.data.message);
    });

    $scope.buyStock = function (index) {
        $location.path('/shoppingCart');
    };

}]);