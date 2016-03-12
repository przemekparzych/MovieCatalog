/// <reference path="angular.js" />


var movies;
var movieApp = angular
    .module("movieModule", [])
    .controller("movieController", ['$scope',function ($scope) {
        $scope.casts = [];
        $scope.casts.push($scope.addMe);
        var array = [];
        $scope.addItem = function (val) {
           
            array.push(val);
            $scope.casts=array;
        }
    }]);
