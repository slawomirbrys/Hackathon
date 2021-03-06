﻿
var app = angular.module('SimpleStackApp', ['ngRoute', 'LocalStorageModule', 'ngMaterial', 'angularModalService' ]);

app.config(function ($routeProvider) {

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
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

    $routeProvider.when("/shoppingCart", {
        controller: "productsController",
        templateUrl: "/app/views/shoppingCart.html"
    });
    
    $routeProvider.otherwise({ redirectTo: "/products" });

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

