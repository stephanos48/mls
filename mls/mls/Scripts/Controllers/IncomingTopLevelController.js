//app.controller('IncomingTopLevelController', function ($scope) {
//    $scope.Message = "Hello World";
//});

// Share Data.
app.factory("ShareData", function () {
    return { value: 0 }
});

// Defining Routing.
app.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
        templateUrl: '/IncomingTopLevels/ShowIncoming',
        controller: 'IncomingTopLevelController'
    });

    $routeProvider.otherwise({ redirectTo: '/' });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});

app.controller('IncomingTopLevelController', function ($scope, $location, IncomingTopLevelService, ShareData, $window) {
    $scope.error = null;
    $scope.IncomingTopLevel = {
        IncomingVesselNo: '',
        InspectionDateTime: '',
        Notes: '',
        IncomingDetails: []
    };

    // Call to "getMovies" function.
    getIncomingTopLevels();

    // getMovies function.
    function getIncomingTopLevels() {
        IncomingTopLevelService.getIncomingTopLevels()
            .then(function (incomingtoplevel) {
                $scope.IncomingTopLevels = incomingtoplevel.data;
                console.log($scope.IncomingTopLevels);
            }
            , function (error) {
                $scope.error = 'Unable to load incoming data: ' + error.message;
                console.log($scope.error);
            });
    };
});