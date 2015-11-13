(function () {

    ClientSideEvent = function (message) {
        this.message = message;
    };

    'use strict';

    var app = angular.module("TestApp", ['signalR.eventAggregator']);

    app.controller("TestCtrl", ['$scope','$http', function ($scope, $http) {

        $scope.count = 0;
        $scope.message = "";
        $scope.incommingMessage = "message in - empty";

        function onEvent(e) {

            $scope.count++;

            console.log("event received => ", e);
        };

        function onClientEvent(message) {

            $scope.incommingMessage = message;
        };

        $scope.eventAggregator().subscribe(EventAgrTest.Events.MyMessage, onEvent);
        $scope.eventAggregator().subscribe(ClientSideEvent, onClientEvent);
        
        $scope.sendMessage = function () {

            $scope.eventAggregator().publish(new ClientSideEvent($scope.message));
        };

        $scope.headerText = "SignalR.EventAggregatorProxy simple event test app";
    }]);
})();