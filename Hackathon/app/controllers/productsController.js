'use strict';
app.controller('productsController', ['$scope', '$location', 'productService', 'authService', 'ModalService', '$mdDialog', function ($scope, $location, productService, authService, ModalService, $mdDialog) {

    $scope.products = [];
    $scope.status = '  ';
    $scope.customFullscreen = false;

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

    $scope.getRandomArbitrary = function (min, max) {
        return (Math.random() * (max - min) + min).toFixed(2);
    }


    $scope.showAdvanced = function(ev) {
        $mdDialog.show({
            controller: DialogController,
            templateUrl: 'app/modals/shoppingCartModal.tmpl.html',
            parent: angular.element(document.body),
            targetEvent: ev,
            clickOutsideToClose:true,
            fullscreen: $scope.customFullscreen // Only for -xs, -sm breakpoints.
        })
        .then(function(answer) {
            $scope.status = 'You said the information was "' + answer + '".';
        }, function() {
            $scope.status = 'You cancelled the dialog.';
        });
    };

    $scope.selectRow = function (row) {
        var i;
        for (i = 1; i <= 4; i++) {
            jQuery('#' + i).removeClass('selected');
        }

        jQuery('#' + row).addClass('selected');
    }

    function DialogController($scope, $mdDialog) {
        $scope.hide = function() {
            $mdDialog.hide();
        };

        $scope.cancel = function() {
            $mdDialog.cancel();
        };

        $scope.answer = function(answer) {
            $mdDialog.hide(answer);
        };
    };

}]);