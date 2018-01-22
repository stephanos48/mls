//app-customers.js
(function () {

    "use strict";

    //Creating the module
    var app = angular.module("app-customers", [
        "simpleControls",
        "ngRoute"])
        .config(function ($routeProvider, $locationProvider) {
        $locationProvider.hashPrefix('');

        $routeProvider.when("/", {
            controller: "customersController",
            controllerAs: "vm",
            templateUrl: "/views/customerorders/ForumView.cshtml"
        });

        $routeProvider.when("/editor", {
            controller: "customerEditorController",
            controllerAs: "vm",
            templateUrl: "/views/tripEditorView.html"
        });

        $routeProvider.otherwise({ redirectTo: "/"});
    
    });
    
})();