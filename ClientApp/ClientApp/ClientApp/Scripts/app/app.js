

var ClientApp = angular.module('ClientApp', [
    'ngRoute',
    'ScheduleControllers'
]);

ClientApp.config(['$routeProvider', function ($routeProvider) {

    $routeProvider.when('/schedulelist', {
        templateUrl: '/Schedule/list.html',
        controller: 'ScheduleListController'
    }).

    otherwise({
        redirectTo: '/schedulelist'
    });

}]);

//