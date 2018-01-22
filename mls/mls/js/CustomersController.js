//customersController.js
(function () {

    "use strict";

    // Getting existing module
    angular.module("app-customers")
    .controller("customersController", customersController);

    function customersController($http) {

        var vm = this;

        vm.customers = [];

        vm.newCustomer = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/Customers")
        .then(function (response) {
            //Success
            console.log(response);
            angular.copy(response.data, vm.customers);
        }, function (error) {
            //Failure
            vm.errorMessage = "Failed to load our data" + error;
        })
        .finally(function() {
            vm.isBusy = false;
        });

        vm.addCustomer = function () {
            
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/Customers", vm.newCustomer)
                .then(function (response) {
                    // success
                    vm.customers.push(response.data);
                    vm.newCustomer = [];
                }, function () {
                    // failure
                    vm.errorMessage = "Failed to save new customer";
                })
            .finally(function () {
                vm.Busy = false;
            });
        };


    }

})();