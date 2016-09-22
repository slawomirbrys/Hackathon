
var app = angular.module('SimpleStackApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/myStocks", {
        controller: "myStocksController",
        templateUrl: "/app/views/myStocks.html"
    });

    $routeProvider.when("/stocks", {
        controller: "stocksController",
        templateUrl: "/app/views/stocks.html"
    });

    $routeProvider.when("/products", {
        controller: "productsController",
        templateUrl: "/app/views/products.html"
    });

    $routeProvider.when("/books", {
        controller: "booksController",
        templateUrl: "/app/views/books.html"
    });

    $routeProvider.when("/banks", {
        controller: "bankController",
        templateUrl: "/app/views/banks.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});

var serviceBase = 'http://localhost:26264/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngSimpleStockApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);