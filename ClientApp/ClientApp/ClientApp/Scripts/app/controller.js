

var ScheduleControllers = angular.module("ScheduleControllers", []);


var DataService = angular.module("ClientApp").factory('DataService',function ($http) {
    
       var getData = function(stopNum) {
            return $http.get('http://localhost:59167/api/scheduler',
                {
                    params: { stop: stopNum },
                    headers: {authToken:'4961fe48dd054f67ac82734a2f37bb25'}
                }).then(function (response) {
                    return response.data;
                })
                .catch(function (data) {
                    //handle error
                    console.log("error returning data");
                });
            
       }

       return {
           getData: getData
       };



})


ScheduleControllers.controller("ScheduleListController", ['$scope', '$http','DataService',
    function ($scope, $http,DataService) {

        var stopNum = 1;

        DataService.getData(stopNum)
            .then(function (data) {

                $scope.schedules1 = data;

                $scope.combinedArrivals1 = combineItems($scope.schedules1);

            });

        stopNum = 2;

        DataService.getData(stopNum)
        .then(function (data) {

        $scope.schedules2 = data;

        $scope.combinedArrivals2 = combineItems($scope.schedules2);

        });

        $scope.stop1CountTest = function () {

            var countLength;

            DataService.getData(1)
                    .then(function (data) {

                        $scope.schedulesTest = data;
                        $scope.combinedArrivalsTest = combineItems($scope.schedulesTest);
                        countLength =  $scope.combinedArrivalsTest.length;
                    });

            return countLength;
        };


            function combineItems(schedules) {

                var dictionaryItems = [];
                angular.forEach(schedules, function (value, key) {
                    var addItem = 'true';

                    if (dictionaryItems.length > 0) {

                        for (var item in dictionaryItems) {
                            if (dictionaryItems[item]['key'] != undefined && dictionaryItems[item]['key'] == value.route) {
                                dictionaryItems[item]['value'] = dictionaryItems[item]['value'] + ' and ' + value.arrivalMins + ' mins. ';
                                addItem = false;
                                break;
                            }
                        }
                    }
                    if (addItem == 'true') {
                        var dict = {};
                        dict['key'] = value.route;
                        dict['value'] = value.arrivalMins + ' mins. ';
                        dictionaryItems.push(dict);

                    }
                });

                return dictionaryItems;

            }

        
    }]
);




