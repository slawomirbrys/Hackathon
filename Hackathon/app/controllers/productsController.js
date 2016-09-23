'use strict';
app.controller('productsController', ['$scope', '$location', 'productService', 'authService', function ($scope, $location, productService, authService) {

    $scope.products = [];

    $scope.slider = {
        value: 123
    };

    productService.getProducts().then(function (results) {
        $scope.products = results.data;
    }, function (error) {
        console.log(error.data.message);
    });

    $scope.buyStock = function (index) {
        $location.path('/shoppingCart');
    };

    $scope.getTotal = function () {
        return 123.00.toFixed(2);
    }

    $scope.getTotalLoan = function (interest) {
        return ($scope.getTotal() * interest).toFixed(2);
    }

    $scope.getPaymentLoan = function (months, interest) {
        return ($scope.slider.value * interest / months).toFixed(2);
    }

    $scope.getRandomArbitrary = function (min, max) {
        return (Math.random() * (max - min) + min).toFixed(2);
    }

}]);