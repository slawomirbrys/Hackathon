'use strict';
app.controller('bankController', ['$scope', 'productService', 'authService', function ($scope, productService, authService) {

    $scope.banks = [];
    $scope.choosedBank = "";


    productService.getBanks().then(function (results) {
        $scope.banks = results.data;
    }, function (error) {
        console.log(error.data.message);
    });

    $scope.chooseBank = function (index) {
        var selectedBank = $scope.banks[index];
        $scope.choosedBank = selectedBank.BankName;
        //stocksService.buyStock(stockToBuy.code);
        //stockToBuy.isMyStock = true;
    };

}]);