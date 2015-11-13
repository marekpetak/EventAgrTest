(function () {
    'use strict';

    var app = angular.module("TestApp", ['signalR.eventAggregator']);

    app.controller("TestCtrl", ['$scope','$http', function ($scope, $http) {

        function onEvent(e) {
            console.log("event received => ", e);
        };

        console.log("EventAgrTest.Events.MyMessage = " + EventAgrTest.Events.MyMessage);

        $scope.eventAggregator().subscribe(EventAgrTest.Events.MyMessage, onEvent);

        console.log("2: " + EventAgrTest.Events.MyMessage);

        $scope.headerText = "HEADER";
    }]);
})();