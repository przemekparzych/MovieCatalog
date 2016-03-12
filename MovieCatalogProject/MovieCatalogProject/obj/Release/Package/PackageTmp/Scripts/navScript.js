/// <reference path="angular.js" />


var movieApp = angular
    .module("navModule", [])
    .controller("navController", ['$scope', function ($scope) {
        $scope.index = 0;
        $scope.setIndex = function (val) {
            $scope.index = val;
        }
        $scope.getIndex = function () {
            return($scope.index);
        }
    }]);
