﻿'use strict';
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

    $scope.getTotal = function () {
        return 123.45.toFixed(2);
    }

    $scope.getTotalLoan = function (interest) {
        return ($scope.getTotal() * interest).toFixed(2);
    }

    $scope.getPaymentLoan = function (months, interest) {
        return ($scope.getTotal() * interest / months).toFixed(2);
    }

}]);