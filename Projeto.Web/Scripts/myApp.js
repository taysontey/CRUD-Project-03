var myApp = angular.module('myApp', []);

myApp.controller('listarTimes', function ($scope, $http) {

    $scope.times = "";

    $http.get("/Time/Consultar")
    .success(function (lista) {
        $scope.times = lista;
    })
    .error(function (msg) {
        console.log(msg);
    });
})