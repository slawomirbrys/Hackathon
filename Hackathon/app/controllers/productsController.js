'use strict';
app.controller('productsController', ['$scope', '$location', 'productService', 'authService', 'ModalService', function ($scope, $location, productService, authService, ModalService) {

    $scope.products = [];
    $scope.message = "";

    $scope.slider = {
        value: 1210
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
        return 1210.00.toFixed(2);
    }

    $scope.getTotalLoan = function (interest) {
        return ($scope.getTotal() * interest).toFixed(2);
    }

    $scope.getPaymentLoan = function (months, interest) {
        return ($scope.slider.value * interest / months).toFixed(2);
    }

    $scope.show = function () {
        ModalService.showModal({
            templateUrl: 'app/modals/shoppingCartModal.html',
            controller: "productsController"
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function () {
                $("#delete").on('hidden.bs.modal', function () {
                    $scope.$apply();
                })
            });
        });
    };

    $scope.close = function (result) {
        close(result); // close, but give 500ms for bootstrap to animate
        window.location.href = '/Shop';
    };

    $scope.getRandomArbitrary = function (min, max) {
        return (Math.random() * (max - min) + min).toFixed(2);
    }

}]);